using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace _3phaseMoterControl
{
  public partial class App : Form
  {
    private System.Threading.Timer PLCmonitoringTimer = null;
    private System.Threading.Timer InverterMonitoringTimer = null;
    private System.Windows.Forms.Timer motorTimer = null;
    private Inverter inverter = new Inverter();
    private PLC plc = new PLC();
    private int graphCnt = 0;

    private int motorTimerHours = 0;
    private int motorTimerMinute = 0;
    private int motorTimerSec = 0;
    public App()
    {
      InitializeComponent();
    }
    // PLC monitoring
    private void PLCMonitoringStart(TimerCallback callback, int stateTime, int tick)
    {
      //plc setting click에 있음
      PLCmonitoringTimer = new System.Threading.Timer(callback, null, stateTime, tick);
    }
    private void PLCMonithoringStop()
    {
      rect_run.BackColor = Styles.red;
      rect_stop.BackColor = Styles.red;
      rect_alarm.BackColor = Styles.red;
      PLCmonitoringTimer.Dispose();
    }
    private void PLCMonitoringOperation(object status)
    {
        this.Invoke(new Action(delegate ()
        {
          if (CheckConnectPLC())
          {
            GetPLCStatus();
          }
        }));
    }
    // Inverter Monitoring
    private void InverterMonitoringStart(TimerCallback callback, int stateTime, int tick)
    {
      //plc setting click에 있음
      InverterMonitoringTimer = new System.Threading.Timer(callback, null, stateTime, tick);
    }
    private void InverterMonithoringStop()
    {
      rect_run.BackColor = Styles.red;
      rect_stop.BackColor = Styles.red;
      rect_alarm.BackColor = Styles.red;
      InverterMonitoringTimer.Dispose();
    }
    private void InverterMonitoringOperation(object status)
    {
      this.Invoke(new Action(delegate ()
      {
        if (CheckConnectPort())
        {
          GetInverterStatus();
          //Hz, A, V
          string res = inverter.resData();
          string[] InverterData = inverter.SeperateOutputData(res);
          //부하, 토크
          GetMotorTok();
          res = inverter.resData();
          string moterTokData = inverter.SeperateData(res);

          res = inverter.resData();
          if (plc.IsConnect())
          {
            DisplayInverterData(InverterData);
            DisplayMotorData(moterTokData);

            string[] moterData = new string[1] { moterTokData };
            string[] outputData = new string[InverterData.Length + moterData.Length];
            InverterData.CopyTo(outputData, 0);
            moterData.CopyTo(outputData, InverterData.Length);
            short[] data = plc.StringsToWords(outputData);

            plc.WriteMultipleWord(Device.Hz, data.Length, data);
          }
        }
      }));
    }
    // Timer
    private void MotorTimerStart()
    {
      motorTimer = new System.Windows.Forms.Timer();
      motorTimer.Tick += MotorTick;
      motorTimer.Interval = 1000;
      motorTimer.Start();
    }
    private void MotorTick(object sender, EventArgs e)
    {
      motorTimerSec++;
      if(motorTimerSec >= 60)
      {
        motorTimerSec = 0;
        motorTimerMinute++;
      }
      if(motorTimerMinute >= 60)
      {
        motorTimerMinute = 0;
        motorTimerHours++;
      }
      string sec = motorTimerSec <= 10 ? "0" + motorTimerSec.ToString() : motorTimerSec.ToString();
      string min = motorTimerMinute <= 10 ? "0" + motorTimerMinute.ToString() : motorTimerMinute.ToString();
      string hour = motorTimerHours <= 10 ? "0" + motorTimerHours.ToString() : motorTimerHours.ToString();

      string time = hour + ":" + min + ":" + sec;
      lb_time.Text = time;
    
    }
    private void OnControlMotorTimer()
    {
      if (cb_fast.Checked || cb_normal.Checked || cb_slow.Checked)
      {
        if (motorTimer == null)
        {
          MotorTimerStart();
        }
      }
      else
      {
        if(motorTimer != null)
        {
          motorTimer.Stop();
          motorTimer.Dispose();
        }
        motorTimer = null;
      }
    }
    //control
    private void GetMotorTok()
    {
      byte[] reqData = inverter.ConvertReqDataFormat(Instructor.GET_MOTER_TOK);
      inverter.ReqData(reqData);
      Thread.Sleep(100);
    }
    private void GetInverterStatus()
    {
      byte[] reqData = inverter.ConvertReqDataFormat(Instructor.GET_ALL_OUTPUT);
      inverter.ReqData(reqData);
      Thread.Sleep(100);
    }
    private void GetPLCStatus()
    {
      //plc 전동기 상태
      MonitoringPLCOperationStatus();
      MonitoringPLCRotaionStatus();
      MonitoringPLCSpeedStatus();
      MonitoringPLCVarStatus();
    }
    private void MonitoringPLCRotaionStatus()
    {
      short isCW = plc.ReadWord(Device.CWRes);
      short isCCW = plc.ReadWord(Device.CCWRes);

      if (isCW == Instructor.ON) cb_cw.Checked = true;
      else cb_cw.Checked = false;

      if (isCCW == Instructor.ON) cb_ccw.Checked = true;
      else cb_ccw.Checked = false;
    }
    private void MonitoringPLCSpeedStatus()
    {
      short isFast = plc.ReadWord(Device.FASTRes);
      short isNormal = plc.ReadWord(Device.NORMALRes);
      short isSlow = plc.ReadWord(Device.SLOWRes);

      if (isFast == Instructor.ON) cb_fast.Checked = true;
      else cb_fast.Checked = false;
      if (isNormal == Instructor.ON) cb_normal.Checked = true;
      else cb_normal.Checked = false;
      if (isSlow == Instructor.ON) cb_slow.Checked = true;
      else cb_slow.Checked = false;
    }
    private void MonitoringPLCVarStatus()
    {
      short isON = plc.ReadWord(Device.varRes);
      if(isON == Instructor.ON)
      {
        cb_varOff.Checked = false;
        cb_varON.Checked = true;
      }
      else
      {
        cb_varON.Checked = false;
        cb_varOff.Checked = true;
      }
    }
    private void MonitoringPLCOperationStatus()
    {
      short isRun = plc.ReadWord(Device.RUN);
      short isStop = plc.ReadWord(Device.STOP);
      short isALARM = plc.ReadWord(Device.ALARM);
      Debug.WriteLine("RUN : " + isRun + " STOP : " + isStop + " ALARM : " + isALARM);

      if (isRun == Instructor.ON) rect_run.BackColor = Styles.green;
      else rect_run.BackColor = Styles.red;

      if (isStop == Instructor.ON) rect_stop.BackColor = Styles.green;
      else rect_stop.BackColor = Styles.red;

      if (isALARM == Instructor.ON) rect_alarm.BackColor = Styles.green;
      else rect_alarm.BackColor = Styles.red;
    }
    private void DisplayInverterData(string[] data)
    {
      data = inverter.ConvertOutputData(data);

      if (graphCnt > 60)
      {
        chart_Hz.Series[0].Points.RemoveAt(0);
        chart_A.Series[0].Points.RemoveAt(0);
        chart_V.Series[0].Points.RemoveAt(0);

        chart_Hz.ChartAreas[0].AxisX.Minimum = chart_Hz.Series[0].Points[0].XValue;
        chart_A.ChartAreas[0].AxisX.Minimum = chart_A.Series[0].Points[0].XValue;
        chart_V.ChartAreas[0].AxisX.Minimum = chart_V.Series[0].Points[0].XValue;

        chart_Hz.ChartAreas[0].AxisX.Maximum = graphCnt;
        chart_A.ChartAreas[0].AxisX.Maximum = graphCnt;
        chart_V.ChartAreas[0].AxisX.Maximum = graphCnt;


      }

      lb_hz.Text = data[0];
      lb_a.Text = data[1];
      lb_v.Text = data[2];

      double hz = double.Parse(data[0]);
      double a = double.Parse(data[1]);
      double v = double.Parse(data[2]);

      chart_Hz.Series[0].Points.AddXY(graphCnt, hz);
      chart_A.Series[0].Points.AddXY(graphCnt, a);
      chart_V.Series[0].Points.AddXY(graphCnt, v);



      graphCnt++;
    }
    private void DisplayMotorData(string tok )
    {
      tok = inverter.ConvertMotorData(tok);
      lb_tok.Text = tok + "%";
    }
    private bool CheckConnectPLC()
    {
      if (plc.IsConnect())
      {
        rect_PLC.BackColor = Styles.green;
        return true;
      }
      rect_PLC.BackColor = Styles.red;
      return false;
    }
    private bool CheckConnectPort()
    {
      if (Inverter.serialPort.IsOpen)
      {
        rect_inverter.BackColor = Styles.green;
        return true;
      }
      rect_inverter.BackColor = Styles.red;
      return false;
    }
    private void PLCReset()
    {
      if (!cb_cw.Checked && !cb_ccw.Checked)
      {
        cb_varOff.Checked = false;
        cb_varON.Checked = false;
        cb_fast.Checked = false;
        cb_normal.Checked = false;
        cb_slow.Checked = false;

        plc.WriteWord(Device.varSwit, Instructor.OFF);
        if (PLCmonitoringTimer != null)
        {
          PLCMonithoringStop();
          PLCmonitoringTimer = null;
        }
      }
    }
    private void InverterReset()
    {
      if (InverterMonitoringTimer != null)
      {
        InverterMonithoringStop();
        InverterMonitoringTimer = null;
      }
    }
    //event
    private void App_FormClosed(object sender, FormClosedEventArgs e)
    {
      Inverter.serialPort.Close();
      if (PLCmonitoringTimer != null)
      {
        PLCMonithoringStop();
        PLCmonitoringTimer = null;
      }
      if (InverterMonitoringTimer != null)
      {
        InverterMonithoringStop();
        InverterMonitoringTimer = null;
      }
    }
    private void serialPort_DataReceived(object sender, EventArgs e)
    {
      if (!Inverter.serialPort.IsOpen) return;
      this.Invoke(new MethodInvoker(delegate { inverter.resData(); }));
    }
    private void btn_plc_setting_Click(object sender, EventArgs e)
    {
      Button button = (Button)sender;

      if(button.Text == "끊기")
      {
        if(cb_fast.Checked || cb_normal.Checked || cb_slow.Checked)
        {
          DialogResult result =MessageBox.Show("작동 중입니다. 연결을 끊으시겠습니까?", "Question", MessageBoxButtons.OKCancel);
          if (result == DialogResult.Cancel) return;
        }
        PLCReset();
        plc.OnClosed();
        button.Text = "설정";
        rect_PLC.BackColor = Styles.red;
        return;
      }
      PLCSetting plcSetting = new PLCSetting();
      plcSetting.ShowDialog();
      // todo : plc가 연결되는 지 확인한 후, 램프 켜기0
      bool isConnect = CheckConnectPLC();
      if (isConnect)
      {
        PLCMonitoringStart(PLCMonitoringOperation, 100, 1000);
        button.Text = "끊기";
      }
        
    }
    private void btn_Inverter_setting_Click(object sender, EventArgs e)
    {
      Button button = (Button)sender;

      if (button.Text == "끊기")
      {
        InverterReset();
        button.Text = "설정";
        rect_inverter.BackColor = Styles.red;
        return;
      }

      PortSetting setting = new PortSetting();
      setting.ShowDialog();
      bool isConnect = CheckConnectPort();

      if (isConnect)
      {
        Inverter.serialPort.DataReceived
          += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        InverterMonitoringStart(InverterMonitoringOperation, 100, 1000);
        button.Text = "끊기";
      }
    }
    //checkbox
    private void OnableVarSwit()
    {
      if (cb_fast.Checked || cb_normal.Checked || cb_normal.Checked)
      {
        cb_varOff.Enabled = false;
        cb_varON.Enabled = false;
      }
      else
      {
        cb_varOff.Enabled = true;
        cb_varON.Enabled = true;
      }
    }
    private void cb_cw_Click(object sender, EventArgs e)
    {

      CheckBox checkBox = (CheckBox)sender;
      if (!plc.IsConnect())
      {
        checkBox.Checked = false;
        return;
      }
      if (checkBox.Checked)
      {
        cb_cw.Checked = true;
        cb_ccw.Checked = false;
        if (!cb_varON.Checked) cb_varOff.Checked = true;

        plc.WriteWord(Device.CW, Instructor.ON);
      }
      else
      {
        cb_cw.Checked = false;
        plc.WriteWord(Device.CWRst, Instructor.ON);
      }
    }
    private void cb_ccw_Click(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox)sender;
      if (!plc.IsConnect())
      {
        checkBox.Checked = false;
        return;
      }
      if (checkBox.Checked)
      {
        cb_ccw.Checked = true;
        cb_cw.Checked = false;
        if(!cb_varON.Checked) cb_varOff.Checked = true;

        plc.WriteWord(Device.CCW, Instructor.ON);
      }
      else
      {
        cb_ccw.Checked = false;
        plc.WriteWord(Device.CCWRst, Instructor.ON);
      }
    }
    private void cb_fast_Click(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox)sender;
      if (!cb_cw.Checked && !cb_ccw.Checked)
      {
        checkBox.Checked = false;
        MessageBox.Show("운전을 먼저 선택해주세요.");
        return;
      }

      if (checkBox.Checked)
      {
        cb_fast.Checked = true;
        cb_normal.Checked = false;
        cb_slow.Checked = false;

        plc.WriteWord(Device.FAST, Instructor.ON);
      }
      else
      {
        cb_fast.Checked = false;
        plc.WriteWord(Device.FASTRst, Instructor.ON);
      }
      OnableVarSwit();
      OnControlMotorTimer();

    }
    private void cb_normal_Click(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox)sender;
      if (!cb_cw.Checked && !cb_ccw.Checked)
      {
        MessageBox.Show("운전을 먼저 선택해주세요.");
        checkBox.Checked = false;
        return;
      }

      if (checkBox.Checked)
      {
        cb_fast.Checked = false;
        cb_normal.Checked = true;
        cb_slow.Checked = false;

        plc.WriteWord(Device.NORMAL, Instructor.ON);
      }
      else
      {
        cb_normal.Checked = false;
        plc.WriteWord(Device.NORMALRst, Instructor.ON);
      }
      OnableVarSwit();
      OnControlMotorTimer();
    }
    private void cb_slow_Click(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox)sender;
      if (!cb_cw.Checked && !cb_ccw.Checked)
      {
        MessageBox.Show("운전을 먼저 선택해주세요.");
        checkBox.Checked = false;
        return;
      }

      if (checkBox.Checked)
      {
        cb_fast.Checked = false;
        cb_normal.Checked = false;
        cb_slow.Checked = true;

        plc.WriteWord(Device.SLOW, Instructor.ON);
      }
      else
      {
        cb_slow.Checked = false;
        plc.WriteWord(Device.SLOWRst, Instructor.ON);
      }
      OnableVarSwit();
      OnControlMotorTimer();
    }
    private void cb_varOff_Click(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox)sender;
      if (cb_fast.Checked || cb_normal.Checked || cb_slow.Checked)
      {
        checkBox.Checked = false;
        return;
      }
      if (!cb_ccw.Checked && !cb_cw.Checked)
      {
        checkBox.Checked = false;
        return;
      };
      cb_varOff.Checked = true;
      cb_varON.Checked = false;

      plc.WriteWord(Device.varSwit, Instructor.OFF);
    }
    private void cb_varON_Click(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox)sender;
      if (cb_fast.Checked || cb_normal.Checked || cb_slow.Checked)
      {
        checkBox.Checked = false;
        return;
      }
      if (!cb_ccw.Checked && !cb_cw.Checked)
      {
        checkBox.Checked = false;
        return;
      };
      cb_varOff.Checked = false;
      cb_varON.Checked = true;

      plc.WriteWord(Device.varSwit, Instructor.ON);
    }

    private void App_Load(object sender, EventArgs e)
    {
      chart_Hz.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      chart_Hz.Series[0].BorderWidth = 2;
      chart_Hz.Series[0].Color = Styles.tomato;
      chart_Hz.ChartAreas[0].AxisX.Minimum = 0;
      chart_Hz.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
      chart_Hz.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;

      chart_A.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      chart_A.Series[0].BorderWidth = 2;
      chart_A.Series[0].Color = Styles.green;
      chart_A.ChartAreas[0].AxisX.Minimum = 0;
      chart_A.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
      chart_A.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;

      chart_V.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      chart_V.Series[0].BorderWidth = 2;
      chart_V.Series[0].Color = Styles.green;
      chart_V.ChartAreas[0].AxisX.Minimum = 0;
      chart_V.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
      chart_V.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;

      pictureBox1.Image = Properties.Resources.penguin;
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

    }
  }
}
