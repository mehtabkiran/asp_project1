using System;
using System.Collections.Generic;

namespace asp_project1.Models
{
    public partial class PurchaseHistory
    {
        public int Sr { get; set; }
        public string VendorName { get; set; }
        public string VendorPhoneno { get; set; }
        public string PurchaseItemName { get; set; }
        public int PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
