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
}