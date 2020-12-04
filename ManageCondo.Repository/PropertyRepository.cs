using ManageCondo.DomainModels;
using ManageCondo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCondo.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        ManageCondoContext _manageCondoContext;
        public PropertyRepository(ManageCondoContext manageCondoContext)
        {
            _manageCondoContext = manageCondoContext;
          
        }


        public void add()
        {
            Property property = new Property();
            property.ID = 1;
            property.Email = "asd";
            property.Description = "sas";
            property.Name = "sas";
            property.Status = "sas";
            property.Address = "sas";


            _manageCondoContext.Properties.Add(property);
        }
    }
}
