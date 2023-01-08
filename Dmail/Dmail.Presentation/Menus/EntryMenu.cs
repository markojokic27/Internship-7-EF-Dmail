using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dmail.Presentation.Menus;
namespace Dmail.Presentation.Menus
{
    public static class EntryMenu
    {
        public static void Create() 
        {
            MenusPrint.EntryMenuPrint();
            int input=MenuInput.GetInput(3);
            switch (input)
            {
                case 1:

                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }    
}
