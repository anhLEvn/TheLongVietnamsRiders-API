using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAPI_TLVNsR.Models;

namespace WebAppAPI_TLVNsR.DataContext
{
    public class TLVNsRsDBContext: DbContext
    {
        public TLVNsRsDBContext (DbContextOptions<TLVNsRsDBContext> options): base(options)
        {
         }
        public DbSet <Tour> Tours { get; set; }
        public DbSet <TourCategory> TourCategories { get; set; }

    }
}
