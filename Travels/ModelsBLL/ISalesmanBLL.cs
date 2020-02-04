using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsBLL
{
    public interface ISalesmanBLL
    {
        double Calculate(int cType, int passengers, int nights, List<int> idsPackages);
    }
}
