using Dmail.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime SentAt { get; set; }
        public MailType Type { get; set; }
        public DateTime? EventStart { get; set; }
        public TimeSpan? EventDuration { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; } = null!;
        public ICollection<Receiver> Receivers { get; set; } = new List<Receiver>();
    }
}
