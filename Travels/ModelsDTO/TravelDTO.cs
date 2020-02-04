using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDTO
{
    public class TravelDTO
    {
        public int clientType { get; set; }
        public int passengers { get; set; }
        public int nights { get; set; }
        public List<int> idsPackages { get; set; }
    }
}
