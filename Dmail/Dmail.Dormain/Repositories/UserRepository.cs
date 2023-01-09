using Dmail.Data.Entities.Models;
using Dmail.Data.Entities;
using Dmail.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dmail.Domain.Enums;

namespace Dmail.Dormain.Repositories
{
    public class UserRepository:BaseRepository
    {
        public UserRepository(DmailDBContext dbContext) : base(dbContext)
        {
        }
        public ResponseResultType AddUser(User user)
        {
            DbContext.Users.Add(user);
            return SaveChanges();
        }

        public ResponseResultType SingIn(string address, string password)
        {
            User? user = DbContext.Users.FirstOrDefault(u => u.Email == address);

            if (user == null)
                return ResponseResultType.NotFound;
            if (password!=user.Password)
                return ResponseResultType.ValidationError;
            return ResponseResultType.Success;
        }
        public ICollection<User> Search(string a)
        {
            return DbContext.Users.ToList()
            .Where(u => u.Email.Contains(a))
            .ToList();
        }
        public bool AddressExists(string address)
        {
            return DbContext.Users.ToList().Any(u => u.Email == address);
        }


    }
}
