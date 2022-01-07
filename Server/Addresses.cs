using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BergersCode
{
    public static class Addresses
    {
        public static string IpAddress = "127.0.0.1";
        public static string MainPort = "1";

        public static bool[] connections1 = new bool[8] { false, false, true, false, false, false, false, false };
        public static bool[] connections2 = new bool[8] { false, false, true, false, false, false, false, false };
        public static bool[] connections3 = new bool[8] { true, true, false, true, false, false, false, false };
        public static bool[] connections4 = new bool[8] { false, false, true, false, true, false, false, false };
        public static bool[] connections5 = new bool[8] { false, false, false, true, false, true, true, false };
        public static bool[] connections6 = new bool[8] { false, false, false, false, true, false, false, true };
        public static bool[] connections7 = new bool[8] { false, false, false, false, true, false, false, false };
        public static bool[] connections8 = new bool[8] { false, false, false, false, false, true, false, false };

        public static bool[][] ConnectionsMap = new bool[8][] { connections1, connections2, connections3, connections4, connections5, connections6, connections7, connections8 };
    }
}
