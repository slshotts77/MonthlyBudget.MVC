using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Data
{
    public class UtilityCompany
    {
        [Key]
        public int UtilityCompanyId { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        [Display(Name = "Utility Company Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Example www.website.com")]
        public string Website { get; set; }
        [Required]
        public string UserLogin { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        [Display(Name = "Enter phone number as shown (123) 555-1234")]
        public string PhoneNumber { get; set; }
       
        [ForeignKey(nameof(PayingBy))]
        public int PayingById { get; set; }
        public virtual PayingBy PayingBy { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
