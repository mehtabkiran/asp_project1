using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_project1.Models
{
    public class Categorydropdown
    {
        public int CategoryId { set; get; }
    public SelectList CategoryList { set; get; }

    }
}
