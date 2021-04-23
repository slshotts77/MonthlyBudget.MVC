using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CheckingEdit
    {
        public int EntryId { get; set; }
        [Display(Name = "Is this a monthly bill")]
        public bool MonthlyBill { get; set; }
        [Required]
        [Display(Name = "Date of purchase")]
        public DateTime ChargeDate { get; set; }
        [Display(Name = "Date transaction cleared the bank")]
        public DateTime DateCleared { get; set; }
        [Display(Name = "Has transaction cleared with the bank")]
        public bool Cleared { get; set; }
    }
}
