CREATE TABLE [dbo].[SoldItems]
(
	[ItemId] INT NOT NULL PRIMARY KEY, 
    [SoldBy] INT NOT NULL, 
    [SoldDate] DATE NOT NULL, 
    [DiscountAmount] NUMERIC(8, 2) NOT NULL DEFAULT 0.00,
	CONSTRAINT [FK_SoldItem_To_Item] FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId]),
	CONSTRAINT [FK_SoldItem_To_Employee] FOREIGN KEY (SoldBy) REFERENCES [Employees]([EmployeeId])
)
