using ManageCondo.DomainModels;
using ManageCondo_FP.Common;
using ManageCondo_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageCondo_FP.Mappers
{
    public static class ResidentMapper
    {
        public static ResidentViewModel ToResidentViewModel(this Resident resident)
        {
            ResidentViewModel viewModel = new ResidentViewModel();
            viewModel.ResidentID = resident.ID;
            viewModel.Phone = resident.Phone;
            viewModel.Address = resident.Address;
            viewModel.MoveInDate = resident.MoveInDate;
            viewModel.DateOfBirth = resident.DateOfBirth;
            viewModel.EmergencyNotes = resident.EmergencyNotes;
            viewModel.EmergencyContact = resident.EmergencyContact;
            viewModel.HavePets = resident.HavePets;
            viewModel.ResidentType = (ResidentType)Enum.Parse(typeof(ResidentType), resident.ResidentType, true);

            viewModel.UnitID = resident.UnitID;
            viewModel.UserID = resident.UserID;

            if (resident.Unit != null)
            {
                viewModel.Unit = resident.Unit.ToUnitViewModel();
            }

            if (resident.User != null)
            {
                viewModel.User = resident.User.ToUserViewModel();
            }

            return viewModel;
        }

        public static List<ResidentViewModel> ToResidentViewModelList(this IEnumerable<Resident> residents)
        {
            List<ResidentViewModel> residentDTO = new List<ResidentViewModel>();
            foreach (Resident resident in residents)
            {
                residentDTO.Add(resident.ToResidentViewModel());
            }
            return residentDTO;
        }

        public static Resident ToResident(this ResidentViewModel residentViewModel)
        {
            Resident resident = new Resident();
            resident.ID = residentViewModel.ResidentID;
            resident.Phone = residentViewModel.Phone;
            resident.Address = residentViewModel.Address;
            resident.MoveInDate = residentViewModel.MoveInDate;
            resident.DateOfBirth = residentViewModel.DateOfBirth;
            resident.EmergencyNotes = residentViewModel.EmergencyNotes;
            resident.EmergencyContact = residentViewModel.EmergencyContact;
            resident.HavePets = residentViewModel.HavePets;
            resident.ResidentType = residentViewModel.ResidentType.ToString();
            resident.UnitID = residentViewModel.UnitID;
            resident.UserID = residentViewModel.UserID;


            //if (resident.Unit != null)
            //{
            //    resident.Unit = residentViewModel.Unit.ToUnit();
            //}

            //if (resident.User != null)
            //{
            //    resident.User = residentViewModel.User.ToUser();
            //}

            return resident;
        }
    }
}