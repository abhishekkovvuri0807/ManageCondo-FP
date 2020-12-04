using ManageCondo.DomainModels;
using ManageCondo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PropertyRepository : IPropertyRepository
    {

        private readonly ManageCondoContext _dbContext;
        private readonly UnitRepository _unitRepository;

        public PropertyRepository(ManageCondoContext dbContext, UnitRepository unitRepository)
        {
            _dbContext = dbContext;
            _unitRepository = unitRepository;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _dbContext.Properties.Where(p => p.IsActive).ToList<Property>();
        }

        public void AddProperty(Property property)
        {
            property.IsActive = true;
            _dbContext.Properties.Add(property);
            _dbContext.SaveChanges();
        }

        public void UpdateProperty(Property property)
        {
            Property propertyData = _dbContext.Properties.Where(p => p.ID == property.ID).FirstOrDefault();
            propertyData.Name = property.Name;
            propertyData.Address = property.Address;
            propertyData.Email = property.Email;
            propertyData.Description = property.Description;
            propertyData.Status = property.Status;
            propertyData.Phone = property.Phone;
            _dbContext.SaveChanges();
        }

        public Property GetPropertyDetails(int propertyID)
        {
            return _dbContext.Properties.Where(p => p.ID == propertyID).FirstOrDefault();
        }

        public bool DeleteProperty(int propertyID)
        {
            Property property = _dbContext.Properties.Where(p => p.ID == propertyID).FirstOrDefault();

            List<Unit> units = _unitRepository.GetUnitsByPropertyID(propertyID);
          
            if(units.Count > 0)
            {
                return false;
            } else
            {
                property.IsActive = false;
                int result = _dbContext.SaveChanges();
                if(result > 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
