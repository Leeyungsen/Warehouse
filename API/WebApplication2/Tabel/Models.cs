using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApplication2.Tabel {
    
    public class SEContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<MsCategory> MsCategory { get; set; }
        public DbSet<MsLogin> MsLogin { get; set; }

        public string DbPath { get; }

        public SEContext()
        {
            
        }



        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {   
            options.UseSqlServer("Data Source=LAPTOP-P6A1MIO7\\SQLEXPRESS; Initial Catalog=Project; User Id=; Password=;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }
    }

    public class MsLogin
    {
        [Key]
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string EmailAdderss { get; set; }
        public string Password { get; set; }
        
         
    }

    public class MsCategory
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        
    }
}