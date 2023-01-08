using Dmail.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class Receiver
    {
        public int MailId { get; set; }
        public Mail? Mail { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public MailStatus MailStatus { get; set; }
        public EventResponse EventResponse { get; set; }
    }
}
