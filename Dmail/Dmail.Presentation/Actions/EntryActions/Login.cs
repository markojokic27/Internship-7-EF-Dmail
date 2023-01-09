using Dmail.Domain.Enums;
using Dmail.Dormain.Repositories;
using Dmail.Presentation.Menus;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Actions
{
    public  class Login
    {
        private readonly UserRepository _userRepository;
        public Login(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Create()
        {
            Console.Clear();
            Console.WriteLine("Prijava (za odustajanje unesite 0)\nUnesite adresu: ");
            string address=Console.ReadLine();
            if (address == "0")
                EntryMenu.Create();
            Console.WriteLine("Unesite lozinku:");
            string password=Console.ReadLine();
            if (password == "0")
                EntryMenu.Create();
            //NEKAKO ZAPAMTIT KORISNIKA
            if (_userRepository.SingIn(address,password)==ResponseResultType.Success)
            {
                Helpers.NewCurrentUser(address);
                Console.WriteLine("Uspjesna prijava.");
                Helpers.PressAnyButton("za odlazak na glavni izbornik.");
                MainMenu.Create();
            }
            if (_userRepository.SingIn(address, password) == ResponseResultType.NotFound)
                Console.WriteLine("Navedena adresa ne postoji medu racunima.\n");
            if (_userRepository.SingIn(address, password) == ResponseResultType.ValidationError)
                Console.WriteLine("Netocna lozinka.\n");


            Console.WriteLine("Neuspjesna prijava. Za 30 sekundi opet cete imati mogucnost prijave.");
            Thread.Sleep(30000);
            Create();
            
        }
    }
}
