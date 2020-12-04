using ManageCondo.DomainModels;
using ManageCondo_FP.Common;
using ManageCondo_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageCondo_FP.Mappers
{
    public static class PropertyMapper
    {
        public static PropertyViewModel ToPropertyViewModel(this Property property)
        {
            PropertyViewModel propertyViewModel = new PropertyViewModel();
            propertyViewModel.PropertyID = property.ID;
            propertyViewModel.Name = property.Name;
            propertyViewModel.Address = property.Address;
            propertyViewModel.Email = property.Email;
            propertyViewModel.Description = property.Description;
            propertyViewModel.Status = (PropertyStatus)Enum.Parse(typeof(PropertyStatus), property.Status, true);
            propertyViewModel.Phone = property.Phone;
            return propertyViewModel;
        }

        public static List<PropertyViewModel> ToPropertyViewModelList(this IEnumerable<Property> properties)
        {
            List<PropertyViewModel> usersDTO = new List<PropertyViewModel>();
            foreach (Property property in properties)
            {
                usersDTO.Add(property.ToPropertyViewModel());
            }
            return usersDTO;
        }

        public static Property ToProperty(this PropertyViewModel propertyViewModel)
        {
            Property property = new Property();
            property.ID = propertyViewModel.PropertyID;
            property.Name = propertyViewModel.Name;
            property.Address = propertyViewModel.Address;
            property.Email = propertyViewModel.Email;
            property.Description = propertyViewModel.Description;
            property.Status = propertyViewModel.Status.ToString();
            property.Phone = propertyViewModel.Phone;
            return property;
        }
    }
}