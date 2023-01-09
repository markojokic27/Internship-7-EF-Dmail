using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Actions
{
    public static class Helpers
    {
        public static void PressAnyButton(string message)
        {
            Console.WriteLine($"Pritisnite bilo koju tipku {message}");
            Console.ReadKey();
        }
    }
}
