CREATE TABLE [dbo].[Overview]
(
	[Date] DATE NOT NULL PRIMARY KEY, 
    [Budget] MONEY NOT NULL, 
    [ClientAsset] MONEY NOT NULL, 
    [UsableBudget] MONEY NOT NULL, 
    [TotalIncome] MONEY NOT NULL, 
    [TotalExpense] MONEY NOT NULL, 
    [IncomeOfDate] MONEY NOT NULL, 
    [ExpenseOfDate] MONEY NOT NULL
)
