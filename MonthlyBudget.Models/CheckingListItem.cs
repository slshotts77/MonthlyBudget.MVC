using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CheckingListItem
    {
        public int EntryId { get; set; }
        
        public bool MonthlyBill { get; set; }

        public string Category { get; set; }
        public string UtilityComapny { get; set; }

        public string Description { get; set; }

        public string PayingBy { get; set; }

        [Display(Name = "Date of purchase")]
        public DateTime ChargeDate { get; set; }
        [Display(Name = "Date transaction cleared the bank")]
        public DateTime DateCleared { get; set; }
        [Display(Name = "Has transaction cleared the bank")]
        public bool Cleared { get; set; }
        

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
