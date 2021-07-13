using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace _3phaseMoterControl
{
  public partial class PortSetting : Form
  {
    public PortSetting()
    {
      InitializeComponent();
     
    }
    private void LoadComPorts()
    {
      string[] ports = SerialPort.GetPortNames();
      cb_comPort.Items.AddRange(ports);
    }
    //set serial port
    private void SetCOM(string data)
    {
      Inverter.serialPort.PortName = data;
    }
    private void SetBaud(string data)
    {
      Inverter.serialPort.BaudRate = int.Parse(data);
    }
    private void SetDataBit(string data)
    {
      Inverter.serialPort.DataBits = int.Parse(data);
    }
    private void SetStopBit(string data)
    {
      string input = data;
      StopBits stopBits;
      switch (input)
      {
        case "1":
          stopBits = StopBits.One;
          break;
        case "1.5":
          stopBits = StopBits.OnePointFive;
          break;
        case "2":
          stopBits = StopBits.Two;
          break;
        default:
          throw new Exception("stopbit set Error! value : " + input);
      }
      Inverter.serialPort.StopBits = stopBits;
    }
    private void SetParity(string data)
    {
      string input = data;
      Parity parity;
      switch (input)
      {
        case "None":
          parity = Parity.None;
          break;
        case "Even":
          parity = Parity.Even;
          break;
        case "Mark":
          parity = Parity.Mark;
          break;
        case "Odd":
          parity = Parity.Odd;
          break;
        case "Space":
          parity = Parity.Space;
          break;
        default:
          throw new Exception("Parity Set Error! value : " + input);
      }
      Inverter.serialPort.Parity = parity;
    }
    private void SetHandShaking(string data)
    {
      string input = data;
      Handshake handshake;
      switch (input)
      {
        case "None":
          handshake = Handshake.None;
          break;
        case "RTS/CTS":
          handshake = Handshake.RequestToSend;
          break;
        case "XON/XOFF":
          handshake = Handshake.XOnXOff;
          break;
        case "RTS/CTS + XON/XOF":
          handshake = Handshake.RequestToSendXOnXOff;
          break;
        default:
          throw new Exception("handshaking set Error! value : " + input);
      }
      Inverter.serialPort.Handshake = handshake;
    }
    //event
    private void Setting_Load(object sender, EventArgs e)
    {
      LoadComPorts();
      Inverter.serialPort.Close();
      Inverter.serialPort.PortName = "None";
    }
    private void cb_comPort_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetCOM(cb_comPort.Text);
    }
    private void cb_baud_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetBaud(cb_baud.Text);
    }
    private void cb_dataBit_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetDataBit(cb_dataBit.Text);
    }
    private void cb_stopBit_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetStopBit(cb_stopBit.Text);
    }
    private void cb_parity_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetParity(cb_parity.Text);
    }
    private void cb_handshaking_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetHandShaking(cb_handshaking.Text);
    }
    //btn
    private void btn_default_Click(object sender, EventArgs e)
    {
      cb_baud.Text = "9600";
      cb_dataBit.Text = "8";
      cb_stopBit.Text = "1";
      cb_parity.Text = "None";
      cb_handshaking.Text = "None";

      SetBaud(cb_baud.Text);
      SetDataBit(cb_dataBit.Text);
      SetStopBit(cb_stopBit.Text);
      SetParity(cb_parity.Text);
      SetHandShaking(cb_handshaking.Text);
    }
    private void btn_test_Click(object sender, EventArgs e)
    {
      if (!CheckValidate()) return; 
      try
      {
        Inverter.serialPort.Open();

        if (Inverter.serialPort.IsOpen)
          MessageBox.Show("Successfully Connection!");
        else
          MessageBox.Show("Failed Connection!");

        if (Inverter.serialPort.IsOpen)
          Inverter.serialPort.Close();
      }catch(Exception error)
      {
        throw new Exception("test Error! \n message : " + error.Message);
      }
    }
    private void btn_connect_Click(object sender, EventArgs e)
    {
      if (!CheckValidate()) return;
      try
      {
        Inverter.serialPort.Open();
        this.Close();
      }catch(Exception error)
      {
        throw new Exception("Connection Error! \n message : " + error.Message);
      }
    }
    private bool CheckValidate()
    {
      if (Inverter.serialPort.PortName == "None")
      {
        MessageBox.Show("COM포트 설정을 하세요.");
        return false;
      }
      string com = cb_comPort.Text;
      string baud = cb_baud.Text;
      string databit = cb_dataBit.Text;
      string stopbit = cb_stopBit.Text;
      string parity = cb_parity.Text;
      string handshaking = cb_handshaking.Text;
      string empty = string.Empty;

      if (com == empty ||
        baud == empty ||
        databit == empty ||
        stopbit == empty ||
        parity == empty ||
        handshaking == empty)
      {
        MessageBox.Show("연결에 실패했습니다. 설정을 확인하세요.");
        return false;
      }

      return true;
    }
  }
}
