using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsDAL
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ItemId { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
        public virtual ICollection<PackageItem> PackageItems { get; set; }
    }
}
