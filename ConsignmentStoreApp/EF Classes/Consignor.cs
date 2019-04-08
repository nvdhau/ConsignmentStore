namespace ConsignmentStoreApp.EF_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Consignor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Consignor()
        {
            ConsignmentResults = new HashSet<ConsignmentResult>();
            Items = new HashSet<Item>();
        }

        public int ConsignorId { get; set; }

        [Required]
        [StringLength(50)]
        public string ConsignorName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ConsignorDOB { get; set; }

        [StringLength(15)]
        public string ConsignorPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string ConsignorEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsignmentResult> ConsignmentResults { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
