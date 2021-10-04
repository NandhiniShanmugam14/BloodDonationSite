using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDonarApplication.BloodDonationModal;
using BloodDonarApplication.Repository;

namespace BloodDonarApplication.Service
{
    public class ReqServ : IReqServ<Requirementstbl>
    {
        private readonly IReqRepo<Requirementstbl> repo;

        public ReqServ(IReqRepo<Requirementstbl> _repo)
        {
            repo = _repo;
        }
        public void AddRequirement(Requirementstbl r)
        {
            repo.AddRequirement(r);
        }

        public void DeleteRequirement(int id)
        {
            repo.DeleteRequirement(id);
        }

        public List<Requirementstbl> GetAllRequirement()
        {
            return repo.GetAllRequirement();
        }

        public Requirementstbl GetRequirementById(int id)
        {
            return repo.GetRequirementById(id);
        }

        public void UpdateRequirement(int id, Requirementstbl r)
        {
            repo.UpdateRequirement(id, r);
        }
    }
}
