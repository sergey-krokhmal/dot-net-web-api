using System.ComponentModel.DataAnnotations;

namespace InternalMoney.Models
{
	public class Transaction
	{
		public int Id { get; set; }

		[Required]
		public int Id_Sender { get; set; }

		public User Sender { get; set; }

		[Required]
		public int Id_Receiver { get; set; }

		public User Receiver { get; set; }

		[Required]
		public decimal Money { get; set; }
	}
}