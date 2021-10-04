using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonarApplication.Repository
{
    public interface IReqRepo<Requirementstbl>
    {
        public void AddRequirement(Requirementstbl r);
        public List<Requirementstbl> GetAllRequirement();
        public void UpdateRequirement(int id, Requirementstbl r);
        public void DeleteRequirement(int id);
        public Requirementstbl GetRequirementById(int id);
    }
}
