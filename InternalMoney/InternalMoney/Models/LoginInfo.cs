using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternalMoney.Models
{
	public class LoginInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public decimal Balance { get; set; }

		public LoginInfo(User user)
		{
			Id = user.Id;
			Name = user.Name;
			Email = user.Email;
			Balance = user.Balance;
		}
	}
}