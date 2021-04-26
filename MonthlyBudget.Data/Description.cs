using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Data
{
    public class Description
    {
        [Key]
        public int? DescriptionId { get; set; }
        [Required]
        public string DescriptionName { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Description> Descriptions { get; set; } = new List<Description>();

        public virtual List<Category> ListOfCategories { get; set; } = new List<Category>();

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
