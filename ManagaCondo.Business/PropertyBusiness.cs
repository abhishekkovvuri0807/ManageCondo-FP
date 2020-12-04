using ManageCondo.DomainModels;
using ManageCondo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageCondo.Business
{
    public class PropertyBusiness
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertyBusiness(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            IEnumerable<Property> properties = _propertyRepository.GetAllProperties();
            return properties;
        }

        public void AddProperty(Property property)
        {
             _propertyRepository.AddProperty(property);
        }

        public void UpdateProperty(Property property)
        {
            _propertyRepository.UpdateProperty(property);
        }

        public Property GetPropertyDetails(int propertyID)
        {
            return _propertyRepository.GetPropertyDetails(propertyID);
        }

        public void DeleteProperty(Property property)
        {
            _propertyRepository.DeleteProperty(property);
        }

    }
}
