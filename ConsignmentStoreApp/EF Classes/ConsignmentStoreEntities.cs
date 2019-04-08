namespace ConsignmentStoreApp.EF_Classes
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConsignmentStoreEntities : DbContext
    {
        public ConsignmentStoreEntities()
            : base("name=ConsignmentStoreConnection")
        {
        }

        public virtual DbSet<ConsignmentResult> ConsignmentResults { get; set; }
        public virtual DbSet<ConsignmentSummary> ConsignmentSummaries { get; set; }
        public virtual DbSet<Consignor> Consignors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public virtual DbSet<Expens> Expenses { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Overview> Overviews { get; set; }
        public virtual DbSet<SoldItem> SoldItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsignmentResult>()
                .Property(e => e.TotalValueOfReturnedItems)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentResult>()
                .Property(e => e.TotalValueOfLostItems)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentResult>()
                .Property(e => e.TotalValueOfSoldItems)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentResult>()
                .Property(e => e.TotalValueReceivedByConsignor)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentSummary>()
                .Property(e => e.TotalValueOfConsignedItems)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentSummary>()
                .Property(e => e.TotalValueOfSoldItems)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentSummary>()
                .Property(e => e.TotalValueOfActualSoldValue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentSummary>()
                .Property(e => e.TotalValueOfReturnedItems)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentSummary>()
                .Property(e => e.TotalValueOfLostItems)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentSummary>()
                .Property(e => e.TotalValueReceivedByConsignors)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ConsignmentSummary>()
                .HasMany(e => e.ConsignmentResults)
                .WithRequired(e => e.ConsignmentSummary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Consignor>()
                .Property(e => e.ConsignorPhone)
                .IsFixedLength();

            modelBuilder.Entity<Consignor>()
                .HasMany(e => e.ConsignmentResults)
                .WithRequired(e => e.Consignor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Consignor>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Consignor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeePhone)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeType)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ConsignmentResults)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.ReturnedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.ConsignedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.SoldItems)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.SoldBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExpenseCategory>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseCategory>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseCategory>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.ExpenseCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expens>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Expens>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Expens>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemStatus)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .HasOptional(e => e.SoldItem)
                .WithRequired(e => e.Item);

            modelBuilder.Entity<Overview>()
                .Property(e => e.Budget)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Overview>()
                .Property(e => e.ClientAsset)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Overview>()
                .Property(e => e.UsableBudget)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Overview>()
                .Property(e => e.TotalIncome)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Overview>()
                .Property(e => e.TotalExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Overview>()
                .Property(e => e.IncomeOfDate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Overview>()
                .Property(e => e.ExpenseOfDate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SoldItem>()
                .Property(e => e.DiscountAmount)
                .HasPrecision(8, 2);
        }
    }
}
