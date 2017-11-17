using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_project1.Models;

namespace asp_project1.Controllers
{
    public class SaleflowController : Controller
    {
        asp_proj1Context mydbcontext = null;
        public SaleflowController(asp_proj1Context _mydbContext)
        {
            mydbcontext = _mydbContext;
        }
        public string getsicount()
        {
            int sicount = mydbcontext.SaleItem.ToList<SaleItem>().Count();
            return "<p class='label label-success'>" + "Total sold items: " + sicount + "</p> "; ;
        }
        public string getcustcount()
        {
            int custcount = mydbcontext.Customer.ToList<Customer>().Count();
            return "<p class='label label-success'>" + "Total Customers: " + custcount + "</p> "; ;
        }

        [HttpGet]
        public IActionResult addsale()
        {
            List<Item> cat = new List<Item>();
            cat = (from prod in mydbcontext.Item select prod).ToList();
            cat.Insert(0, new Item {  ItemName = "Select Item",ItemModel = "Select Item"});
            ViewBag.listitem = cat;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addsale(Salefinal S)
        {
            if (S.SaleItemName == null)
            {
                ModelState.AddModelError("", "Select item");
            }

            string selectvalue = S.SaleItemName;
            ViewBag.SelectedValue = S.SaleItemName;

            List<Item> cat = new List<Item>();
            cat = (from prod in mydbcontext.Item select prod).ToList();
            cat.Insert(0, new Item { ItemName = "Select Item", ItemModel = "Select Item" });
            ViewBag.listitem = cat;

            var SaleItem = new SaleItem()
            {
                SaleItemName = S.SaleItemName,
                SaleQuantity = S.SaleQuantity,
                SalePrice = S.SalePrice,
                SaleDate = S.SaleDate,


            };

            var chck = mydbcontext.Item.Single(m => m.ItemName == S.SaleItemName);
            if (chck != null)
            {if(chck.ItemQuantity< S.SaleQuantity) { ViewBag.Message = "You dont have " + S.SaleQuantity  +" "+S.SaleItemName +" in your stock. Please try again."; return View(); }
                if (chck.ItemQuantity >= S.SaleQuantity) { chck.ItemQuantity = chck.ItemQuantity - S.SaleQuantity; ViewBag.Message = "You successfully sold " + S.SaleQuantity + " " + S.SaleItemName + " from your stock."; }
            }
            var Salehistory = new SaleHistory()
            {
                SaleItemName = S.SaleItemName,
                SaleQuantity = S.SaleQuantity,
                SalePrice = S.SalePrice,
                SaleDate = S.SaleDate,
                CustomerName = S.CustomerName,
                CustomerPhoneno = S.CustomerPhoneno,

            };
            var Customer = new Customer()
            {
                CustomerName = S.CustomerName,
                CustomerPhoneno = S.CustomerPhoneno,
            };
            mydbcontext.SaleItem.Add(SaleItem);
            mydbcontext.SaleHistory.Add(Salehistory);
            mydbcontext.Customer.Add(Customer);
            mydbcontext.Item.Update(chck);
            mydbcontext.SaveChanges();
            return View();
        }
        public IActionResult viewsalehistory()
        {
            IList<SaleHistory> SS = mydbcontext.SaleHistory.ToList<SaleHistory>();
            return View(SS);

        }

        public IActionResult viewsaleitem()
        {
            IList<SaleItem> SS = mydbcontext.SaleItem.ToList<SaleItem>();
            return View(SS);

        }

        public IActionResult viewcustomer()
        {
            IList<Customer> SS = mydbcontext.Customer.ToList<Customer>();
            return View(SS);

        }
        public IActionResult detailsalehistory(SaleHistory S)
        {
            SaleHistory SS = mydbcontext.SaleHistory.Where(m => m.Sr == S.Sr).FirstOrDefault<SaleHistory>();
            return View(SS);
        }

        public IActionResult detailsaleitem(SaleItem S)
        {
            SaleItem SS = mydbcontext.SaleItem.Where(m => m.SaleId == S.SaleId).FirstOrDefault<SaleItem>();
            return View(SS);
        }

        public IActionResult detailcustomer(Customer S)
        {
            Customer SS = mydbcontext.Customer.Where(m => m.CustomerId == S.CustomerId).FirstOrDefault<Customer>();
            return View(SS);
        }


        public IActionResult deletesalehistory(SaleHistory s)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
            {
                try
                {
                    mydbcontext.SaleHistory.Remove(s);

                    mydbcontext.SaveChanges();
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                }

            }
            return RedirectToAction(nameof(SaleflowController.viewsalehistory));
        }

        public IActionResult deletesaleitem(SaleItem s)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
            {
                try
                {
                    mydbcontext.SaleItem.Remove(s);

                    mydbcontext.SaveChanges();
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                }

            }
            return RedirectToAction(nameof(SaleflowController.viewsaleitem));
        }
        public IActionResult deletecustomer(Customer s)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
            {
                try
                {
                    mydbcontext.Customer.Remove(s);

                    mydbcontext.SaveChanges();
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                }

            }
            return RedirectToAction(nameof(SaleflowController.viewcustomer));
        }

        [HttpGet]
        public IActionResult editsaleitem(int SaleId)
        {
            SaleItem s = mydbcontext.SaleItem.Where(m => m.SaleId == SaleId).FirstOrDefault<SaleItem>();
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult editsaleitem(SaleItem s)
        {
            mydbcontext.SaleItem.Attach(s);
            SaleItem SS = mydbcontext.SaleItem.Where(m => m.SaleId == s.SaleId).FirstOrDefault<SaleItem>();
            var entry = mydbcontext.Entry(SS);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            mydbcontext.SaveChanges();
            return RedirectToAction(nameof(SaleflowController.viewsaleitem));

        }
        [HttpGet]
        public IActionResult editcustomer(int CustomerId)
        {
            Customer s = mydbcontext.Customer.Where(m => m.CustomerId ==CustomerId).FirstOrDefault<Customer>();
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult editcustomer(Customer s)
        {
            mydbcontext.Customer.Attach(s);
            Customer SS = mydbcontext.Customer.Where(m => m.CustomerId == s.CustomerId).FirstOrDefault<Customer>();
            var entry = mydbcontext.Entry(SS);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            mydbcontext.SaveChanges();
            return RedirectToAction(nameof(SaleflowController.viewcustomer));

        }


















    }
}