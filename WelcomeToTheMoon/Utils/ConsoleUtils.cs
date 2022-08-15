using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeToTheMoon.Utils
{
    public static class ConsoleUtils
    {
        public static string GetLine(int pLength)
        {
            return new string('-', pLength);
        }
    }
}
