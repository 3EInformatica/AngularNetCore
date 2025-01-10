using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Common
{
    internal class Convertitori
    {
        public static bool ConvertiBool(string value)
        {
            if (value == "0")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
