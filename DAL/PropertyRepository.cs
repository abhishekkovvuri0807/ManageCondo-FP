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

        public PropertyRepository(ManageCondoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _dbContext.Properties.ToList<Property>();
        }

        public void AddProperty(Property property)
        {
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

        public void DeleteProperty(Property property)
        {
            _dbContext.Properties.Remove(property);
            _dbContext.SaveChanges();
        }

    }
}
