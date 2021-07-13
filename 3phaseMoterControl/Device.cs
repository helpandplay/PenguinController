using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3phaseMoterControl
{
  class Device
  {
    public const string RUN = "M10";
    public const string STOP = "M11";
    public const string ALARM = "M12";

    public const string CW = "B0";
    public const string CWRst = "B10";
    public const string CWRes = "M0";
    public const string CCW = "B1";
    public const string CCWRst = "B11";
    public const string CCWRes = "M1";

    public const string FAST = "B2";
    public const string FASTRst = "B12";
    public const string FASTRes = "M2";
    public const string NORMAL = "B3";
    public const string NORMALRst = "B13";
    public const string NORMALRes = "M3";
    public const string SLOW = "B4";
    public const string SLOWRst = "B14";
    public const string SLOWRes = "M4";
    public const string varRes = "M5";
    public const string varSwit = "B6";

    public const string Hz = "D100";
    public const string A = "D101";
    public const string V = "D102";
    public const string TOK = "D103";
  }
}
