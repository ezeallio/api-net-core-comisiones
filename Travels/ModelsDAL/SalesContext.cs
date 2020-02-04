using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL
{
    public class SalesContext : DbContext, ISalesContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = EZE-PC\\MSSQLSERVER2; Initial Catalog = LandingTravel; Integrated Security= True");
            optionsBuilder.UseLazyLoadingProxies(true);
        }

        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PackageItem> PackageItems { get; set; }
    }
}
