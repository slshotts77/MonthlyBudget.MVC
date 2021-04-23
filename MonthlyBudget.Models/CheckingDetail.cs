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
        public Guid OwnerId { get; set; }
        public int? CategoryId { get; set; }
        [Display(Name = "Is this a monthly bill")]
        public bool MonthlyBill { get; set; }
        public int DescriptionId { get; set; }
        public string CashOrCard { get; set; }        
        public DateTime ChargeDate { get; set; }
        public DateTime DateCleared { get; set; }
        public bool Cleared { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
