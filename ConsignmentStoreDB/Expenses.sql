CREATE TABLE [dbo].[Expenses]
(
	[ExpenseId] INT NOT NULL PRIMARY KEY, 
    [Date] DATE NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [Category] VARCHAR(100) NOT NULL, 
    [Note] TEXT NULL,
	CONSTRAINT [FK_Expense_To_ExpenseCategory] FOREIGN KEY ([Category]) REFERENCES [ExpenseCategories]([Category])
)
