using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkDev.VehicleLicense.API.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleOwnerName { get; set; }
        public string NationalId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string RequestStatus { get; set; }
    }
}