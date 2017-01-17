using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace InternalMoney.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public decimal Balance { get; set; }

		private decimal startBalance = 500;
		public User() { }

		public User(IdentityUser rbm)
		{
			Name = rbm.UserName;
			Email = rbm.Email;
			Balance = startBalance;
		}
	}
}
