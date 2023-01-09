using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;
using Dmail.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Dormain.Repositories
{
    public class SpamRepository:BaseRepository
    {
        public SpamRepository(DmailDBContext dbContext) : base(dbContext)
        {
        }
        public bool SpamExists(int userId, int blockedUserId)
        {
            return DbContext.Spam.ToList().Any(sf => sf.UserId == userId && sf.BlockedUserId == blockedUserId);
        }
        public ResponseResultType Add(Spam spam)
        {
            var user = DbContext.Users.Find(spam.UserId);
            if (user == null)
                return ResponseResultType.NotFound;
            var blockedUser = DbContext.Users.Find(spam.BlockedUserId);
            if (blockedUser == null)
                return ResponseResultType.NotFound;
            DbContext.Spam.Add(spam);
            return SaveChanges();
        }
        public ResponseResultType Delete(int blockerId, int blockedId)
        {
            var connectionToDelete = DbContext.Spam.Find(blockerId, blockedId);
            if (connectionToDelete == null)
                return ResponseResultType.NotFound;
            DbContext.Spam.Remove(connectionToDelete);
            return SaveChanges();

        }
        public ResponseResultType MakeSpam(int userId, int blockedUserId)
        {

            if (SpamExists(userId, blockedUserId))
            {
                return ResponseResultType.NoChanges;
            }

            DbContext.Spam.Add(new Spam()
            {
                UserId = userId,
                BlockedUserId = blockedUserId,
            });

            return base.SaveChanges();
        }

        public ResponseResultType RemoveSpam(int userId, int blockedUserId)
        {
            DbContext.Spam.Remove(new Spam()
            {
                UserId = userId,
                BlockedUserId = blockedUserId,
            });

            return base.SaveChanges();
        }

        public ICollection<Spam> GetAllSpamsForUser(int userId)
        {
            return DbContext.Spam.ToList()
            .Where(sf => sf.UserId == userId)
            .ToList();
        }
        public ICollection<Spam> GetSpams(int userId) => DbContext.Spam.ToList()
           .Where(sf => sf.UserId == userId)
           .ToList();
    }
}
