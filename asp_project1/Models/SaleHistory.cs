using System;
using System.Collections.Generic;

namespace asp_project1.Models
{
    public partial class SaleHistory
    {
        public int Sr { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneno { get; set; }
        public string SaleItemName { get; set; }
        public int SaleQuantity { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
