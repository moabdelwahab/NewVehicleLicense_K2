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
    public class RequestSmartObjectController : ApiController
    {


        // GET: RequestSmartObject
        [System.Web.Http.HttpGet]
        public IHttpActionResult ChangeStatus(string folio, string status)
        {
            VehicleLicenseService vehicleLicenseService = new VehicleLicenseService();
            vehicleLicenseService.UpdateStatus(folio, status);

            return Ok();
        }


        [System.Web.Http.HttpGet]
        public IHttpActionResult TestApi()
        {
            return Ok("Mohamed Abd El Wahab !");
        }
    }
}