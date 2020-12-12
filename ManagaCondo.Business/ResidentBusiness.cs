using ManageCondo.DomainModels;
using ManageCondo.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace ManagaCondo.Business
{
    public class ResidentBusiness
    {
        private readonly IResidentRepository _residentRepository;
        public ResidentBusiness(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }

        public IEnumerable<Resident> GetAllResidents()
        {
            try
            {
                IEnumerable<Resident> units = _residentRepository.GetAllResidents();
                return units;
            } catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public Result<bool> AddResident(Resident unit)
        {
            try
            {
                return _residentRepository.AddResident(unit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<bool> UpdateResident(Resident user)
        {
            try
            {
                return _residentRepository.UpdateResident(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resident GetResidentDetails(int userID)
        {
            try
            {
                return _residentRepository.GetResidentDetails(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<bool> DeleteResident(int userID)
        {
            try
            {
               return _residentRepository.DeleteResident(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
