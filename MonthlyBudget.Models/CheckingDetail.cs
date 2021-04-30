using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CheckingDetail
    {
        public int EntryId { get; set; }
        [Display(Name = "Is this a monthly bill")]
        public bool MonthlyBill { get; set; }
        public string Category { get; set; }   // public int? CategoryId { get; set; }
        public string UtilityComapny { get; set; }   // public int? UtilityComapnyId { get; set; }

        public string Description { get; set; }   // public List<CheckingListItem> Entries { get; set; }

        public string PayingBy { get; set; }   // public int? PayingById { get; set; }
        [Display(Name = "Date of purchase")]
        
        public DateTime ChargeDate { get; set; }
        [Display(Name = "Date transaction cleared the bank")]
        public DateTime DateCleared { get; set; }
        public bool Cleared { get; set; }

        public virtual ICollection<CheckingListItem> ListOfEntries { get; set; } = new List<CheckingListItem>();

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
