using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp_project1.Models
{
    public partial class ShopStaff
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string Designation { get; set; }
        public string Address { get; set; }
        public decimal? Salary { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int StaffId { get; set; }
    }
}
