using DomainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Data
{
    public class EshopDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=(local);Initial Catalog=nbgEshopDb;User Id=sa; Password=passw0rd;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
