using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class DescriptionListItem
    {        
        public int? DescriptionId { get; set; }
        [Display(Name = "Description of purchase")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(15)]
        public string DescriptionName { get; set; }
    }
}
