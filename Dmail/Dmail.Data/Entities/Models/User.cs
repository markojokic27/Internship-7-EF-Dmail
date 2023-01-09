using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities.Models
{
    public class User
    { 
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<Mail> Sented { get; set; } = new List<Mail>();
        public ICollection<Spam> Spams { get; set; } = new List<Spam>();
        public ICollection<Receiver> Recieved { get; set; } = new List<Receiver>();
        public User() { }
        public User(string email,string password)
        {
            Email = email;
            Password = password;
        }
    }
}
