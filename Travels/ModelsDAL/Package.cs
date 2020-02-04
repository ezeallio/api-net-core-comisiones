using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsDAL
{
    public class Package
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PackageId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PackageItem> PackageItems { get; set; }
    }
}
