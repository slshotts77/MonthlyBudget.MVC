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
        public int? CategoryId { get; set; }        
        public bool MonthlyBill { get; set; }
        public int? UtilityComapnyId { get; set; }
        
        public List<CheckingListItem> Entries { get; set; }
        
        public int? PayingById { get; set; }
        [Display(Name = "Date of purchase")]
        
        public DateTime ChargeDate { get; set; }
        [Display(Name = "Date transaction cleared the bank")]
        public DateTime DateCleared { get; set; }
        public bool Cleared { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
