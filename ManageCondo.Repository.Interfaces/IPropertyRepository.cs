using ManageCondo.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCondo.Repository.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAllProperties();

        void AddProperty(Property property);

        void UpdateProperty(Property property);

        Property GetPropertyDetails(int propertyID);

        bool DeleteProperty(int propertyID);
    }
}
