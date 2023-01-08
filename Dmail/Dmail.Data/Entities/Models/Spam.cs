using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class Spam
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int BlockedUserId { get; set; }
        public User? BlockedUser { get; set; }
    }
}
