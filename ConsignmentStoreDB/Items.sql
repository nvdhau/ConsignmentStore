CREATE TABLE [dbo].[Items]
(
	[ItemId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ConsignorId] INT NOT NULL, 
    [ConsignedDate] DATE NOT NULL, 
    [Price] NUMERIC(8, 2) NOT NULL, 
    [ItemStatus] NCHAR(10) NOT NULL, 
    [ConsignedBy] INT NOT NULL,
	CONSTRAINT [FK_Item_To_Consignor] FOREIGN KEY ([ConsignorId]) REFERENCES [Consignors]([ConsignorId]),
	CONSTRAINT [FK_Item_To_Employee] FOREIGN KEY ([ConsignedBy]) REFERENCES [Employees]([EmployeeId])
)
