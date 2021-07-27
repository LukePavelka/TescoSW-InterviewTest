using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TescoSWLibrary.DB
{
    /// <summary>
    /// Db context for entity framework, includes migration if the db has not already been created. 
    /// </summary>
    public class CarContext : DbContext
    {
        public DbSet<CarDbModel> CarDb { get; set; }
        public CarContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=sqlite.db");
        }
    }
}
