using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_project1.Models
{
    public class Salefinal
    {

        public int SaleId { get; set; }
        [Required] public string SaleItemName { get; set; }
        [Required] public DateTime SaleDate { get; set; }
        [Required] public decimal SalePrice { get; set; }
        [Required] public int SaleQuantity { get; set; }
        public int CustomerId { get; set; }
        [Required] public string CustomerName { get; set; }
        [Required] public string CustomerPhoneno { get; set; }

    }
}
