using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDonarApplication.BloodDonationModal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonarApplication.Controllers
{
    public class AdminController : Controller
    {
        public static List<Blooddonationcamp> bcamp = new List<Blooddonationcamp>();

        [HttpGet]
        public IActionResult AddCamp()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddCamp(Blooddonationcamp b)
        {
            using (var db = new BloodDonationContext())
            {
                db.Blooddonationcamps.Add(b);
                db.SaveChanges();
            }
            return View("Viewcamp");
        }
        [HttpGet]
        public IActionResult Viewcamp()
        {
            using (var db = new BloodDonationContext())
            {
                bcamp = db.Blooddonationcamps.ToList();
            }
            return View(bcamp);
        }

        [HttpGet]
        public IActionResult Editcamp(int id)
        {
            Blooddonationcamp b = new Blooddonationcamp();
            using (var db = new BloodDonationContext())
            {
                b = db.Blooddonationcamps.Find(id);
            }
            return View(b);
        }

        [HttpPost]

        public IActionResult Editcamp(Blooddonationcamp b)
        {
            using (var db = new BloodDonationContext())
            {
                db.Entry(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Viewcamp");
        }

        public IActionResult Deletecamp(int id)
        {
            Blooddonationcamp b = new Blooddonationcamp();
            using (var db = new BloodDonationContext())
            {
                b = db.Blooddonationcamps.Find(id);
                db.Blooddonationcamps.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Viewcamp");
        }

    }
}
