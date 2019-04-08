namespace ConsignmentStoreApp.EF_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SoldItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        public int SoldBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime SoldDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DiscountAmount { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Item Item { get; set; }
    }
}
