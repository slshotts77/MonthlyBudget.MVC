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

        
        [Display(Name = "Date of purchase")]
        public DateTime ChargeDate { get; set; }
        [Display(Name = "Date transaction cleared the bank")]
        public DateTime DateCleared { get; set; }
        [Display(Name = "Has transaction cleared the bank")]
        public bool Cleared { get; set; }
        [Display(Name = "Created")]

        public virtual ICollection<CheckingListItem> ListOfEntries { get; set; } = new List<CheckingListItem>();

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
