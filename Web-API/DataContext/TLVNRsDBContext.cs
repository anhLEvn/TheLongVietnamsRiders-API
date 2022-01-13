using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Models
{
    public class TLVNRsDBContext : DbContext
    {
        public TLVNRsDBContext(DbContextOptions<TLVNRsDBContext> options) : base(options)
        {

        }

        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tour> Tours { get; set; }
    }
}
