using MonthlyBudget.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CategoryDetail
    {
        public int? CategoryId { get; set; }
        [Display(Name = "Type of expense")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(25, ErrorMessage = "Enter shorter name.")]
        public string CategoryName { get; set; }
       
        public List<DescriptionListItem> Descriptions { get; set; }
    }
}
