using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Dormain.Repositories;
using Dmail.Presentation.Menus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Actions
{
    public  class IncomingMail
    {
        private readonly MailRepository _mailRepository;
        private readonly UserRepository _userRepository;
        public IncomingMail(UserRepository userRepository,MailRepository mailRepository)
        {
            _mailRepository= mailRepository;
            _userRepository= userRepository;
        }
        public void Create()
        {
            MenusPrint.IncomingMailMenuPrint();
            int input = MenuInput.GetInput(4);
            switch (input) {
                case 1:
                    GetMails(_userRepository, _mailRepository, "Procitane");
                    break;
                case 2:
                    GetMails(_userRepository, _mailRepository, "Neprocitane");
                    break;
                case 3:
                    break;
                case 4:
                    MainMenu.Create();
                    break;
            }
            if (input is 1 || input is 2)
            {
                MenusPrint.IncomingMailMenuPrint2();
                int input2 = MenuInput.GetInput(3);
                switch (input2)
                {
                    case 1:
                        Console.WriteLine("\nUnesite broj isped maila kojeg zelite vise istraziti:");
                        var id = int.Parse(Console.ReadLine());
                        GetMailDetail(_mailRepository, id);
                        break;
                    case 2:
                        Console.WriteLine("Trazilica: ");
                        var a = Console.ReadLine();
                        ICollection<User> users = _userRepository.Search(a);
                        foreach (User user in users)
                            Console.WriteLine($"{user.Email}\n");
                        Helpers.PressAnyButton("za povratak na glavni izbornik.");
                        MainMenu.Create();
                        break;
                    case 3:
                        Create();
                        break;
                }

            }

        }

        private static void GetMails(UserRepository userRepository, MailRepository mailRepository, string type)
        {
            int i = userRepository.GetIdByAdress(Helpers.currentUser);
            ICollection<Mail> mails = null;
            if (type == "Procitane")
                mails = mailRepository.GetSeenMails(i);
            else
                mails = mailRepository.GetUnSeenMails(i);
            Console.Clear();
            if (mails.Count == 0)
            {
                Console.WriteLine("Nema poruka.");
                return;
            }
            Console.WriteLine($"{type} poruke\n Id         Naslov      Posiljatelj");
            foreach (Mail mail in mails)
            {
                Console.WriteLine($"{mail.Id,3} - {mail.Title,15} - {mail.Sender,15}");
            }
        }
        private static void GetMailDetail(MailRepository mailRepository,int id)
        {
            Mail mail = mailRepository.GetMail(id);
            if (mail.Type == Data.Enums.MailType.Email)
            {
                Console.Clear();
                Console.WriteLine($"Odabrani dogadaj:\n{mail.Title}\n{mail.SentAt}\n{mail.Sender}\n{mail.Content}");
                Helpers.PressAnyButton("za povratak na glavni izbornik.");
                MainMenu.Create();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Odabrani dogadaj:\n{mail.Title}\n{mail.SentAt}\n{mail.Sender}\n");
                Helpers.PressAnyButton("za povratak na glavni izbornik.");
                MainMenu.Create();
            }
        }
    }
}
