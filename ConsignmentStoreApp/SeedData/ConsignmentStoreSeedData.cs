using ConsignmentStoreApp.Controller;
using ConsignmentStoreApp.EF_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsignmentStoreApp.SeedData
{
    public class ConsignmentStoreSeedData
    {
        public static void SeedDatabase(ConsignmentStoreEntities context)
        {
            string fileName,
                // path point to SeedData folder
                path = Environment.CurrentDirectory + "\\..\\..\\SeedData\\";
            Random random = new Random();
            StringBuilder sqlCommandBuilder = new StringBuilder("");

            //if employees table has no data, then seed data (1 admin, 9 employees)
            if (!context.Employees.Any())
            {
                //reseed table Employees, make sure Employees id start at 1
                //insert and delete a dummy record, then reseed database
                context.Database.ExecuteSqlCommand(
                    "insert into Employees " +
                        "(EmployeeName, EmployeePhone, EmployeePassword, EmployeeEmail, EmployeeType) " +
                        "values ('', '', '', '', '');" +
                    "delete from Employees;" +
                    "DBCC CHECKIDENT('Employees', RESEED, 0)");

                //seed database by from sql file
                fileName = "seed-employees.sql";
                ExecuteSqlFile(context, path + fileName);
            }


            //if consignors table has no data, then seed data (100 consignors)
            if (!context.Consignors.Any())
            {
                //reseed table Consignors, make sure Consignors id start at 1
                //insert and delete a dummy record, then reseed database
                context.Database.ExecuteSqlCommand(
                    "insert into Consignors " +
                        "(ConsignorName, ConsignorDOB, ConsignorPhone, ConsignorEmail) " +
                        "values ('', '19990909', '', '');" +
                    "delete from Consignors;" +
                    "DBCC CHECKIDENT('Consignors', RESEED, 0)");

                //seed database by from sql file
                fileName = "seed-consignors.sql";
                ExecuteSqlFile(context, path + fileName);
            }

            //if items table has no data, then seed data 
            //(Jan/2019: 1000 items; Feb/2019: 1100 items; Mar/2019: 1200 items; Apr/1/2019 - Apr/7/2019: 500 items;)
            if (!context.Items.Any())
            {
                //reseed table Items, make sure Items id start at 1
                //insert and delete a dummy record, then reseed database
                context.Database.ExecuteSqlCommand(
                    "insert into Items " +
                        "(ConsignorId, ConsignedDate, Price, ItemStatus, ConsignedBy) " +
                        "values (1, '19990909', 1, '', 1);" +
                    "delete from Items;" +
                    "DBCC CHECKIDENT('Items', RESEED, 0)");

                //seed database by from sql file
                fileName = "seed-items.sql";
                ExecuteSqlFile(context, path + fileName);
            }

            //if SoldItems table has no data, then update it by loop through items that has status = "sold"  
            if (!context.SoldItems.Any())
            {
                //update sold_items table
                var soldItems = context.Items.Where(x => x.ItemStatus == "sold").ToList();

                //build insert sql commands for each sold item
                foreach (var item in soldItems)
                {
                    sqlCommandBuilder.AppendLine(
                        string.Format("insert into SoldItems (ItemId, SoldBy, SoldDate, DiscountAmount) " +
                        "values ({0}, {1}, '{2}', {3});",
                        item.ItemId,
                        random.Next(1, 10),//randomly pick an employee
                                           //randomly pick soldDate between its ConsignedDate and 2 days after its ConsignedDate
                        item.ConsignedDate.AddDays(random.Next(0, 2)).ToString("MM/dd/yyyy"),
                        //about 20% sold items get DiscountAmount $5
                        random.Next(0, 9) > 7 ? 5 : 0
                        ));
                }

                //execute sql commands
                context.Database.ExecuteSqlCommand(sqlCommandBuilder.ToString());
                sqlCommandBuilder.Clear();//clear string builder
            }

            decimal consignorConsignmentRatio = ConsignmentStoreBusinessLogic.GetConsignorRatio();//70%
            int consignmentPeriod = 201901;//Jan/2019 an interger of string month,year format "yyyyMM"
            //all consigned items from Jan/2019 have consignment result at Apr,01,2019 (about 2-3 months)
            DateTime startReturningConsignmentResultDate = new DateTime(2019, 04, 01);

            //if ConsignmentSummaries table has no data
            //then update with ConsignmentSummaries of Jan/2019
            if (!context.ConsignmentSummaries.Any())
            {
                //get items that have ConsignedDate in Jan/2019 group by ConsignorId
                var summaryItems = context.Items.Where(item =>
                    item.ConsignedDate > new DateTime(2018, 12, 31) &&
                    item.ConsignedDate < new DateTime(2019, 02, 01)
                    ).GroupBy(item => item.ConsignorId)
                    .Select(group =>
                        new {
                            ConsignorId = group.Key,
                            //number and total value of returned items of a consignor
                            NumberOfReturnedItems = group.Count(item => item.ItemStatus.Trim() == "returned"),
                            TotalValueOfReturnedItems = group.Sum(item => item.ItemStatus.Trim() == "returned" ? item.Price : 0),
                            //number and total value of lost items of a consignor
                            NumberOfLostItems = group.Count(item => item.ItemStatus.Trim() == "lost"),
                            TotalValueOfLostItems = group.Sum(item => item.ItemStatus.Trim() == "lost" ? item.Price : 0),
                            //number and total value of sold items of a consignor
                            NumberOfSoldItems = group.Count(item => item.ItemStatus.Trim() == "sold"),
                            TotalValueOfSoldItems = group.Sum(item => item.ItemStatus.Trim() == "sold" ? item.Price : 0),
                            //total value of discount when selling items of a consignor
                            TotalValueOfDiscount = group.Sum(item => item.ItemStatus.Trim() == "sold" ? item.SoldItem.DiscountAmount : 0),
                            //total value of a consignment result of a consignor (70% consigned prices of items that have status "sold" or "lost")
                            TotalValueReceivedByConsignor = group.Sum(item => (item.ItemStatus.Trim() == "sold" ||
                                item.ItemStatus.Trim() == "lost" ? Math.Floor(item.Price * consignorConsignmentRatio) : 0))
                        }).ToList();

                //add ConsignmentSummary for Jan/2019
                context.ConsignmentSummaries.Add(new ConsignmentSummary
                {
                    ConsignmentPeriod = consignmentPeriod,
                    NumberOfConsingors = summaryItems.Count,
                    //total number and value of consigned items in Jan,2019
                    NumberOfConsignedItems = summaryItems.Sum(group => group.NumberOfLostItems
                            + group.NumberOfReturnedItems + group.NumberOfSoldItems),
                    TotalValueOfConsignedItems = summaryItems.Sum(group => group.TotalValueOfLostItems
                            + group.TotalValueOfReturnedItems + group.TotalValueOfSoldItems),
                    //total number and value of sold items in Jan,2019
                    NumberOfSoldItems = summaryItems.Sum(group => group.NumberOfSoldItems),
                    TotalValueOfSoldItems = summaryItems.Sum(group => group.TotalValueOfSoldItems),
                    //total value of actual sold items in Jan,2019 (Price - DiscountAmount)
                    TotalValueOfActualSoldValue = summaryItems.Sum(group => group.TotalValueOfSoldItems - group.TotalValueOfDiscount),
                    //total number and value of returned items in Jan,2019
                    NumberOfReturnedItems = summaryItems.Sum(group => group.NumberOfReturnedItems),
                    TotalValueOfReturnedItems = summaryItems.Sum(group => group.TotalValueOfReturnedItems),
                    //total number and value of lost items in Jan,2019
                    NumberOfLostItems = summaryItems.Sum(group => group.NumberOfLostItems),
                    TotalValueOfLostItems = summaryItems.Sum(group => group.TotalValueOfLostItems),
                    //total value of money that consignors reiceved for their consignment in Jan,2019
                    TotalValueReceivedByConsignors = summaryItems.Sum(group => group.TotalValueReceivedByConsignor)
                });

                //clear ConsignmentResults table
                context.Database.ExecuteSqlCommand("delete from ConsignmentResults;");
                foreach (var group in summaryItems)
                {//add consignment result for each consignor to ConsignmentResults for Jan/2019
                    context.ConsignmentResults.Add(new ConsignmentResult
                    {
                        ConsignmentPeriod = consignmentPeriod,
                        ConsignorId = group.ConsignorId,
                        //number of lost, returned, sold items of a consignor in consignment period Jan,2019
                        NumberOfLostItems = group.NumberOfLostItems,
                        NumberOfReturnedItems = group.NumberOfReturnedItems,
                        NumberOfSoldItems = group.NumberOfSoldItems,
                        //total value of lost, returned, sold items of a consignor in consignment period Jan,2019
                        TotalValueOfLostItems = group.TotalValueOfLostItems,
                        TotalValueOfReturnedItems = group.TotalValueOfReturnedItems,
                        TotalValueOfSoldItems = group.TotalValueOfSoldItems,
                        //total value a consignor received for his/her consignment in Jan,2019
                        TotalValueReceivedByConsignor = group.TotalValueReceivedByConsignor,
                        //return consignment result date randomly in range (Apr,1,2019 - Apr,7,2019)
                        ReturnedDate = startReturningConsignmentResultDate.AddDays(random.Next(0, 6)),
                        ReturnedBy = random.Next(1, 10)//employee return the consignment result
                    });
                }
                context.SaveChanges();
            }

            //if ExpenseCategories table has no data
            //then add some default category
            if (!context.ExpenseCategories.Any())
            {
                context.ExpenseCategories.AddRange(new List<ExpenseCategory>{
                    new ExpenseCategory{Category = "Salary"},
                    new ExpenseCategory{Category = "Rent"},
                    new ExpenseCategory{Category = "Utilities", Description = "Electricity, Heat (gas), Water"},
                    new ExpenseCategory{Category = "Advertising"},
                    new ExpenseCategory{Category = "Supplies", Description="label, bags, pen ..."},
                    new ExpenseCategory{Category = "Discount", Description="Discount amount when selling items"},
                    new ExpenseCategory{Category = "ConsignmentResult", Description="Money returns to consignors"},
                    new ExpenseCategory{Category = "Others", Description="Not common expense e.g. "},
                });
                context.SaveChanges();
            }

            //if Expenses table has no data
            //then add some default Expenses
            if (!context.Expenses.Any())
            {
                //Populate Discount Expenses from SoldItems table
                foreach (var soldItem in context.SoldItems
                    .Where(item => item.DiscountAmount > 0)//filter only DiscountAmount > 0
                    .OrderBy(item => item.SoldDate))
                {
                    context.Expenses.Add(new Expens
                    {
                        Date = soldItem.SoldDate,//set Discount expense date =  SoldDate
                        Amount = soldItem.DiscountAmount,
                        Category = "Discount"
                    });
                }

                //Populate ConsignmentResult Expenses from ConsignmentResults table
                foreach(var consignmentResult in context.ConsignmentResults
                    .Where(result => result.ReturnedDate != null)//if the consignment result had been returned
                    .OrderBy(result => result.ReturnedDate))
                {
                    context.Expenses.Add(new Expens
                    {//set ConsignmentResult expense date =  ReturnedDate
                        Date = (DateTime) consignmentResult.ReturnedDate,
                        Amount = consignmentResult.TotalValueReceivedByConsignor,
                        Category = "ConsignmentResult"
                    });
                }


                //Monthly Expenses from Jan/2019 to End of Mar/2019
                //For seed data, simply add Expenses at date 28th of each month
                for (int month = 1; month < 4; month++)
                {
                    context.Expenses.AddRange(new List<Expens>
                    {
                        new Expens{Date = new DateTime(2019,month,28), Category="Salary", Amount=3000},
                        new Expens{Date = new DateTime(2019,month,28), Category="Rent", Amount=2000},
                        new Expens{Date = new DateTime(2019,month,28), Category="Utilities", Amount=random.Next(100,300)},
                        new Expens{Date = new DateTime(2019,month,28), Category="Advertising", Amount=random.Next(100,200)},
                        new Expens{Date = new DateTime(2019,month,28), Category="Supplies", Amount=random.Next(50,200)},
                        new Expens{Date = new DateTime(2019,month,28), Category="Others", Amount=random.Next(50,200)},
                    });
                }
                context.SaveChanges();
            }

            //if Overviews table has no data
            //populate Overviews data for each date
            if (!context.Overviews.Any())
            {
                //Starting point Dec,31,2018 starting budget $5000
                Overview previousOverview = new Overview
                {
                    Date = new DateTime(2018, 12, 31),
                    Budget = 5000,
                    ClientAsset = 0,
                    UsableBudget = 5000,
                    TotalIncome = 0,
                    TotalExpense = 0,
                    IncomeOfDate = 0,
                    ExpenseOfDate = 0
                };

                context.Overviews.Add(previousOverview);

                //Business begin at Jan,1,2019
                DateTime businessDate = new DateTime(2019, 1, 1);

                decimal incomeOfDate, expenseOfDate, incomeClientAssetOfDate, expenseClientAssetOfDate, budget, clientAsset;

                while (businessDate <= DateTime.Now.Date)
                {
                    //compute total income and expense of the businessDate
                    incomeOfDate = context.SoldItems.Sum(soldItem => soldItem.SoldDate == businessDate ? soldItem.Item.Price : 0);
                    expenseOfDate = context.Expenses.Sum(expense => expense.Date == businessDate ? expense.Amount : 0);
                    //compute total incomeClientAsset and expenseClientAsset of the businessDate
                    //when an item was sold 70% of its price go to clientAsset
                    //when a consignor get his/her consignment result, then the value of the consignment result go out of clientAssetOfDate 
                    incomeClientAssetOfDate = context.SoldItems.Sum(soldItem => soldItem.SoldDate == businessDate ? 
                                                            Math.Floor(soldItem.Item.Price * consignorConsignmentRatio) : 0);
                    expenseClientAssetOfDate = context.Expenses.Sum(expense =>
                                                            expense.Category.Trim() == "ConsignmentResult" &&
                                                            expense.Date == businessDate ? expense.Amount : 0);
                    budget = previousOverview.Budget + incomeOfDate - expenseOfDate;
                    //compute current clientAsset
                    clientAsset = previousOverview.ClientAsset + incomeClientAssetOfDate - expenseClientAssetOfDate;

                    Overview todayOverview = new Overview
                    {
                        Date = businessDate,//the date
                        Budget = budget,//current budget of the date
                        ClientAsset = clientAsset,//current clientAsset of the date
                        UsableBudget = budget -  clientAsset,//compute UsableBudget that is budget - clientAsset
                        TotalIncome = previousOverview.TotalIncome + incomeOfDate,//total income at the beginning
                        TotalExpense = previousOverview.TotalExpense + expenseOfDate,//total expense at the beginning
                        IncomeOfDate = incomeOfDate,//total income of the date
                        ExpenseOfDate = expenseOfDate//total expense of the date
                    };

                    context.Overviews.Add(todayOverview);//add todayOverview

                    previousOverview = todayOverview;//save previousOverview as todayOverview

                    businessDate = businessDate.AddDays(1);//next day
                }
                context.SaveChanges();
            }
        }

        //Execute sql commands from a sql file
        public static void ExecuteSqlFile(ConsignmentStoreEntities context, string filePath)
        {
            StreamReader sqlFile;

            try
            {
                // Read the file and execute sql command line by line.  
                sqlFile = new StreamReader(filePath);

                //execute all sql commands
                context.Database.ExecuteSqlCommand(sqlFile.ReadToEnd());

                sqlFile.Close();//close file
            }
            catch (Exception)
            {
                Console.WriteLine("ConsignmentStoreSeedData: error when read and execute sql command from file "
                    + filePath);
            }
        }
    }
}
