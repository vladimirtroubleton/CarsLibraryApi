using CarsLibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsLibraryApi.Context
{
    public class CarsContext : DbContext
    {
        public DbSet<CarModel> Cars { get; set; }

        public CarsContext(DbContextOptions<CarsContext> contextOptions): base(contextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
