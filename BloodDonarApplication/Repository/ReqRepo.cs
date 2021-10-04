using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDonarApplication.BloodDonationModal;

namespace BloodDonarApplication.Repository
{
    public class ReqRepo : IReqRepo<Requirementstbl>
    {

        //Requirementstbl obj = new Requirementstbl();
        private readonly IRequirement<Requirementstbl> obj;

        public ReqRepo(IRequirement<Requirementstbl> _obj)
        {
            obj = _obj;
        }
        public void AddRequirement(Requirementstbl r)
        {
            obj.AddRequirement(r);
        }

        public void DeleteRequirement(int id)
        {
            obj.DeleteRequirement(id);
        }

        public List<Requirementstbl> GetAllRequirement()
        {
            return obj.GetAllRequirement();
        }

        public Requirementstbl GetRequirementById(int id)
        {
            return obj.GetRequirementById(id);
        }

        public void UpdateRequirement(int id, Requirementstbl r)
        {
            obj.UpdateRequirement(id, r);
        }
    }
}
