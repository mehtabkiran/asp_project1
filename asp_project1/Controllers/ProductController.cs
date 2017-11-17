using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_project1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_project1.Controllers
{
    public class ProductController : Controller
    {
        asp_proj1Context mydbcontext = null;
        public ProductController(asp_proj1Context _mydbContext)
        {
            mydbcontext = _mydbContext;
        }

        public string getitemcount()
        {
            int itemcount = mydbcontext.Item.ToList<Item>().Count();
            
            return "<p class='label label-success'>"+"Total items: " + itemcount + "</p> ";
        }
        [HttpGet]
        public IActionResult addproduct()
        {
            List<Category> cat = new List<Category>();
            cat = (from prod in mydbcontext.Category select prod).ToList();
            cat.Insert(0, new Category {  CategoryName = "Select Category", CategoryType = "Select Category" });
            ViewBag.listitem = cat;

            return View();


}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addproduct(Item I)
        {
            if(I.ItemCategory == null )
            {
                ModelState.AddModelError("", "Select category");
            }

            string selectvalue = I.ItemCategory;
            ViewBag.SelectedValue = I.ItemCategory;

            List<Category> cat = new List<Category>();
            cat = (from prod in mydbcontext.Category select prod).ToList();
            cat.Insert(0, new Category {  CategoryName = "Select Category", CategoryType = "Select Category" });
            ViewBag.listitem = cat;
            mydbcontext.Item.Add(I);
                    mydbcontext.SaveChanges();
                    ViewBag.Message = I.ItemName + " " + "is successfully added.";
         

                return View();

        }
        public IActionResult viewallproduct()
        {
            IList<Item> II = mydbcontext.Item.ToList<Item>();
            return View(II);
        }
        public IActionResult detail(Item I)
        {
            Item II = mydbcontext.Item.Where(m => m.ItemId == I.ItemId).FirstOrDefault<Item>();
            return View(II);
        }



        public IActionResult delete(Item I)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
            {
                try
                {
                    mydbcontext.Item.Remove(I);

                    mydbcontext.SaveChanges();
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                }
            }
          
            return RedirectToAction(nameof(ProductController.viewallproduct));
        }
        [HttpGet]
        public IActionResult edit(int ItemId)
        {
            Item I = mydbcontext.Item.Where(m => m.ItemId == ItemId).FirstOrDefault<Item>();
            return View(I);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit(Item I)
        {
            mydbcontext.Item.Attach(I);
            Item II = mydbcontext.Item.Where(m => m.ItemId == I.ItemId).FirstOrDefault<Item>();
            var entry = mydbcontext.Entry(II);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            mydbcontext.SaveChanges();
            return RedirectToAction(nameof(ProductController.viewallproduct));

        }




    }
}