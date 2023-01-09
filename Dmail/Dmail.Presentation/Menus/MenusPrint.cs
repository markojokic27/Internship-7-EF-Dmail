using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus
{
    public static class MenusPrint
    {
        public static void EntryMenuPrint()
        {
            Console.Clear();
            Console.WriteLine("1. Prijava\n2. Registracija\n3. Izlaz");
        }
        public static void MainMenuPrint() 
        {
            Console.Clear();
            Console.WriteLine("Glavni izbornik\n" +
                "1. Ulazna posta\n" + 
                "2. Izlazna posta\n" + 
                "3. Spam\n" + 
                "4. Posalji novi mail\n" + 
                "5. Posalji novi dogadaj\n" +
                "6. Postavke profila\n" +
                "7. Odjava\n");
        }
        public static void IncomingMailMenuPrint()
        {
            Console.Clear();
            Console.WriteLine("Ulazna posta\n" +
                "1. Procitana posta\n" +
                "2. Neprocitana posta\n" +
                "3. Posta odredenog posiljatelja\n" +
                "4. Povratak na glavni izbornik\n" 
                );
        }
    }
}
