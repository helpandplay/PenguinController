using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3phaseMoterControl
{
  public static class Instructor
  {
    public const string GET_HZ = "010300c80001";
    public const string GET_A = "010300c90001";
    public const string GET_V = "010300ca0001";
    public const string GET_ALL_OUTPUT = "010300c80003";
    public const string GET_MOTER_TOK = "010300CE0001";
    public const string GET_MOTER_ELOAD = "010300DF0001";

    public const int ON = 1;
    public const int OFF = 0;
  }
}
