using Dmail.Data.Entities.Models;
using Dmail.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Seeds
{
    public class DatabaseSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                   .HasData(new List<User>
                   {
                    new User
                    {
                        Id = 1,
                        Email = "ante@gmail.com",
                        Password="ante"
                    },
                    new User
                    {
                        Id = 2,
                        Email = "ivan@gmail.com",
                        Password="ivan"
                    },
                    new User
                    {
                        Id = 3,
                        Email = "marko@gmail.com",
                        Password="marko"
                    },
                    new User
                    {
                        Id = 4,
                        Email = "ana@gmail.com",
                        Password="ana"
                    },
                    new User
                    {
                        Id = 5,
                        Email = "ana@gmail.com",
                        Password="ana"
                    },
                    new User
                    {
                        Id = 6,
                        Email = "ivana@gmail.com",
                        Password="ivana"
                    },

                   });
            builder.Entity<Mail>()
                .HasData(new List<Mail>
                {
                    new Mail
                    {
                        Id = 1,
                        Title = "Upit",
                        Content = "Pozdrav, radi li sutra knjiznica?",
                        SentAt = new DateTime(2022, 12, 1, 15, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Email,
                        SenderId = 1
                    },
                    new Mail
                    {
                        Id = 2,
                        Title = "Kava",
                        Content = "Kad cemo na kavu?",
                        SentAt = new DateTime(2022, 11, 2, 20, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Email,
                        SenderId = 1
                    },
                    new Mail
                    {
                        Id = 3,
                        Title = "Kino",
                        Content = "Kupio sam karte za oanj film o kojem smo pricali.",
                        SentAt = new DateTime(2023, 1, 3, 15, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Email,
                        SenderId = 2
                    },
                    new Mail
                    {
                        Id = 4,
                        Title = "Cestitka",
                        Content = "Sretan Bozic!!!",
                        SentAt = new DateTime(2022, 12, 25, 7, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Email,
                        SenderId = 2
                    },
                    new Mail
                    {
                        Id = 5,
                        Title = "Dokumentacija",
                        Content = "U privitku ti saljem dokumentaciju?",
                        SentAt = new DateTime(2022, 12, 21, 15, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Email,
                        SenderId = 3
                    },
                    new Mail
                    {
                        Id = 6,
                        Title = "Planinrenje",
                        SentAt = new DateTime(2022, 12, 1, 3, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Event,
                        SenderId = 4,
                        EventStart = new DateTime(2023, 2, 1, 5, 0, 0, DateTimeKind.Utc),
                        EventDuration = TimeSpan.FromHours(4)
                    },
                    new Mail
                    {
                        Id = 7,
                        Title = "Predavanje",
                        SentAt = new DateTime(2022, 12, 1, 2, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Event,
                        SenderId = 5,
                        EventStart = new DateTime(2023, 1, 13, 12, 0, 0, DateTimeKind.Utc),
                        EventDuration = TimeSpan.FromHours(3)
                    },
                    new Mail
                    {
                        Id = 8,
                        Title = "Nogometni termin",
                        SentAt = new DateTime(2022, 12, 1, 2, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Event,
                        SenderId = 1,
                        EventStart = new DateTime(2023, 2, 1, 12, 0, 0, DateTimeKind.Utc),
                        EventDuration = TimeSpan.FromHours(2)
                    },
                    new Mail
                    {
                        Id = 9,
                        Title = "Docek Nove godine",
                        SentAt = new DateTime(2022, 12, 10, 2, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Event,
                        SenderId = 6,
                        EventStart = new DateTime(2022,12, 23, 20,0, 0, DateTimeKind.Utc),
                        EventDuration = TimeSpan.FromHours(8)
                    },
                    new Mail
                    {
                        Id = 10,
                        Title = "Team Building",
                        SentAt = new DateTime(2023, 1, 5, 2, 0, 0, DateTimeKind.Utc),
                        Type = MailType.Event,
                        SenderId = 4,
                        EventStart = new DateTime(2023, 1, 18, 17,0, 0, DateTimeKind.Utc),
                        EventDuration = TimeSpan.FromHours(4)
                    }
                });

            builder.Entity<Spam>()
               .HasData(new List<Spam>
                    {
                    new Spam()
                    {
                        UserId=1,
                        BlockedUserId=2
                    },
                    new Spam()
                    {
                        UserId=1,
                        BlockedUserId=3
                    },
                    new Spam()
                    {
                        UserId=2,
                        BlockedUserId=3
                    },
                    new Spam()
                    {
                        UserId=3,
                        BlockedUserId=4
                    },
                    new Spam()
                    {
                        UserId=5,
                        BlockedUserId=6
                    },
                    });
            builder.Entity<Receiver>()
               .HasData(new List<Receiver>
                    {
                    new Receiver()
                    {
                        MailId=1,
                        UserId=4,
                        MailStatus=MailStatus.Unread
                    },
                    new Receiver()
                    {
                        MailId=2,
                        UserId=5,
                        MailStatus=MailStatus.Unread
                    },
                    new Receiver()
                    {
                        MailId=2,
                        UserId=6,
                        MailStatus=MailStatus.Read
                    },
                    new Receiver()
                    {
                        MailId=3,
                        UserId=1,
                        MailStatus=MailStatus.Unread
                    },
                    new Receiver()
                    {
                        MailId=3,
                        UserId=6,
                        MailStatus=MailStatus.Unread
                    },
                    new Receiver()
                    {
                        MailId=4,
                        UserId=1,
                        MailStatus=MailStatus.Read
                    },
                    new Receiver()
                    {
                        MailId=4,
                        UserId=6,
                        MailStatus=MailStatus.Unread
                    },
                    new Receiver()
                    {
                        MailId=4,
                        UserId=5,
                        MailStatus=MailStatus.Unread
                    },
                    new Receiver()
                    {
                        MailId=5,
                        UserId=1,
                        MailStatus=MailStatus.Unread
                    },
                    new Receiver()
                    {
                        MailId=5,
                        UserId=5,
                        MailStatus=MailStatus.Unread
                    },
                    new Receiver()
                    {
                        MailId=5,
                        UserId=2,
                        MailStatus=MailStatus.Unread
                    },
                    new Receiver()
                    {
                        MailId=6,
                        UserId=2,
                        EventResponse=EventResponse.None
                    },
                    new Receiver()
                    {
                        MailId=6,
                        UserId=3,
                        EventResponse=EventResponse.Rejected
                    },
                    new Receiver()
                    {
                        MailId=7,
                        UserId=1,
                        EventResponse=EventResponse.Accepted
                    },
                    new Receiver()
                    {
                        MailId=7,
                        UserId=4,
                        EventResponse=EventResponse.None
                    },
                    new Receiver()
                    {
                        MailId=8,
                        UserId=4,
                        EventResponse=EventResponse.Rejected
                    },
                    new Receiver()
                    {
                        MailId=8,
                        UserId=5,
                        EventResponse=EventResponse.Rejected
                    },
                    new Receiver()
                    {
                        MailId=8,
                        UserId=2,
                        EventResponse=EventResponse.Accepted
                    },
                    new Receiver()
                    {
                        MailId=9,
                        UserId=5,
                        EventResponse=EventResponse.None
                    },
                    new Receiver()
                    {
                        MailId=9,
                        UserId=3,
                        EventResponse=EventResponse.Rejected
                    },
                    new Receiver()
                    {
                        MailId=9,
                        UserId=2,
                        EventResponse=EventResponse.Accepted
                    },
                    new Receiver()
                    {
                        MailId=10,
                        UserId=3,
                        EventResponse=EventResponse.None
                    },
                    new Receiver()
                    {
                        MailId=10,
                        UserId=2,
                        EventResponse=EventResponse.Rejected
                    },
                    new Receiver()
                    {
                        MailId=10,
                        UserId=6,
                        EventResponse=EventResponse.None
                    },
                    });
        }
    }
}
