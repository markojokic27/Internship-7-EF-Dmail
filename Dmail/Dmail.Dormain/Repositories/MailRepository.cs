using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Data.Enums;
using Dmail.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Dmail.Domain.Repositories
{
    public class MailRepository : BaseRepository
    {
        public Mail? GetMail(int id) => DbContext.Mails.Find(id);
        public ICollection<Mail> GetMessages() => DbContext.Mails.ToList();

        public MailRepository(DmailDBContext dbContext) : base(dbContext)
        {

        }
        public ResponseResultType Add(Mail mail)
        {
            if (mail.Title.Length == 0)
                return ResponseResultType.ValidationError;
            if (DbContext.Mails.Find(mail.Id) != null)
                return ResponseResultType.AlreadyExists;
            DbContext.Mails.Add(mail);
            return SaveChanges();

        }

        public ResponseResultType Delete(int message)
        {
            var mailToDelete = DbContext.Mails.Find(message);
            if (mailToDelete == null)
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
            if (type!=0) 
            { 
                mail.EventStart = eventStart;
                mail.EventDuration = eventDuration;
            }
            var check =Add(mail);
            if (check!=ResponseResultType.Success)
            {
                Console.WriteLine(check.ToString());
                return -1;
            }
            return mail.Id;

        }
        

    }
}
