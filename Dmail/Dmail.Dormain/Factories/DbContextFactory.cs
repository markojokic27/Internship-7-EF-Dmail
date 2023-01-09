using Dmail.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Dormain.Factories
{
    public static class DbContextFactory
    {
        public static DmailDBContext GetDmailDBContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["Dmail"].ConnectionString)
                .Options;

            return new DmailDBContext(options);
        }
    }
}
