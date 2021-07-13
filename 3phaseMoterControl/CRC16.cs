using System;

namespace _3phaseMoterControl
{
  public static class CRC16
  {
    const ushort polynomial = 0xA001;
    static readonly ushort[] table = new ushort[256];
    static CRC16()
    {
      ushort value;
      ushort temp;
      for (ushort i = 0; i < table.Length; i++)
      {
        value = 0;
        temp = i;
        for (byte j = 0; j < 8; j++)
        {
          if (((value ^ temp) & 0x0001) != 0)
          {
            value = (ushort)((value >> 1) ^ polynomial);
          }
          else
          {
            value >>= 1;
          }
          temp >>= 1;
        }
        table[i] = value;
      }
    }
    public static byte[] ComputeChecksum(byte[] bytes)
    {
      int icrc = 0xFFFF;
      for (int i = 0; i < bytes.Length; i++)
      {
        icrc = (icrc >> 8) ^ table[(icrc ^ bytes[i]) & 0xff];
      }
      byte[] ret = BitConverter.GetBytes(icrc);

      byte[] result = new byte[2];
      int cnt = 0;
      foreach (byte h in ret)
      {
        if (h.ToString("X2") != "00")
          result[cnt++] = h;
      }

      return result;
    }

  }
}
