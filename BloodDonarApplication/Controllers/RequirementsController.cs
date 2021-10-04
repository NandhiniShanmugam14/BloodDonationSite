using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDonarApplication.BloodDonationModal;
using BloodDonarApplication.Service;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonarApplication.Controllers
{
    public class RequirementsController : Controller
    {
        //public static List<Requirementstbl> req = new List<Requirementstbl>();

        private readonly IReqServ<Requirementstbl> serv;

        public RequirementsController(IReqServ<Requirementstbl> _serv)
        {
            serv = _serv;
        }

        public IActionResult ViewRequirement()
        {
            //using (var db = new BloodDonationContext())
            //{
            //    req = db.Requirementstbls.ToList();
            //}
            //return View(req);
            return View(serv.GetAllRequirement());
        }

        [HttpGet]
        public IActionResult AddRequirement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRequirement(Requirementstbl r)
        {
            using (var db = new BloodDonationContext())
            {
                serv.AddRequirement(r);
                //db.Requirementstbls.Add(r);
                db.SaveChanges();
            }

            return RedirectToAction("ViewRequirement");
        }

        [HttpGet]

        public IActionResult ContactDetail(int id)
        {
            Requirementstbl r = new Requirementstbl();
            using (var db = new BloodDonationContext())
            {
                r = db.Requirementstbls.Find(id);
            }
            return View(r);
        }

        [HttpGet]
        public IActionResult EditRequirement(int id)
        {
            Requirementstbl r = new Requirementstbl();
            using (var db = new BloodDonationContext())
            {
                r = db.Requirementstbls.Find(id);
            }
            return View(r);
        }

        [HttpPost]

        public IActionResult EditRequirement(Requirementstbl r)
        {
            using (var db = new BloodDonationContext())
            {
                db.Entry(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ViewRequirement");
        }

        public IActionResult DeleteRequirement(int id)
        {
            Requirementstbl r = new Requirementstbl();
            using (var db = new BloodDonationContext())
            {
                r = db.Requirementstbls.Find(id);
                db.Requirementstbls.Remove(r);
                db.SaveChanges();
            }
            return RedirectToAction("ViewRequirement");
        }
    }
}
