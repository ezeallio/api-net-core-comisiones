using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ModelsDAL;
using Enums;
using ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace ModelsBLL
{
    public class PackageBLL : IPackageBLL
    {
        private readonly ISalesContext _ctx;

        public PackageBLL(ISalesContext ctx)
        {
            _ctx = ctx;
        }

        public List<PackageDTO> GetPackages(string description)
        {
            var result = new List<PackageDTO>();

            if (string.IsNullOrEmpty(description))
            {
                result = _ctx.Packages.Select(x => new PackageDTO { PackageId = x.PackageId, Description = x.Description })
                    .OrderBy(x => x.Description).ToList();
            }
            else
            {
                result = _ctx.Packages.Select(x => new PackageDTO { PackageId = x.PackageId, Description = x.Description })
                .Where(x => x.Description.Contains(description)).OrderBy(x => x.Description).ToList();
            }

            return result;
        }

        public PackageItemDTO GetPackage(int id)
        {
            return _ctx.Packages.Include(x => x.PackageItems)
                .Select(y => new PackageItemDTO { PackageId = y.PackageId, Description = y.Description,
                    Items = y.PackageItems.Select(h => 
                    new ItemDTO { Description = h.Item.Description, Category = h.Item.Category, Price = h.Item.Price, Type = h.Item.Type })
                    .ToList() })
                .FirstOrDefault(z => z.PackageId == id);
        }
    }
}
