namespace ConsignmentStoreApp.EF_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Overview")]
    public partial class Overview
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [Column(TypeName = "money")]
        public decimal ClientAsset { get; set; }

        [Column(TypeName = "money")]
        public decimal UsableBudget { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalIncome { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal IncomeOfDate { get; set; }

        [Column(TypeName = "money")]
        public decimal ExpenseOfDate { get; set; }
    }
}
