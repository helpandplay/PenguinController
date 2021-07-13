using System;
using ACTMULTILib; //mx component (PLC 통신 연결 라이브러리)

namespace _3phaseMoterControl
{
  class PLC
  {
    public static ActEasyIF plc = new ActEasyIF();
    static bool isConnect = false;
    static bool isClosed = false;
    public bool IsConnect()
    {
      return isConnect;
      
    }
    public bool IsClosed()
    {
      return isClosed;
    }
    public bool OnConnect()
    {
      bool isSuccess = true;
      string error;
      if (plc.ActLogicalStationNumber == 0)
      {
        error = string.Format("Not Set PLC station Num");
        System.Windows.Forms.MessageBox.Show(error);
        isSuccess = false;
        return isSuccess;
      }
      int iRet = plc.Open();
      if (iRet != 0)
      {
        error = string.Format("Error PLC Check connection: {0}", iRet.ToString("X"));
        System.Windows.Forms.MessageBox.Show(error);
        isSuccess = false;
      }
      else
      {
        isConnect = true;
        isClosed = false;
      }
      return isSuccess;
    }
    public bool OnClosed()
    {
      bool isSuccess = true;
      int iRet = plc.Close();
      if (iRet != 0)
      {
        string error = string.Format("Error PLC closed : {0}", iRet.ToString("X"));
        throw new Exception(error);
      }
      else
      {
        isClosed = true;
        isConnect = false;
      }
      return isSuccess;
    }
    public void setStationNum(int stationNum)
    {
      plc.ActLogicalStationNumber = stationNum;
    }
    // 1 word rw
    public short ReadWord(string device)
    {
      short getdata;

      int result = plc.GetDevice2(device, out getdata);
      if (result == 0) return getdata;

      string error = string.Format("error : {0}, 워드 읽기 실패", result.ToString("X"));
      System.Windows.Forms.MessageBox.Show(error);

      return -1;
    }
    public bool WriteWord(string device, short data)
    {
      bool isSuccess = false;
      int result = plc.SetDevice2(device, data);
      if (result == 0)
      {
        isSuccess = true;
      }
      else
      {
        string error = string.Format("Error Write Word : {0}", result.ToString("X"));
        System.Windows.Forms.MessageBox.Show(error);
      }
      return isSuccess;
    }
    // 2 word rw
    public short[] ReadMultipleWord(string device, int len)
    {
      short[] data = new short[2];
      int result = plc.ReadDeviceBlock2(device, len, out data[0]);
      if (result == 0) return data;

      string error = string.Format("error Read multiple Word : {0}", result.ToString("X"));
      System.Windows.Forms.MessageBox.Show(error);
      return data;
    }
    public bool WriteMultipleWord(string device, int len , short[] data)
    {
      bool isSuccess = false;
      int result = plc.WriteDeviceBlock2(device, len, ref data[0]);
      if (result == 0)
      {
        isSuccess = true;
      }
      else
      {
        string error = string.Format("Error Write multiple Word : {0}", result.ToString("X"));
        System.Windows.Forms.MessageBox.Show(error);
      }
      return isSuccess;
    }
    //casting
    public short[] StringsToWords(string[] input)
    {
      short[] result = new short[input.Length];
      int cnt = 0;
      foreach(string str in input)
      {
        short s = Convert.ToInt16(str, 16);
        result[cnt++] = s;
      }
      return result;
    }
    private short[] StringToDoubleWord(string input)
    {
      // 0x12345678 : 1234 = low, 5678 = high
      string hex = int.Parse(input).ToString("X2").PadLeft(8, '0');
      short high = Convert.ToInt16(hex.Substring(0, 4), 16);
      short low = Convert.ToInt16(hex.Substring(4, 4), 16);

      return new short[2] { low, high };
    }
    private string DoubleWordToString(short[] hex)
    {
      // 0x12345678 : 1234 = low, 5678 = high
      string low = hex[0].ToString("X2").PadLeft(4, '0'); // 16진수 = x2, 왼쪽부터 0으로 채움
      string high = hex[1].ToString("X2").PadLeft(4, '0');
      string dword = high + low; // high word + low word (important sequence)
      int DwordInt = Convert.ToInt32(dword, 16); //16진수 0xffffffff를 10진수 32bit형태로 변경

      return DwordInt.ToString();
    }
  }
}
