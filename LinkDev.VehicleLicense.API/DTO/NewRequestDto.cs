using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkDev.VehicleLicense.API.DTO
{
    public class NewRequestDto
    {
        public string VehicleNumber { get; set; }
        public string VehicleOwnerName { get; set; }
        public string NationalId { get; set; }
        public string Requester { get; set; }
    }
}