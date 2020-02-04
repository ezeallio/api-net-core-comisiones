using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL
{
    public interface ISalesContext
    {
        DbSet<Salesman> Salesmen { get; set; }
        DbSet<Package> Packages { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<PackageItem> PackageItems { get; set; }
    }
}
