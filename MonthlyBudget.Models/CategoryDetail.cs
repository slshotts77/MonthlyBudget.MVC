using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CategoryDetail
    {
        public int? CategoryId { get; set; }
        [Display(Name = "Example would be Food, Gas, Water, Groceries, etc...")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(15)]
        public string CategoryName { get; set; }

        public virtual List<string> Description { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
