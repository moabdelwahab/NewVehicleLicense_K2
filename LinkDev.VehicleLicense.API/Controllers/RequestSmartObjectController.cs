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

        [System.Web.Http.HttpPost]
        public IHttpActionResult SubmitRequest(NewRequestDto requestDto)
        {
            VehicleLicenseService vehicleLicenseService = new VehicleLicenseService();

            vehicleLicenseService.Create(requestDto);

            return Ok();

        }


        // GET: RequestSmartObject
        [System.Web.Http.HttpGet]
        public IHttpActionResult Test()
        {
            return Ok("Ahmed Michael Mohamed");
        }
    }
}