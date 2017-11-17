using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp_project1.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
[Required]        public string CustomerName { get; set; }
    [Required]    public string CustomerPhoneno { get; set; }
    }
}
