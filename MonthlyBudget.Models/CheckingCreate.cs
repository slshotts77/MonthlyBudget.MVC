using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CheckingCreate
    {        
        public int? CategoryId { get; set; }
        public bool MonthlyBill { get; set; }
        public int? DescriptionId { get; set; }
        public int? PayingById { get; set; }
        public DateTime ChargeDate { get; set; }
        public DateTime DateCleared { get; set; }
        public bool Cleared { get; set; }       
    }
}
