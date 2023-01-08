using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus
{
     public static class MainMenu
     {
        public static void Create()
        {
            MenusPrint.MainMenuPrint();
            int input = MenuInput.GetInput(7);
        }
     }
}
