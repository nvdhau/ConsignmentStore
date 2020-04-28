namespace ConsignmentStoreApp.EF_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Xml.Serialization;

    public partial class ConsignmentResult
    {
        [DisplayName("Consignor ID")]
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConsignorId { get; set; }

        [DisplayName("Consignment Period")]
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConsignmentPeriod { get; set; }

        [DisplayName("Returned Items")]
        public int NumberOfReturnedItems { get; set; }

        [DisplayName("Returned Items Value")]
        [Column(TypeName = "money")]
        public decimal TotalValueOfReturnedItems { get; set; }

        [DisplayName("Lost Items")]
        public int NumberOfLostItems { get; set; }

        [DisplayName("Lost Items Value")]
        [Column(TypeName = "money")]
        public decimal TotalValueOfLostItems { get; set; }

        [DisplayName("Sold Items")]
        public int NumberOfSoldItems { get; set; }

        [DisplayName("Sold Items Value")]
        [Column(TypeName = "money")]
        public decimal TotalValueOfSoldItems { get; set; }

        [DisplayName("Consignor Received Value")]
        [Column(TypeName = "money")]
        public decimal TotalValueReceivedByConsignor { get; set; }

        [DisplayName("Returned Date")]
        [Column(TypeName = "date")]
        public DateTime? ReturnedDate { get; set; }

        [DisplayName("Returned By")]
        public int? ReturnedBy { get; set; }

        [XmlIgnore]
        public virtual ConsignmentSummary ConsignmentSummary { get; set; }

        [XmlIgnore]
        public virtual Consignor Consignor { get; set; }

        [XmlIgnore]
        public virtual Employee Employee { get; set; }
    }
}
