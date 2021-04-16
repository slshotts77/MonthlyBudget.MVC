using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CategoryCreate
    {
        [Display(Name = "Example would be Food, Gas, Water, Groceries, etc...")]
        public string CategoryName { get; set; }
    }
}
