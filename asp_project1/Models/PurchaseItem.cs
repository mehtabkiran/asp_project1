using System;
using System.Collections.Generic;

namespace asp_project1.Models
{
    public partial class PurchaseItem
    {
        public int PurchaseId { get; set; }
         public string PurchaseItemName { get; set; }
        public int PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchasingDate { get; set; }
        
    }
}
