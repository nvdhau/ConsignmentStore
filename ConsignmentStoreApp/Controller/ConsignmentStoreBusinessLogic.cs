using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using ConsignmentStoreApp.EF_Classes;
using System.Data.Entity;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsignmentStoreApp.Controller
{
    public static class ConsignmentStoreBusinessLogic
    {
        //error codes
        public const int VALID = 1;
        public const int INVALID = -1;
        public const int INVALID_EMAIL = -2;
        public const int INVALID_PASSWORD = -3;

        //messages
        public const string ADD_SUCCESS = "ADD_SUCCESS";
        public const string ADD_FAIL = "ADD_FAIL";
        public const string UPDATE_SUCCESS = "UPDATE_SUCCESS";
        public const string UPDATE_FAIL = "UPDATE_FAIL";

        //item states
        public const string ITEM_STATUS_UNSOLD = "unsold";
        public const string ITEM_STATUS_SOLD = "sold";
        public const string ITEM_STATUS_LOST = "lost";
        public const string ITEM_STATUS_RETURNED = "returned";

        public static ConsignmentStoreEntities context = new ConsignmentStoreEntities();
        public static Employee loggedInEmployee;//current logged in employee

        public static decimal GetConsignorRatio()
        {
            return 1 - decimal.Parse(ConfigurationManager.AppSettings.Get("ConsignmentFee"));
        }

        public static int Authenticate(string email, string password) 
        {
            Employee loginEmployee = context.Employees.Where(employee => employee.EmployeeEmail.Trim() == email).FirstOrDefault();

            if(loginEmployee == null)
            {//invalid email
                return INVALID_EMAIL;
            }
            else if(loginEmployee.EmployeePassword != password)
            {//incorrect password
                return INVALID_PASSWORD;
            }
            else
            {//valid email and password
                loggedInEmployee = loginEmployee;
                return VALID;
            }
        }

        public static string AddConsignor(Consignor consignor)
        {
            context.Consignors.Add(consignor);

            try
            {
                if(context.SaveChanges() > 0)
                {
                    return ADD_SUCCESS;
                }
                else
                {
                    return ADD_FAIL;
                } 
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        //string format "month/year"
        public static int GetConsignmentPeriodFromString(string monthYearStr)
        {
            string[] monthYear = monthYearStr.Split('/');
            return  int.Parse(monthYear[0]) + int.Parse(monthYear[1]) * 100;
        }

        //consignmentPeriod is and integer with format yyyymm
        public static string GetConsignmentPeriodFromInt(int period)
        {
            return string.Format("{0}/{1}", period % 100, period / 100);
        }

        //consignment period must 
        //1. must be greater than the last consignmentPeriod (e.g. current is 201901)
        //2. must less than current month (e.g. 201904)
        //e.g valid consignmentPeriods can be 201902, 201903
        public static bool ValidateConsignmentPeriod(int consignmentPeriod)
        {
            //last consignmentPeriod
            int downLimitConsignmentPeriod = context.ConsignmentSummaries.Max(summary => summary.ConsignmentPeriod);

            //current month so cannot generate consignment results
            int upLimitConsignmentPeriod = GetConsignmentPeriodFromString(DateTime.Now.Month + "/" + DateTime.Now.Year);

            return consignmentPeriod > downLimitConsignmentPeriod && consignmentPeriod < upLimitConsignmentPeriod;
        }


        public static bool GenerateConsignmentResultsForPeriod(int consignmentPeriod)
        {
            if (!ValidateConsignmentPeriod(consignmentPeriod))
            {
                return false;
            }

            decimal consignorRatio = GetConsignorRatio();

            //generate summary of all items in consignmentPeriod
            var summaryItems = context.Items.Where(item =>
                    item.ConsignedDate.Month == consignmentPeriod % 100 &&
                    item.ConsignedDate.Year == consignmentPeriod / 100)
                    .GroupBy(item => item.ConsignorId)
                    .Select(group =>
                        new
                        {
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
                                item.ItemStatus.Trim() == "lost" ? Math.Floor(item.Price * consignorRatio) : 0))
                        }).ToList();

            //add ConsignmentSummary 
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
                    TotalValueReceivedByConsignor = group.TotalValueReceivedByConsignor
                    //return consignment result date randomly in range (Apr,1,2019 - Apr,7,2019
                });
            }

            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        //Update Overview table to today 
        public static bool UpdateOverview()
        {
            decimal incomeOfDate, expenseOfDate, incomeClientAssetOfDate, expenseClientAssetOfDate, budget, clientAsset;
            decimal consignorRatio = GetConsignorRatio();

            //get last overview
            Overview previousOverview = context.Overviews.Local.OrderByDescending(o => o.Date).Take(1).ToArray()[0];

            if(previousOverview.Date.Date == DateTime.Now.Date)
            {//do update
                Overview todayOverview = previousOverview;
                previousOverview = context.Overviews.Local.Single(overview => overview.Date == todayOverview.Date.AddDays(-1));

                //compute total income and expense of  today
                incomeOfDate = context.SoldItems.Sum(soldItem => soldItem.SoldDate == todayOverview.Date ? soldItem.Item.Price : 0);
                expenseOfDate = context.Expenses.Sum(expense => expense.Date == todayOverview.Date ? expense.Amount : 0);
                //compute total incomeClientAsset and expenseClientAsset of today
                //when an item was sold 70% of its price go to clientAsset
                //when a consignor get his/her consignment result, then the value of the consignment result go out of clientAssetOfDate 
                incomeClientAssetOfDate = context.SoldItems.Sum(soldItem => soldItem.SoldDate == todayOverview.Date ?
                                                        Math.Floor(soldItem.Item.Price * consignorRatio) : 0);
                expenseClientAssetOfDate = context.Expenses.Sum(expense =>
                                                        expense.Category.Trim() == "ConsignmentResult" &&
                                                        expense.Date == todayOverview.Date ? expense.Amount : 0);
                budget = previousOverview.Budget + incomeOfDate - expenseOfDate;
                //compute current clientAsset
                clientAsset = previousOverview.ClientAsset + incomeClientAssetOfDate - expenseClientAssetOfDate;

                //update
                todayOverview.Budget = budget;//current budget of the date
                todayOverview.ClientAsset = clientAsset;//current clientAsset of the date
                todayOverview.UsableBudget = budget - clientAsset;//compute UsableBudget that is budget - clientAsset
                todayOverview.TotalIncome = previousOverview.TotalIncome + incomeOfDate;//total income at the beginning
                todayOverview.TotalExpense = previousOverview.TotalExpense + expenseOfDate;//total expense at the beginning
                todayOverview.IncomeOfDate = incomeOfDate;//total income of the date
                todayOverview.ExpenseOfDate = expenseOfDate;//total expense of the date

                try
                {//update database
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
           

            //get next day
            DateTime businessDate = previousOverview.Date.AddDays(1);


            while (businessDate <= DateTime.Now)
            {
                //compute total income and expense of the businessDate
                incomeOfDate = context.SoldItems.Sum(soldItem => soldItem.SoldDate == businessDate ? soldItem.Item.Price : 0);
                expenseOfDate = context.Expenses.Sum(expense => expense.Date == businessDate ? expense.Amount : 0);
                //compute total incomeClientAsset and expenseClientAsset of the businessDate
                //when an item was sold 70% of its price go to clientAsset
                //when a consignor get his/her consignment result, then the value of the consignment result go out of clientAssetOfDate 
                incomeClientAssetOfDate = context.SoldItems.Sum(soldItem => soldItem.SoldDate == businessDate ?
                                                        Math.Floor(soldItem.Item.Price * consignorRatio) : 0);
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
                    UsableBudget = budget - clientAsset,//compute UsableBudget that is budget - clientAsset
                    TotalIncome = previousOverview.TotalIncome + incomeOfDate,//total income at the beginning
                    TotalExpense = previousOverview.TotalExpense + expenseOfDate,//total expense at the beginning
                    IncomeOfDate = incomeOfDate,//total income of the date
                    ExpenseOfDate = expenseOfDate//total expense of the date
                };

                context.Overviews.Add(todayOverview);//add todayOverview

                previousOverview = todayOverview;//save previousOverview as todayOverview

                businessDate = businessDate.AddDays(1);//next day
            }

            try
            {//update database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

    }
}
