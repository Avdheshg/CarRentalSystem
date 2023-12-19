using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    public enum VehicleType
    {
        [Description("SUV")]
        SUV,

        [Description("SEDAN")]
        SEDAN,

        [Description("BIKE")]
        BIKE
    }
}
