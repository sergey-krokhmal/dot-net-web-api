using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace InternalMoney.Models
{
    public class User : IdentityUser
	{
		public int Id { get; set; }

		[Required]
		public string Id_Identity{ get; set; }
		[Required]
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public decimal Balance { get; set; }

		private decimal startBalance = 500;
		public User() { }

		public User(IdentityUser rbm)
		{
			Id_Identity = rbm.Id;
			Name = rbm.UserName;
			Email = rbm.Email;
			Balance = startBalance;
		}
	}
}
