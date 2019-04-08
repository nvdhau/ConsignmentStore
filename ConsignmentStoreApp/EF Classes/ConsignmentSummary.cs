namespace ConsignmentStoreApp.EF_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConsignmentSummary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConsignmentSummary()
        {
            ConsignmentResults = new HashSet<ConsignmentResult>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConsignmentPeriod { get; set; }

        public int NumberOfConsingors { get; set; }

        public int NumberOfConsignedItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalValueOfConsignedItems { get; set; }

        public int NumberOfSoldItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalValueOfSoldItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalValueOfActualSoldValue { get; set; }

        public int NumberOfReturnedItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalValueOfReturnedItems { get; set; }

        public int NumberOfLostItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalValueOfLostItems { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalValueReceivedByConsignors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsignmentResult> ConsignmentResults { get; set; }
    }
}
