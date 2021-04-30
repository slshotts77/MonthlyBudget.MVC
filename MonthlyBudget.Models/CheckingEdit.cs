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
        public int CheckingId { get; set;  }
        [Display(Name = "Is this a monthly bill")]
        public bool MonthlyBill { get; set; }
        public int CategoryId { get; set; }
        public int UtilityCompanyId { get; set; }
        public int DescriptionId { get; set; }
        public int PayingById { get; set; }
        [Display(Name = "Date of purchase")]
        public DateTime ChargeDate { get; set; }        
        [Display(Name = "Date transaction cleared the bank")]
        public DateTime DateCleared { get; set; }        
        [Display(Name = "Has transaction cleared with the bank")]
        public bool Cleared { get; set; }
    }
}
