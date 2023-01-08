using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus
{
    public static class MenuInput
    {
        public static int GetInput(int max)
        {
            int input=0;
            var checker = false;
            while(checker==false) 
            {
                checker=int.TryParse(Console.ReadLine(),out input);
                if(input<1 || input >max)
                    checker = false;
                if(checker==false)
                    Console.WriteLine("Unesite jedan od brojeva ispred ponuđenih opcija!");
            }
            
            return input;
        }
    }
}
