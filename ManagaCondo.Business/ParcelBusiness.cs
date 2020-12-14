using ManageCondo.DomainModels;
using ManageCondo.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace ManagaCondo.Business
{
    public class ParcelBusiness
    {
        private readonly IParcelRepository _parcelRepository;
        public ParcelBusiness(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public IEnumerable<Parcel> GetAllParcels()
        {
            try
            {
                IEnumerable<Parcel> parcels = _parcelRepository.GetAllParcels();
                return parcels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Parcel> GetParcelByUser(string email)
        {
            try
            {
                IEnumerable<Parcel> parcels = _parcelRepository.GetParcelByUser(email);
                return parcels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<bool> AddParcel(Parcel parcel)
        {
            try
            {
                return _parcelRepository.AddParcel(parcel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<bool> UpdateParcel(Parcel parcel)
        {
            try
            {
                return _parcelRepository.UpdateParcel(parcel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Parcel GetParcelDetails(int parcelID)
        {
            try
            {
                return _parcelRepository.GetParcelDetails(parcelID);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<bool> DeleteParcel(int parcelID)
        {
            try
            {
                return _parcelRepository.DeleteParcel(parcelID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
