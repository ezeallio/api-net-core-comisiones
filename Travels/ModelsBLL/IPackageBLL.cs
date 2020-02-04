using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsBLL
{
    public interface IPackageBLL
    {
        List<PackageDTO> GetPackages(string description);
        PackageItemDTO GetPackage(int id);
    }
}
