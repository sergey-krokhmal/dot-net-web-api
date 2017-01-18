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
        public InternalMoneyContext() : base("name=InternalMoneyContext")
        {
        }

		public System.Data.Entity.DbSet<InternalMoney.Models.User> Users { get; set; }

		public System.Data.Entity.DbSet<InternalMoney.Models.Transaction> Transactions { get; set; }
    
    }
}
