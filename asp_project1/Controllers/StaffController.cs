using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_project1.Models;
using Microsoft.AspNetCore.Http;

namespace asp_project1.Controllers
{
    public class StaffController : Controller
    {
        asp_proj1Context mydbcontext = null;
        public StaffController(asp_proj1Context _mydbContext)
        {
            mydbcontext = _mydbContext;
        }
        public string getusercount()
        {
            int usrcount = mydbcontext.ShopStaff.ToList<ShopStaff>().Count();
            return "<p class='label label-success'>"+"Users: " +usrcount+"</p> ";
        }


        [HttpGet]
        public IActionResult addmember()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addmember(ShopStaff S)
        {

            using (var t = mydbcontext.Database.BeginTransaction())
                try
                {

                    mydbcontext.ShopStaff.Add(S);
                    mydbcontext.SaveChanges();
                    ViewBag.Message = S.Username + " " + "is successfully added.";
                    t.Commit(); }
                catch (Exception e) { t.Rollback(); }
                return View();

        }
        [HttpGet]
        public IActionResult dashboard()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Optforadmin(ShopStaff S)
        {

            using (var t = mydbcontext.Database.BeginTransaction())
                try
                {

                    mydbcontext.ShopStaff.Add(S);
                    mydbcontext.SaveChanges();
                    ViewBag.Message = S.Username + " " + "is successfully added.";
                    t.Commit();
                }
                catch (Exception e) { t.Rollback(); }
            return View();

        }
        [HttpGet]
        public IActionResult Optforadmin()
        {
            return View();
        }
        public IActionResult Optforusers()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult dashboard(ShopStaff S1)
        {
            try
            {
                try
                {
                    var shop = mydbcontext.ShopStaff.Single(m => m.Username == S1.Username && m.Password == S1.Password && m.Designation == "staff");
                    if (shop != null)
                    {
                        return RedirectToAction(nameof(StaffController.Optforusers));
                    }
                }
                catch (Exception e)
                {
                    var shop1 = mydbcontext.ShopStaff.Single(m => m.Username == S1.Username && m.Password == S1.Password && m.Designation == "admin");
                    if (shop1 != null)
                    {
                        return RedirectToAction(nameof(StaffController.Optforadmin));

                    }

                }
            }
            catch (Exception e)
            {
                                    ViewBag.Message = "Username or password is incorrect. Please enter again.";

            }
            return View();
        }
        public IActionResult viewallusers()
        {
            IList<ShopStaff> SS = mydbcontext.ShopStaff.ToList<ShopStaff>();
            return View(SS);
        }
        public IActionResult detail(ShopStaff S)
        {
            ShopStaff SS = mydbcontext.ShopStaff.Where(m => m.StaffId == S.StaffId).FirstOrDefault<ShopStaff>();
            return View(SS);
        }

        public IActionResult delete(ShopStaff s)
        {
            using (var t = mydbcontext.Database.BeginTransaction())
            {
                try
                {
                    mydbcontext.ShopStaff.Remove(s);

                    mydbcontext.SaveChanges();
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                }
            }

            return RedirectToAction(nameof(StaffController.viewallusers));
        }
        [HttpGet]
        public IActionResult edit(int StaffId)
        {
            ShopStaff s = mydbcontext.ShopStaff.Where(m => m.StaffId == StaffId).FirstOrDefault<ShopStaff>();
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit(ShopStaff s)
        {
            mydbcontext.ShopStaff.Attach(s);
            ShopStaff SS = mydbcontext.ShopStaff.Where(m => m.StaffId == s.StaffId).FirstOrDefault<ShopStaff>();
            var entry = mydbcontext.Entry(SS);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            mydbcontext.SaveChanges();
            return RedirectToAction(nameof(StaffController.viewallusers));

        }




    }
}