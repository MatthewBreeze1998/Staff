using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Models
{
    public class StaffDataBaseContext : DbContext
    {

        public DbSet<StaffModel> Staff { get; set; }

        public StaffDataBaseContext(DbContextOptions<StaffDataBaseContext> options) : base(options)
        {
            Database.Migrate();// creates or migrates data if data base has been created 
        }
    }
}
