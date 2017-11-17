using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_project1.Models
{
    public class Purchasefinal
    {
        public int PurchaseId { get; set; }
        [Required] public string PurchaseItemName { get; set; }
        [Required] public int PurchaseQuantity { get; set; }
        [Required] public decimal PurchasePrice { get; set; }
        [Required] public DateTime PurchasingDate { get; set; }
         public int  VendorId { get; set; }
        [Required] public string VendorName { get; set; }
        [Required] public string VendorPhoneno { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemDescription { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemModel { get; set; }
        public string ItemColor { get; set; }
        public string ItemCategory { get; set; }



        





    }
}
