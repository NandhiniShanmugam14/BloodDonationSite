using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDonarApplication.BloodDonationModal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using PagedList;
//using PagedList.Mvc;

namespace BloodDonarApplication.Controllers
{
    public class RegisterController : Controller
    {
        public static List<Registertbl> reg = new List<Registertbl>();
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RegisterController));

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(Registertbl r)
        {
            _log4net.Info("Register is invoked");
            using (var db = new BloodDonationContext())
            {
                db.Registertbls.Add(r);
                db.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(Registertbl r)
        {
            _log4net.Info(r.UserName + " is logged in");
            if (r.UserName ==  "Admin" && r.Password=="admin")
            {
                HttpContext.Session.SetString("username", r.UserName);
                return RedirectToAction("Viewcamp", "Admin");
            }
            else
            {
                using (var db = new BloodDonationContext())
                {
                    Registertbl result = (from i in db.Registertbls where i.UserName == r.UserName && i.Password == r.Password select i).FirstOrDefault();

                    if (result != null)
                    {
                        HttpContext.Session.SetString("username", result.UserName);
                        HttpContext.Session.SetInt32("id", result.Id);
                        return RedirectToAction("SearchDonors");
                    }
                    else
                    {
                        ViewBag.Message = String.Format("Your Username or Password is incorrect");
                        return View();
                    }
                }
            }
            
        }

        public IActionResult Logout()
        {
            _log4net.Info("Logged out");
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]

        public IActionResult ViewDonars()
        {
            using (var db = new BloodDonationContext())
            {
                reg = db.Registertbls.ToList();
            }
            return View(reg);
        }

        [HttpGet]
        public IActionResult EditDonars(int id)
        {
            Registertbl r = new Registertbl();
            using (var db = new BloodDonationContext())
            {
                r = db.Registertbls.Find(id);
            }
            return View(r);
        }

        [HttpPost]

        public IActionResult EditDonars(Registertbl r)
        {
            _log4net.Info("id " + r.Id + " is edited");
            using (var db = new BloodDonationContext())
            {
                db.Entry(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("DonorProfile", new { id = r.Id });
        }

        public IActionResult DeleteDonors(int id)
        {
            Registertbl r = new Registertbl();
            using (var db = new BloodDonationContext())
            {
                r = db.Registertbls.Find(id);
                db.Registertbls.Remove(r);
                db.SaveChanges();
            }
            return RedirectToAction("DonorProfile");
        }

        [HttpGet]
        public IActionResult SearchDonors(string searching, string searching1)
        {
            using (var db = new BloodDonationContext())
            {
                var search_res = (from i in db.Registertbls select i);
                if(!String.IsNullOrEmpty(searching) && !String.IsNullOrEmpty(searching1))
                {
                    search_res = search_res.Where(i => i.City == searching && i.Bloodgroup == searching1);
                    _log4net.Info(searching  + " and "+ searching1 + " is being searched");
                }
                return View(search_res.ToList()); //.ToPagedList(page ?? 1, 3)
            }
        }
        [HttpGet]
        public IActionResult DonorProfile(int id)
        {
            Registertbl r = new Registertbl();
            using (var db = new BloodDonationContext())
            {
                r = db.Registertbls.Find(id);
            }
            return View(r);
        }


    }
}
