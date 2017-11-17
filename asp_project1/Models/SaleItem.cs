using System;
using System.Collections.Generic;

namespace asp_project1.Models
{
    public partial class SaleItem
    {
        public int SaleId { get; set; }
        public string SaleItemName { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public int SaleQuantity { get; set; }
    }
}
