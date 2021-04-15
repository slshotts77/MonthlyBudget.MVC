﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Data
{
    public class PayingBy
    {
        [Key]
        public int PayById { get; set; }
        public decimal CashAmount { get; set; }
        public string CardType { get; set; }
        public decimal CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}