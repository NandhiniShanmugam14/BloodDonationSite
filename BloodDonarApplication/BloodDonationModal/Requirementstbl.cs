using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace BloodDonarApplication.BloodDonationModal
{
    public partial class Requirementstbl: IRequirement<Requirementstbl>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Bloodgroup { get; set; }
        public int Units { get; set; }
        public DateTime? Reqbefore { get; set; }
        public string Reason { get; set; }
        public string Hospital { get; set; }
        public string Patientname { get; set; }
        public int Patientage { get; set; }
        public string Patientgender { get; set; }
        public string Contactperson { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        private readonly BloodDonationContext db = new BloodDonationContext();

        public Requirementstbl()
        {

        }
        //public Requirementstbl(BloodDonationContext _db)
        //{
        //    db = _db;
        //}
        public void AddRequirement(Requirementstbl r)
        {
            db.Requirementstbls.Add(r);
            db.SaveChanges();
        }

        public void DeleteRequirement(int id)
        {
            Requirementstbl r = GetRequirementById(id);
            db.Requirementstbls.Remove(r);
            db.SaveChanges();
        }

        public List<Requirementstbl> GetAllRequirement()
        {
            return db.Requirementstbls.ToList();
        }

        public void UpdateRequirement(int id, Requirementstbl r)
        {
            using (var db = new BloodDonationContext())
            {
                db.Entry(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Requirementstbl GetRequirementById(int id)
        {
            Requirementstbl r = db.Requirementstbls.Find(id);
            return r;
        }
    }
}
