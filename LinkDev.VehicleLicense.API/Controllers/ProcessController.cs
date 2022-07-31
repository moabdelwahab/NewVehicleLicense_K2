using LinkDev.VehicleLicense.API.DTO;
using LinkDev.VehicleLicense.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LinkDev.VehicleLicense.API.Controllers
{
    public class ProcessController : ApiController
    {

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateRequest(NewRequestDto newRequestDto)
        {

            try
            {
                VehicleLicenseService vehicleLicenseService = new VehicleLicenseService();
                vehicleLicenseService.Create(newRequestDto);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}