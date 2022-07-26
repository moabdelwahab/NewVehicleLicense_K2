using LinkDev.VehicleLicense.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LinkDev.VehicleLicense.API.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("LinkServer")
        {

        }
        public DbSet<Request> Requests { get; set; }
    }
}