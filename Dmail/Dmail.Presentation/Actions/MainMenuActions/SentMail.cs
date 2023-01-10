using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Dormain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Actions
{
    public class SentMail
    {
        private readonly MailRepository _mailRepository;
        private readonly UserRepository _userRepository;
        public SentMail(UserRepository userRepository, MailRepository mailRepository)
        {
            _mailRepository = mailRepository;
            _userRepository = userRepository;
        }
        public void Create()
        {
            ICollection<Mail> mails=GetSentMails(_mailRepository,_userRepository);
            foreach (Mail mail in mails)
            {
                Console.WriteLine($"{mail.Id,3} - {mail.Title,15}\nPrimatelji:");
                foreach(Receiver user in mail.Receivers)
                {
                    Console.WriteLine($"{user.User}  ");
                }
            }
        }
        public ICollection<Mail> GetSentMails(MailRepository mailRepository,UserRepository userRepository)
        {
            var mails = mailRepository.GetSentMails(userRepository.GetIdByAdress(Helpers.currentUser));
            return mails;
        }
    }
}
