using CarsLibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsLibraryApi.Context
{
    public class LogContext : DbContext
    {
        public DbSet<LogModel> Logs { get; set; }
        public LogContext(DbContextOptions<LogContext> contextOptions) : base(contextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
