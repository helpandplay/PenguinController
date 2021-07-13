using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace _3phaseMoterControl
{
  public class Inverter
  {
    public static SerialPort serialPort = new SerialPort();
    private string HexToString(string Hex, double unit)
    {
      string result = string.Empty;
      int hz = Convert.ToInt32(Hex, 16);

      double Wreal = hz / unit;
      result = string.Format("{0, 4:N2}", Wreal);

      return result;
    }
    private  byte[] getStringToHex(string input)
    {
      byte[] result = new byte[input.Length / 2];
      int cnt = 0;
      for (int i = 1; i < input.Length; i = i + 2)
      {
        string str = input[i - 1].ToString() + input[i].ToString();
        result[cnt++] = Convert.ToByte(str, 16);
      }
      return result;
    }
    public byte[] ConvertReqDataFormat(string input)
    {
      byte[] hex = getStringToHex(input);
      byte[] crc = CRC16.ComputeChecksum(hex);

      byte[] result = new byte[hex.Length + crc.Length];
      hex.CopyTo(result, 0);
      crc.CopyTo(result, hex.Length);
      return result;
    }
    public void ReqData(byte[] data)
    {     
      serialPort.Write(data, 0, data.Length);
    }     
    public string resData()
    {
      int iSize = serialPort.BytesToRead;

      string data = string.Empty;
      if (iSize == 0) return string.Empty;
      byte[] buffer = new byte[iSize];
      serialPort.Read(buffer, 0, iSize);
      foreach (byte bufferData in buffer)
      {
        data += "" + bufferData.ToString("X2");
      }
      return data;
    }

    public string[] SeperateOutputData(string input)
    {
      string data = input.Substring(6, 12);
      string hz = data.Substring(0, 4);
      string a = data.Substring(4, 4);
      string v = data.Substring(8, 4);

      return new string[] { hz, a, v };
    }
    public string SeperateData(string input)
    {
      string data = input.Substring(4, 4);
      return data;
    }

    public string[] ConvertOutputData(string[] input)
    {
      string[] result = new string[]
      {
        HexToString(input[0], 100.0),
        HexToString(input[1], 100.0),
        HexToString(input[2], 10.0)
      };
      return result;
    }
    public string ConvertMotorData(string input)
    {
      return HexToString(input, 10.0);
    }
  }
}
