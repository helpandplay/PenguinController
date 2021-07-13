using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3phaseMoterControl
{
  public partial class PLCSetting : Form
  {
    PLC plc = new PLC();
    public PLCSetting()
    {
      InitializeComponent();
    }
    private bool CheckValidInput(string input)
    {
      int num;
      if (int.TryParse(input, out num))
      {
        return true;
      }
      MessageBox.Show("유효하지 않은 PLC 번호 입니다.");
      return false;
    }
    private void PLCSetting_Load(object sender, EventArgs e)
    {
      plc = new PLC();
    }
    private void btn_test_Click(object sender, EventArgs e)
    {
      string input = tb_input.Text;
      bool isSuccess = CheckValidInput(input);
      if (!isSuccess) return;

      plc.setStationNum(int.Parse(input));

      bool result = plc.OnConnect();
      if (!result)
      {
        MessageBox.Show("연결에 실패했습니다.");
        return;
      }
      result = plc.OnClosed();
      if (!result)
      {
        MessageBox.Show("테스트에 실패했습니다. ");
        return;
      }
      MessageBox.Show("연결 성공");
    }
    private void btn_connect_Click(object sender, EventArgs e)
    {
      string input = tb_input.Text;
      bool isSuccess = CheckValidInput(input);
      if (!isSuccess) return;

      plc.setStationNum(int.Parse(input));
      bool result = plc.OnConnect();
      if (!result)
      {
        MessageBox.Show("연결에 실패했습니다.");
        return;
      }
      this.Close();
    }
  }
}
