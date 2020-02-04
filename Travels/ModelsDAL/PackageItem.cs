using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsDAL
{
    public class PackageItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PackageItemId { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
