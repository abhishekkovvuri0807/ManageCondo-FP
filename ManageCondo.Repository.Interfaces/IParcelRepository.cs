using ManageCondo.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCondo.Repository.Interfaces
{
    public interface IParcelRepository
    {
        IEnumerable<Parcel> GetAllParcels();
        Result<bool> AddParcel(Parcel parcel);
        Result<bool> UpdateParcel(Parcel parcel);
        Parcel GetParcelDetails(int parcelID);
        Result<bool> DeleteParcel(int parcelID);
        IEnumerable<Parcel> GetParcelByUser(string user);
    }
}
