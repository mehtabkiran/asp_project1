using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp_project1.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
[Required]        public string ItemName { get; set; }
 [Required]       public decimal ItemPrice { get; set; }
        [Required] public string ItemDescription { get; set; }
        [Required] public int ItemQuantity { get; set; }
        [Required] public string ItemModel { get; set; }
        [Required] public string ItemColor { get; set; }
        [Required] public string ItemCategory { get; set; }
    }
}
