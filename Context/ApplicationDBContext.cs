using DataShelfMaster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShelfMaster.Context
{
    public class ApplicationDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=localhost; Database=datashelfmaster; User=root; Password=;";
            optionsBuilder.UseMySQL(connection);
        }
        
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Solicitude> Solicitudes { get; set; }
    }
}
