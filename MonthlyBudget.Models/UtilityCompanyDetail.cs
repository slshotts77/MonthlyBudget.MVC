using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class UtilityCompanyDetail
    {        
        public int UtilityCompanyId { get; set; }
        public int CategoryId { get; set; }
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
        public int PayingById { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
