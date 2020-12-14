using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageCondo_FP.Common
{
    public enum PropertyStatus
    {
        [Description("Active")]
        Active,

        [Description("Renovation")]
        Renovation,

        [Description("Sold Out")]
        SoldOut,

        [Description("Rented Out")]
        RentedOut
    }

    public enum UnitStatus
    {
        [Description("Active")]
        Active,

        [Description("Renovation")]
        Renovation,

        [Description("Sold Out")]
        SoldOut,

        [Description("Rented Out")]
        RentedOut
    }

    public enum UserStatus
    {
        [Description("Active")]
        Active,

        [Description("InActive")]
        InActive,

        [Description("Blocked")]
        Blocked,
    }

    public enum UserRole
    {
        [Description("Admin")]
        Admin,

        [Description("Resident")]
        Resident
    }

    public enum ResidentType
    {
        OwnerOnSite,
        OwnerOffSite,
        Tenane, 
        Resident,
        ResidentOwner,
        OwnerFamily,
        Guest,
        Occupant,
        UnitManager
    }

    public enum ParcelStatus
    {
        DriverDelivery,
        ResidentPickUp,
        ResidentDelivery,
        DriverPickUp
    }
}