using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data
{
    public class GymAppContextFactory : IDesignTimeDbContextFactory<GymAppContext>
    {
        public GymAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GymAppContext>();
            optionsBuilder.UseSqlite("Data Source=gymapp.db");

            return new GymAppContext(optionsBuilder.Options);
        }
    }
}
