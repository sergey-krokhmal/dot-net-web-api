using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InternalMoney.Models
{
    public class InternalMoneyContext : IdentityDbContext
    {

        public DbSet<Transaction> Transactions { get; set; }

        public InternalMoneyContext()
            : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static InternalMoneyContext Create()
        {
            return new InternalMoneyContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                        .HasRequired(m => m.Sender)
                        .WithMany(t => t.SenderTransactions)
                        .HasForeignKey(m => m.Id_Sender)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                        .HasRequired(m => m.Recipient)
                        .WithMany(t => t.RecipientTransactions)
                        .HasForeignKey(m => m.Recipient)
                        .WillCascadeOnDelete(false);
        }
    }
}
