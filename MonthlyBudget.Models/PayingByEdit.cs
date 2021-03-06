using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class PayingByEdit
    {
        public string CashOrCard { get; set; }
        [Display(Name = "Paid with cash, enter that amount")]
        public decimal CashAmount { get; set; }
        [Display(Name = "Example would be Debit or Credit Card-(last 4 of card")]
        public string CardType { get; set; }
        public decimal CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string ExpirationDate { get; set; }
        [Display(Name = "3 digit code on the back of the card")]
        public int SecurityCode { get; set; }
    }
}