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
    public class ResidentRepository : IResidentRepository
    {
        private readonly ManageCondoContext _dbContext;

        public ResidentRepository(ManageCondoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Resident> GetAllResidents()
        {
            try
            {
                return _dbContext.Residents.Where(u => u.IsActive == true).Include(r => r.Unit).
                    Where(u => u.IsActive == true).
                    Include(r => r.User).Where(u => u.IsActive == true).ToList();
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Resident> GetResidentByEmail(string email)
        {
            User user = _dbContext.Users.Where(u => u.IsActive == true && u.Email == email).FirstOrDefault();
            IEnumerable<Resident> residents = _dbContext.Residents.Where(u => u.IsActive == true && u.UserID == user.ID).Include(r => r.Unit).
                    Where(u => u.IsActive == true).
                    Include(r => r.User).Where(u => u.IsActive == true).ToList();
            return residents;
        }

        public Result<bool> AddResident(Resident resident)
        {
            try
            {
                resident.IsActive = true;
                _dbContext.Residents.Add(resident);
                if (_dbContext.SaveChanges() > 0)
                {
                    return Result<bool>.Success(true, Constants.RESIDENT_ADD_SUCCESS);
                }
                return Result<bool>.Fail(Constants.ERROR);
            } catch (Exception ex)
            {
                throw ex;
            }

           
        }

        public Result<bool> UpdateResident(Resident resident)
        {
            try
            {
                Resident residentData = _dbContext.Residents.Where(p => p.ID == resident.ID).FirstOrDefault();

                if (residentData != null)
                {
                    residentData.Address = resident.Address;
                    residentData.DateOfBirth = resident.DateOfBirth;
                    residentData.MoveInDate = resident.MoveInDate;
                    residentData.Phone = resident.Phone;
                    residentData.ResidentType = resident.ResidentType;
                    if(resident.UserID != 0 && residentData.UnitID != 0)
                    {
                        residentData.UserID = resident.UserID;
                        residentData.UnitID = resident.UnitID;
                    }
                    residentData.HavePets = resident.HavePets;
                    residentData.EmergencyNotes = resident.EmergencyNotes;
                    residentData.EmergencyContact = resident.EmergencyContact;


                    if (_dbContext.SaveChanges() > 0)
                    {
                        return Result<bool>.Success(true, Constants.RESIDENT_UPDATE_SUCCESS);
                    }
                }
                else
                {
                    return Result<bool>.Fail(Constants.RESIDENT_NOT_EXISTS);
                }
                return Result<bool>.Fail(Constants.ERROR);
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public Resident GetResidentDetails(int residentID)
        {
            try
            {
                return _dbContext.Residents.Where(p => p.ID == residentID).FirstOrDefault();
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public Result<bool> DeleteResident(int residentID)
        {
            try
            {
                Resident residentData = _dbContext.Residents.Where(p => p.ID == residentID).FirstOrDefault();
                residentData.IsActive = false;
                if (_dbContext.SaveChanges() > 0)
                {
                    return Result<bool>.Success(true, Constants.RESIDENT_UPDATE_SUCCESS);
                }
                 return Result<bool>.Fail(Constants.ERROR);
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
