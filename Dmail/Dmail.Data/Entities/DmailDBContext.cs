using Dmail.Data.Entities.Models;
using Dmail.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Entities
{
    public class DmailDBContext : DbContext
    {
        public DmailDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Mail> Mails => Set<Mail>();
        public DbSet<Receiver> Receivers => Set<Receiver>();
        public DbSet<Spam> Spam => Set<Spam>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //vamo je zapelo...uvik bude neki error zbog kojeg ne mogu izvrsiti ni migraciju ni update baze :(
            modelBuilder.Entity<Mail>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.Sented)
                .HasForeignKey(u=>u.SenderId);
            modelBuilder.Entity<Spam>()
                .HasKey(s => new { s.UserId, s.BlockedUserId });
            //modelBuilder.Entity<Receiver>()
            //    .HasOne(r => r.MailId)
            //    .WithMany(m => m.Id);
            modelBuilder.Entity<Receiver>()
                .HasKey(r => new { r.MailId, r.UserId });





            DatabaseSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        public class DmailDbContextFactory : IDesignTimeDbContextFactory<DmailDBContext>
        {
            public DmailDBContext CreateDbContext(string[] args)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddXmlFile("App.config")
                    .Build();

                config.Providers
                    .First()
                    .TryGet("connectionStrings:add:Dmail:connectionString", out var connectionString);

                var options = new DbContextOptionsBuilder<DmailDBContext>()
                    .UseNpgsql(connectionString)
                    .Options;

                return new DmailDBContext(options);
            }
        }

    }
}