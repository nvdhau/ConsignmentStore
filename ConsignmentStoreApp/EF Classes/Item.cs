namespace ConsignmentStoreApp.EF_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        public int ItemId { get; set; }

        public int ConsignorId { get; set; }

        [Column(TypeName = "date")]
        public DateTime ConsignedDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(10)]
        public string ItemStatus { get; set; }

        public int ConsignedBy { get; set; }

        public virtual Consignor Consignor { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual SoldItem SoldItem { get; set; }
    }
}
