using LinkDev.VehicleLicense.API.DTO;
using LinkDev.VehicleLicense.API.Models;
using LinkDev.VehicleLicense.API.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkDev.VehicleLicense.API.Services
{
    public class VehicleLicenseService
    {
        public bool Create(NewRequestDto requestDto)
        {
            Request request = new Request()
            {
                VehicleNumber = requestDto.VehicleNumber,
                VehicleOwnerName = requestDto.VehicleOwnerName,
                NationalId = requestDto.NationalId,
                CreatedBy = requestDto.Requester
            };

            Random rnd = new Random();
            int rNumber = rnd.Next(52);
            request.RequestNumber = "NVL-" + rNumber;

            K2Service k2Service = new K2Service();

             request.ProcessInsId = k2Service.StartWorkflow(requestDto.Requester, request);


            using (AppDbContext dbContext = new AppDbContext())
            {
                dbContext.Requests.Add(request);
                dbContext.SaveChanges();
            }

            return true;

        }

        public bool UpdateStatus(string RequestNumber, string Status)
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                var request = appDbContext.Requests.FirstOrDefault(x => x.RequestNumber == RequestNumber);
                if (request == null) return false;
                request.RequestStatus = Status;
                appDbContext.SaveChanges();
            }

            return true;
        }
    }
}