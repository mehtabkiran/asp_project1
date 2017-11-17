using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_project1.Models;

namespace asp_project1.Controllers
{
    public class PurchaseflowController : Controller
    {
        asp_proj1Context mydbcontext = null;
        public PurchaseflowController(asp_proj1Context _mydbContext)
        {
            mydbcontext = _mydbContext;
        }
        [HttpGet]
        public IActionResult addpurchase()
        {
            return View();
        }

        public string getpicount()
        {
            int picount = mydbcontext.PurchaseItem.ToList<PurchaseItem>().Count();
            return "<p class='label label-success'>" + "Purchased products: " + picount + "</p> "; ;
        }
        public string getvendorcount()
        {
            int vendorcount = mydbcontext.Vendor.ToList<Vendor>().Count();
            return "<p class='label label-success'>" + "Total Vendors: " + vendorcount + "</p> "; ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addpurchase(Purchasefinal P)
        {
            var PurchaseItem = new PurchaseItem()
            {
                PurchaseItemName = P.PurchaseItemName,
                PurchaseQuantity = P.PurchaseQuantity,
                PurchasePrice = P.PurchasePrice,
                PurchasingDate = P.PurchasingDate,


            };

            var chck = mydbcontext.Item.Single(m => m.ItemName == P.PurchaseItemName);
                if(chck!=null)
            {
                chck.ItemQuantity = chck.ItemQuantity + P.PurchaseQuantity;
            }
                var Purchasehistory = new PurchaseHistory()
            {
                PurchaseItemName = P.PurchaseItemName,
                PurchaseQuantity = P.PurchaseQuantity,
                PurchasePrice = P.PurchasePrice,
                PurchaseDate = P.PurchasingDate,
                VendorName = P.VendorName,
                VendorPhoneno=P.VendorPhoneno,

            };
            var Vendor = new Vendor()
            {
                VendorName = P.VendorName,
                VendorPhoneno = P.VendorPhoneno,
            };
            mydbcontext.PurchaseItem.Add(PurchaseItem);
            mydbcontext.PurchaseHistory.Add(Purchasehistory);
            mydbcontext.Vendor.Add(Vendor);
            mydbcontext.Item.Update(chck);
            mydbcontext.SaveChanges();
            ViewBag.Message = P.PurchaseItemName + " " + "is successfully added in stock.";
            return View();
        }
    public IActionResult viewpurchasehistory()
        {
            IList<PurchaseHistory> SS = mydbcontext.PurchaseHistory.ToList<PurchaseHistory>();
            return View(SS);

        }

        public IActionResult viewpurchaseitem()
        {
            IList<PurchaseItem> SS = mydbcontext.PurchaseItem.ToList<PurchaseItem>();
            return View(SS);

        }

        public IActionResult viewvendors()
        {
            IList<Vendor> SS = mydbcontext.Vendor.ToList<Vendor>();
            return View(SS);

        }
        public IActionResult detailpurchasehistory(PurchaseHistory S)
        {
            PurchaseHistory SS = mydbcontext.PurchaseHistory.Where(m => m.Sr == S.Sr).FirstOrDefault<PurchaseHistory>();
            return View(SS);
                }

        public IActionResult detailpurchaseitem(PurchaseItem S)
        {
            PurchaseItem SS = mydbcontext.PurchaseItem.Where(m => m.PurchaseId == S.PurchaseId).FirstOrDefault<PurchaseItem>();
            return View(SS);
        }

        public IActionResult detailvendor(Vendor S)
        {
            Vendor SS = mydbcontext.Vendor.Where(m => m.VendorId == S.VendorId).FirstOrDefault<Vendor>();
            return View(SS);
        }
        public IActionResult deletepurchasehistory(PurchaseHistory s)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
            {
                try
                {
                    mydbcontext.PurchaseHistory.Remove(s);

                    mydbcontext.SaveChanges();
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                }

            }
            return RedirectToAction(nameof(PurchaseflowController.viewpurchasehistory));
        }

        public IActionResult deletepurchaseitem(PurchaseItem s)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
            {
                try
                {
                    mydbcontext.PurchaseItem.Remove(s);

                    mydbcontext.SaveChanges();
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                }

            }
            return RedirectToAction(nameof(PurchaseflowController.viewpurchaseitem));
        }
        public IActionResult deletevendor(Vendor s)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
            {
                try
                {
                    mydbcontext.Vendor.Remove(s);

                    mydbcontext.SaveChanges();
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                }

            }
            return RedirectToAction(nameof(PurchaseflowController.viewvendors));
        }
        [HttpGet]
        public IActionResult editpurchaseitem(int PurchaseId)
        {
            PurchaseItem s = mydbcontext.PurchaseItem.Where(m => m.PurchaseId == PurchaseId).FirstOrDefault<PurchaseItem>();
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult editpurchaseitem(PurchaseItem s)
        {
            mydbcontext.PurchaseItem.Attach(s);
            PurchaseItem SS = mydbcontext.PurchaseItem.Where(m => m.PurchaseId == s.PurchaseId).FirstOrDefault<PurchaseItem>();
            var entry = mydbcontext.Entry(SS);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            mydbcontext.SaveChanges();
            return RedirectToAction(nameof(PurchaseflowController.viewpurchaseitem));

        }
        [HttpGet]
        public IActionResult editvendor(int VendorId)
        {
            Vendor s = mydbcontext.Vendor.Where(m => m.VendorId == VendorId).FirstOrDefault<Vendor>();
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult editvendor(Vendor s)
        {
            mydbcontext.Vendor.Attach(s);
            Vendor SS = mydbcontext.Vendor.Where(m => m.VendorId == s.VendorId).FirstOrDefault<Vendor>();
            var entry = mydbcontext.Entry(SS);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            mydbcontext.SaveChanges();
            return RedirectToAction(nameof(PurchaseflowController.viewvendors));

        }





    }
}