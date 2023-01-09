using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Data.Enums;
using Dmail.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;

namespace Dmail.Domain.Repositories
{
    public class MailRepository : BaseRepository
    {      
        public MailRepository(DmailDBContext dbContext) : base(dbContext)
        {
        }
        public ICollection<Mail> GetAll() => DbContext.Mails.ToList();
        public ResponseResultType Add(Mail mail)
        {
            //ovu provjeru napravi u presentation layeru!!!
            if (mail.Title.Length == 0)
                return ResponseResultType.ValidationError;
            if (DbContext.Mails.Find(mail.Id) != null)
                return ResponseResultType.AlreadyExists;
            DbContext.Mails.Add(mail);
            return SaveChanges();

        }

        public ResponseResultType Delete(int mailId)
        {
            var mailToDelete = DbContext.Mails.Find(mailId);
            if (mailToDelete is null)
                return ResponseResultType.NotFound;
            DbContext.Mails.Remove(mailToDelete);
            return SaveChanges();
        }

        
        
        public int NewMail(string title,string content, MailType type, int senderId,DateTime eventStart,TimeSpan eventDuration)
        {
            var mail = new Mail()
            {
                Title = title,
                Content = content,
                Type=type,
                SenderId = senderId,
                SentAt = DateTime.Now.ToUniversalTime(),
            };
            if (type != 0) //neda koristenje 1?
            { 
                mail.EventStart = eventStart;
                mail.EventDuration = eventDuration;
            }
            var check =Add(mail);
            if (check!=ResponseResultType.Success)
            {
                Console.WriteLine("Mail uspjesno poslan");
                return -1;
            }
            return mail.Id;

        }
        public Mail? GetMail(int id) => DbContext.Mails.Find(id);
        public ICollection<Mail> GetMails() => DbContext.Mails.ToList();


    }
}
