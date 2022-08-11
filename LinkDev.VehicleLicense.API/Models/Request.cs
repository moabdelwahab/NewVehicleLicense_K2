using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkDev.VehicleLicense.API.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RequestNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string VehicleNumber { get; set; }
        public string VehicleOwnerName { get; set; }
        public string NationalId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public int ProcessInsId { get; set; }
        public string RequestStatus { get; set; }
    }
}