using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Data
{
    public class Checking
    {
        [Key]
        public int EntryId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
               
        public bool MonthlyBill { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("UtilityCompany")]
        public int UtilityCompanyId { get; set; }
        public virtual UtilityCompany UtilityCompany { get; set; }

        [ForeignKey("Description")]
        public int DescriptionId { get; set; }
        public virtual Description Description { get; set; }

        [ForeignKey("PayingBy")]
        public int PayingById { get; set; }
        public virtual PayingBy PayingBy { get; set; }

        public virtual ICollection<Checking> ListOfEntries { get; set; } = new List<Checking>();

        [Required]
        public DateTime ChargeDate { get; set; }
        public DateTime DateCleared { get; set; }
        public bool Cleared { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
