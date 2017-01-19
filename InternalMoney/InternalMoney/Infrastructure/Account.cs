using InternalMoney.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternalMoney.Infrasturcture
{
    public class Account : IdentityUser
    {
        public decimal Balance { get; set; }

        public virtual ICollection<Transaction> SenderTransactions { get; set; }
        public virtual ICollection<Transaction> RecipientTransactions { get; set; }
    }
}