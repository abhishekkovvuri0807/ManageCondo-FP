using DAL.Utility;
using ManageCondo.DomainModels;
using ManageCondo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly ManageCondoContext _dbContext;

        public ParcelRepository(ManageCondoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Parcel> GetAllParcels()
        {
            try
            {
                return _dbContext.Parcels.Where(u => u.IsActive == true).Include(r => r.Resident).
                    Where(r => r.IsActive == true).Include(r => r.Resident.User).Where(r => r.Resident.User.IsActive == true)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Parcel> GetParcelByUser(string email)
        {
            return _dbContext.Parcels.Where(u => u.IsActive == true).Include(r => r.Resident).
                    Where(r => r.IsActive == true).Include(r => r.Resident.User).Where(r => r.Resident.User.IsActive == true && r.Resident.User.Email == email)
                    .ToList();
        }

        public Result<bool> AddParcel(Parcel parcel)
        {
            try
            {
                User user = _dbContext.Users.Where(r => r.IsActive == true && r.ID == parcel.Resident.User.ID).FirstOrDefault();
                Resident resident = _dbContext.Residents.Where(r => r.IsActive == true && r.UserID == user.ID).FirstOrDefault();
                
                parcel.IsActive = true;
                parcel.Resident = resident;
                parcel.ResidentID = resident.ID;

                _dbContext.Parcels.Add(parcel);
                if (_dbContext.SaveChanges() > 0)
                {
                    return Result<bool>.Success(true, Constants.PARCELS_ADD_SUCCESS);
                }
                return Result<bool>.Fail(Constants.ERROR);
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

                User user = _dbContext.Users.Where(r => r.IsActive == true && r.ID == parcel.Resident.User.ID).FirstOrDefault();
                Resident resident = _dbContext.Residents.Where(r => r.IsActive == true && r.UserID == user.ID).FirstOrDefault();

                Parcel parcelData = _dbContext.Parcels.Where(p => p.ID == parcel.ID).FirstOrDefault();

                if (parcelData != null)
                {
                    parcelData.Courier = parcel.Courier;
                    parcelData.IsIncoming = parcel.IsIncoming;
                    parcelData.NumberOfPeices = parcel.NumberOfPeices;
                    parcelData.IsActive = parcel.IsActive;
                    //parcelData.DateRecieved = parcel.DateRecieved;
                    //parcelData.DateReleased = parcel.DateReleased;
                    parcelData.Status = parcel.Status;
                   
                        parcel.Resident = resident;
                        parcelData.ResidentID = resident.ID;

                   
                    parcelData.Description = parcel.Description;

                    if (_dbContext.SaveChanges() > 0)
                    {
                        return Result<bool>.Success(true, Constants.PARCELS_UPDATE_SUCCESS);
                    }
                }
                else
                {
                    return Result<bool>.Fail(Constants.PARCEL_NOT_EXISTS);
                }
                return Result<bool>.Fail(Constants.ERROR);
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
                return _dbContext.Parcels.Where(u => u.IsActive == true && u.ID == parcelID).Include(r => r.Resident).
                    Where(r => r.IsActive == true).Include(r => r.Resident.User).Where(r => r.Resident.User.IsActive == true)
                    .FirstOrDefault();
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
                Parcel parcelData = _dbContext.Parcels.Where(p => p.ID == parcelID).FirstOrDefault();
                parcelData.IsActive = false;
                if (_dbContext.SaveChanges() > 0)
                {
                    return Result<bool>.Success(true, Constants.PARCELS_UPDATE_SUCCESS);
                }
                return Result<bool>.Fail(Constants.ERROR);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
