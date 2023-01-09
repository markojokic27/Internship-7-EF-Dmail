using Dmail.Presentation.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Actions
{
    public static class Login
    {
        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("Prijava\nUnesite adresu: ");
            string address=Console.ReadLine();
            Console.WriteLine("Unesite lozinku:");
            string password=Console.ReadLine();
            //VAMO DODAT PROVJERU I NEKAKO ZAPAMTIT KORISNIKA
            if(true)
            {
                Console.WriteLine("Uspjesna prijava.");
                Helpers.PressAnyButton("za odlazak na glavni izbornik.");
                MainMenu.Create();
            }
        }
    }
}
