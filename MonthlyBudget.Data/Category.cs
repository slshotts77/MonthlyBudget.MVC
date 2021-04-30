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
        public Guid OwnerId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
