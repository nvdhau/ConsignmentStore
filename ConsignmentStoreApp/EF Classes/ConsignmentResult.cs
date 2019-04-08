namespace ConsignmentStoreApp.EF_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConsignmentResult
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConsignorId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConsignmentPeriod { get; set; }

        public int NumberOfReturnedItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalValueOfReturnedItems { get; set; }

        public int NumberOfLostItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalValueOfLostItems { get; set; }

        public int NumberOfSoldItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalValueOfSoldItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalValueReceivedByConsignor { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReturnedDate { get; set; }

        public int? ReturnedBy { get; set; }

        public virtual ConsignmentSummary ConsignmentSummary { get; set; }

        public virtual Consignor Consignor { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
