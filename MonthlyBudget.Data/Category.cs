using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Data
{
    public class Category
    {
        [Key]
        public int? CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        [ForeignKey("Description")]
        public int? DescriptionId { get; set; }
        public virtual Description Description { get; set; }

        public virtual List<Category> ListOfCategories { get; set; } = new List<Category>();

        public virtual List<Description> ListOfDescriptions { get; set; } = new List<Description>();
        
        public virtual List<Description> ListOfUtilityCompanies { get; set; } = new List<Description>();

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
