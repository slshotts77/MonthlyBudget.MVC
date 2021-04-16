using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Data
{
    public class CheckingAccountEntries
    {
        [Key]
        public int EntryId { get; set; }
        
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Is this a monthly bill")]
        public bool MonthlyBill { get; set; }       

        [ForeignKey(nameof(Description))]
        public int DescriptionId { get; set; }
        public virtual Description Description { get; set; }

        [ForeignKey(nameof(PayingBy))]
        public int PayingById { get; set; }
        public virtual PayingBy PayingBy { get; set; }

        [Required]
        [Display(Name = "Date of purchase")]
        public DateTime ChargeDate { get; set; }
        [Display(Name = "Date transaction cleared the bank")]
        public DateTime DateCleared { get; set; }
        [Display(Name = "Has transaction cleared with the bank")]
        public bool Cleared { get; set; }
        
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}