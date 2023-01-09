using Dmail.Data.Entities.Models;
using Dmail.Dormain.Repositories;
using Dmail.Presentation.Menus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Actions
{
    public class Registration
    {
        private readonly UserRepository _userRepository;
        public Registration(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public  void Create()
        {
            string result = RegistrationProcess();
            switch (result)
            {
                //problem trpanja na stog?
                case "izlaz":
                    EntryMenu.Create();
                    break;
                case "kriviFormat":
                    Console.WriteLine("Unjeli ste krivi format adrese.\n");
                    Helpers.PressAnyButton("za ponovni pokusaj.");
                    Create();
                    break;
                case "krivaPotvrdnaLozinka":
                    Console.WriteLine("Lozinke se ne podudaraju.\n");
                    Helpers.PressAnyButton("za ponovni pokusaj.");
                    Create();
                    break;
                case "captchaFailed":
                    Console.WriteLine("Rijeci se ne podudaraju.\n");
                    Helpers.PressAnyButton("za ponovni pokusaj.");
                    Create();
                    break;
                case "sifra":
                    Console.WriteLine("Sifra mora ima ti više od 0 znakova.\n");
                    Helpers.PressAnyButton("za ponovni pokusaj.");
                    Create();
                    break;
                case "adresa":
                    Console.WriteLine("Vec postoji racun sa tom adresom.");
                    Helpers.PressAnyButton("za ponovni pokusaj.");
                    break;
                case "registriran":                   
                    //_userRepository.AddUser();
                    Console.WriteLine("Novi korisnicki racun uspjesno napravljen.");
                    Helpers.PressAnyButton("za odlazak na glavni izbornik.");               
                    MainMenu.Create();  
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        public string RegistrationProcess()
        {
            Console.Clear();

            //Unos adrese
            Console.WriteLine("Registracija (za odustajanje unesite 0)\nUnesite adresu: ");
            string address=Console.ReadLine();
            address = address.Replace(" ", "");

            if (address == "0")
                return "izlaz";
            if (!AddressFormatChecker(address))
                return "kriviFormat";
            //triba napravit provjeru unikatnosti adrese


            //unos lozinke
            Console.WriteLine("Unesite lozinku: ");
            string password = Console.ReadLine();
            password = password.Replace(" ", "");
            if (password == "0")
                return "izlaz";
            if (password == null)
                return "sifra";
            Console.WriteLine("Potvrdite lozinku: ");
            string password2=Console.ReadLine();
            if(password == "0")
                return "izlaz";
            if (password != password2)
                return "krivaPotvrdnaLozinka";

            //provjera robota
            if (!Captcha())
                return "captchaFailed";


            if (!_userRepository.AddressExists(address))
                return "adresa";
            var user = new User(address,password);
            Helpers.NewCurrentUser(address);
            _userRepository.AddUser(user);
            return "registriran";
        }

        public static bool AddressFormatChecker(string address) 
        {
            if (address == null) 
                return false;
            //if (!address.Contains('@') || !address.Contains('.'))
            //    return false;
            String news = address.Replace("@", "");
            if (news.Length != address.Length - 1)
                return false;
            if (address[0]=='@')
                return false;
            news = address.Replace(".", "");
            if (news.Length != address.Length - 1)
                return false;
            if (address[0] == '@')
                return false;
            int i = 0;
            int j = 0;
            while (address[i] != '@')
            {
                if (address[i] == '.')
                    return false;
                i++;
            }
                
            while (address[i] != '.')
            {
                i++;
                j++;
            }
            if(j<3)
                return false;
            if(address.Length-i<3) 
                return false;       
            return true;
        }
        public static bool Captcha()
        {
            string validChars = "0123456789ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random(); 
            char[] chars = new char[6];
            for (int i = 0; i < 6; i++)
                chars[i] = validChars[random.Next(0, validChars.Length)];  
            string captcha=new string(chars);
            Console.WriteLine($"Prepisite sljedecu rijec:"+captcha);
            string attempt = Console.ReadLine();
            if (captcha != attempt)
                    return false;
            return true;
        }
    }
}
