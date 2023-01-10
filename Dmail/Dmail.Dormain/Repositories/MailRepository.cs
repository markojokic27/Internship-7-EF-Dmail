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


        public ICollection<Mail> GetSeenMails(int userId)
        {
            var mails = DbContext.Receivers.Where(r => r.UserId == userId).
                Where(r => r.MailStatus == MailStatus.Read)
                .Join(DbContext.Mails, r => r.MailId, m => m.Id, (r, m) => new { r, m }).
                Select(l => new Mail()
                {
                    Id = l.m.Id,
                    Title = l.m.Title,
                    Content = l.m.Content,
                    SentAt = l.m.SentAt,
                    Type = l.m.Type,
                    EventStart = l.m.EventStart,
                    EventDuration = l.m.EventDuration,
                    SenderId = l.m.SenderId,
                    Sender = l.m.Sender,
                    Receivers = (ICollection<Receiver>)l.m.Receivers.Where(r => r.MailId == l.m.Id).Select(c => c.UserId).ToList(),

                }).OrderByDescending(l => l.SentAt).ToList();

            foreach (var item in mails.ToList())
            {
                if (DbContext.Spam.Find(userId, item.SenderId) != null)
                    mails.Remove(item);
            }
            return mails;
        }
        public ICollection<Mail> GetUnSeenMails(int userId)
        {
            var mails = DbContext.Receivers.Where(r => r.UserId == userId).
                Where(r => r.MailStatus == MailStatus.Unread)
                .Join(DbContext.Mails, r => r.MailId, m => m.Id, (r, m) => new { r, m }).
                Select(l => new Mail()
                {
                    Id = l.m.Id,
                    Title = l.m.Title,
                    Content = l.m.Content,
                    SentAt = l.m.SentAt,
                    Type = l.m.Type,
                    EventStart = l.m.EventStart,
                    EventDuration = l.m.EventDuration,
                    SenderId = l.m.SenderId,
                    Sender = l.m.Sender,
                    Receivers = (ICollection<Receiver>)l.m.Receivers.Where(r => r.MailId == l.m.Id).Select(c => c.UserId).ToList(),

                }).OrderByDescending(l => l.SentAt).ToList();

            foreach (var item in mails.ToList())
            {
                if (DbContext.Spam.Find(userId, item.SenderId) != null)
                    mails.Remove(item);
            }
            return mails;
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
        public ICollection<Mail> GetSentMails(int id)
        {
            var mails = DbContext.Mails.Where(m => m.SenderId == id)
                    .Select(l => new Mail()
                    {
                        Id = l.Id,
                        Title = l.Title,
                        Content = l.Content,
                        SentAt = l.SentAt,
                        Type = l.Type,
                        EventStart = l.EventStart,
                        EventDuration = l.EventDuration,
                        SenderId = l.SenderId,
                        Sender = l.Sender,
                        Receivers = (ICollection<Receiver>)l.Receivers.Where(r => r.MailId == l.Id).Select(c => c.UserId).ToList(),
                    }).OrderByDescending(f => f.SentAt).ToList();
            return mails;
        }

    }
}
