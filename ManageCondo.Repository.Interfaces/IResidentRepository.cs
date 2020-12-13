using ManageCondo.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCondo.Repository.Interfaces
{
    public interface IResidentRepository
    {
        IEnumerable<Resident> GetAllResidents();
        Result<bool> AddResident(Resident resident);
        Result<bool> UpdateResident(Resident resident);
        Resident GetResidentDetails(int residentID);
        Result<bool> DeleteResident(int residentID);

        IEnumerable<Resident> GetResidentByEmail(string email);
    }
}
