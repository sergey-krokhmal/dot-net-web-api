using InternalMoney.Infrasturcture;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalMoney.Models
{
	public class Transaction
	{
		public int Id { get; set; }

		public int Id_Sender { get; set; }

        [ForeignKey("Id_Sender")]
		public Account Sender { get; set; }

		public int Id_Receiver { get; set; }

        [ForeignKey("Id_Recipient")]
        public Account Recipient { get; set; }

		public decimal Sum { get; set; }
	}
}