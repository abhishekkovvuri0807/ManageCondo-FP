using ManageCondo.DomainModels;
using ManageCondo_FP.Common;
using ManageCondo_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageCondo_FP.Mappers
{
    public static class ParcelMapper
    {
        public static ParcelViewModel ToParcelViewModel(this Parcel parcel)
        {
            ParcelViewModel viewModel = new ParcelViewModel();
            viewModel.ParcelID = parcel.ID;
            viewModel.Courier = parcel.Courier;
            viewModel.isIncoming = parcel.IsIncoming;
            viewModel.NumberOfPeices = parcel.NumberOfPeices;
            //viewModel.DateRecieved = parcel.DateRecieved;
            //viewModel.DateReleased = parcel.DateReleased;
            viewModel.Description = parcel.Description;

            viewModel.Staus = (ParcelStatus)Enum.Parse(typeof(ParcelStatus), parcel.Status, true);


            if (parcel.Resident != null)
            {
                viewModel.Resident = new ResidentViewModel();
                viewModel.Resident = parcel.Resident.ToResidentViewModel();

                if (parcel.Resident.User != null)
                {
                    viewModel.Resident.User = new UserViewModel();
                    viewModel.Resident.User = parcel.Resident.User.ToUserViewModel();
                    viewModel.UserID = viewModel.Resident.User.UserID;
                }
            }

           // viewModel.UserID = parcel.Resident.User.ToUser()

            //viewModel.ResidentID = resident.UnitID;
            //viewModel.UserID = parcel.UserID;

            //if (resident.Unit != null)
            //{
            //    viewModel.Unit = resident.Unit.ToUnitViewModel();
            //}

            //if (resident.User != null)
            //{
            //    viewModel.User = resident.User.ToUserViewModel();
            //}

            return viewModel;
        }

        public static List<ParcelViewModel> ToParcelViewModelList(this IEnumerable<Parcel> parcels)
        {
            List<ParcelViewModel> residentDTO = new List<ParcelViewModel>();
            foreach (Parcel parcel in parcels)
            {
                residentDTO.Add(parcel.ToParcelViewModel());
            }
            return residentDTO;
        }

        public static Parcel ToParcel(this ParcelViewModel viewModel)
        {
            Parcel parcel = new Parcel();
            parcel.ID = viewModel.ParcelID;
            parcel.Courier = viewModel.Courier;
            parcel.IsIncoming = viewModel.isIncoming;
            parcel.NumberOfPeices = viewModel.NumberOfPeices;
            //parcel.DateRecieved = viewModel.DateRecieved;
            //parcel.DateReleased = viewModel.DateReleased;
            parcel.Description = viewModel.Description;
            parcel.Status = viewModel.Staus.ToString();


            parcel.Resident = new Resident();
            parcel.Resident.User = new User();
            parcel.Resident.User.ID = viewModel.UserID;


            //parcel.Resident = viewModel.Resident.ToResident();

            //    if(viewModel.Resident.User != null)
            //    {
            //        parcel.Resident.User = viewModel.Resident.User.ToUser();
            //    }
            //}



            return parcel;
        }
    }
}