using ManageCondo.DomainModels;
using ManageCondo_FP.Common;
using ManageCondo_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageCondo_FP.Mappers
{
    public static class UnitMapper
    {
        public static UnitViewModel ToUnitViewModel(this Unit unit)
        {
            UnitViewModel unitViewModel = new UnitViewModel();
            unitViewModel.UnitID = unit.ID;
            unitViewModel.Name = unit.Name;
            unitViewModel.Level = unit.Level;
            unitViewModel.FobKey = unit.FobKey;
            unitViewModel.Description = unit.Description;
            unitViewModel.IsRentedOut = unit.isRentedOut;
            unitViewModel.Status = (UnitStatus)Enum.Parse(typeof(UnitStatus), unit.Status, true);
            unitViewModel.PropertyID = unit.PropertyID;
            unitViewModel.Property = unit.Property.ToPropertyViewModel();
            return unitViewModel;
        }

        public static List<UnitViewModel> ToUnitViewModelList(this IEnumerable<Unit> units)
        {
            List<UnitViewModel> unitsDTO = new List<UnitViewModel>();
            foreach (Unit unit in units)
            {
                unitsDTO.Add(unit.ToUnitViewModel());
            }
            return unitsDTO;
        }

        public static Unit ToUnit(this UnitViewModel unitViewModel)
        {
            Unit unit = new Unit();
            unit.ID = unitViewModel.UnitID;
            unit.Name = unitViewModel.Name;
            unit.Level = unitViewModel.Level;
            unit.FobKey = unitViewModel.FobKey;
            unit.Description = unitViewModel.Description;
            unit.Status = unitViewModel.Status.ToString();
            unit.isRentedOut = unitViewModel.IsRentedOut;
            unit.PropertyID = unitViewModel.PropertyID;
            unit.Property = unitViewModel.Property.ToProperty();
            return unit;
        }
    }
}