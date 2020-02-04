using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ISalesmanService
    {
        List<PackageDTO> GetPackages(string description);
        PackageItemDTO GetPackage(int id);
        double CalculateComission(int clientType, int passengers, int nights, List<int> idsPackages);
    }
}
