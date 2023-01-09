using Dmail.Data.Entities;
using Dmail.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dmail.Data.Entities.DmailDBContext;

namespace Dmail.Dormain.Factories
{
    public static class RepositoryFactory
    {
        public static TRepository Create<TRepository>()
        where TRepository : BaseRepository
        {
            var dbContext = DbContextFactory.GetDmailDBContext();
            var repositoryInstance = Activator.CreateInstance(typeof(TRepository), dbContext) as TRepository;
            return repositoryInstance!;
        }
    }
}
