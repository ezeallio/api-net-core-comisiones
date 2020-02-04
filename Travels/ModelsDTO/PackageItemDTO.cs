using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDTO
{
    public class PackageItemDTO
    {
        public int PackageId { get; set; }
        public string Description { get; set; }

        public IList<ItemDTO> Items { get; set; }
    }
}
