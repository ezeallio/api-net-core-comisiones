using System;
using System.Collections.Generic;
using System.Text;
using ModelsBLL;
using ModelsDAL;
using ModelsDTO;

namespace Services
{
    public class SalesmanService : ISalesmanService
    {
        private readonly IPackageBLL _packageBLL;
        private readonly ISalesmanBLL _salesmanBLL;

        public SalesmanService(IPackageBLL packageBLL, ISalesmanBLL salesmanBLL)
        {
            _packageBLL = packageBLL;
            _salesmanBLL = salesmanBLL;
        }

        public List<PackageDTO> GetPackages(string description)
            => _packageBLL.GetPackages(description);

        public PackageItemDTO GetPackage(int id)
            => _packageBLL.GetPackage(id);

        public double CalculateComission(int clientType, int passengers, int nights, List<int> idsPackages)
            => _salesmanBLL.Calculate(clientType, passengers, nights, idsPackages);
    }
}
