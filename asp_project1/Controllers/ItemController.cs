using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_project1.Models;

namespace asp_project1.Controllers
{
    public class ItemController : Controller
    {
        asp_proj1Context mydbcontext = null;
        public ItemController(asp_proj1Context _mydbContext)
        {
            mydbcontext = _mydbContext;
        }

        public string getcatcount()
        {
            int catcount = mydbcontext.Category.ToList<Category>().Count();
            
            return "<p class='label label-success'>" +"  Categories: " +catcount + "</p> "; 
        }
        [HttpGet]
        public IActionResult addcategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addcategory(Category C)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
                try
                {
                    mydbcontext.Category.Add(C);
                    mydbcontext.SaveChanges();
                    ViewBag.Message = C.CategoryName + " " + "is successfully added.";
                    t.Commit();
                }
                catch (Exception e)
                { t.Rollback(); }                    return View();

                }
        public IActionResult viewallcategory()
        {
            IList<Category> CC = mydbcontext.Category.ToList<Category>();
            return View(CC);
        }

        public IActionResult viewallcategoryU()
        {
            IList<Category> CC = mydbcontext.Category.ToList<Category>();
            return View(CC);
        }
        public IActionResult detail(Category C)
        {
            Category CC = mydbcontext.Category.Where(m => m.CategoryId == C.CategoryId).FirstOrDefault<Category>();
            return View(CC);
        }
        public IActionResult detailU(Category C)
        {
            Category CC = mydbcontext.Category.Where(m => m.CategoryId == C.CategoryId).FirstOrDefault<Category>();
            return View(CC);
        }

        public IActionResult delete(Category C)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
            {
                try
                {
                    mydbcontext.Category.Remove(C);

                    mydbcontext.SaveChanges();
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                }
            }

            return RedirectToAction(nameof(ItemController.viewallcategory));
        }
        [HttpGet]
        public IActionResult edit(int CategoryId)
        {
            Category C = mydbcontext.Category.Where(m => m.CategoryId == CategoryId).FirstOrDefault<Category>();
            return View(C);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit(Category C)
        {
            mydbcontext.Category.Attach(C);
           Category CC= mydbcontext.Category.Where(m => m.CategoryId == C.CategoryId).FirstOrDefault<Category>();
            var entry = mydbcontext.Entry(CC);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            mydbcontext.SaveChanges();
            return RedirectToAction(nameof(ItemController.viewallcategory));

        }




    }
}