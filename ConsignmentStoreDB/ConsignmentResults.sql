CREATE TABLE [dbo].[ConsignmentResults]
(
	[ConsignorId] INT NOT NULL, 
    [ConsignmentPeriod] INT NOT NULL,
	[NumberOfReturnedItems] INT NOT NULL , 
    [TotalValueOfReturnedItems] MONEY NOT NULL , 
	[NumberOfLostItems] INT NOT NULL DEFAULT 0, 
    [TotalValueOfLostItems] MONEY NOT NULL DEFAULT 0.0,  
    [NumberOfSoldItems] INT NOT NULL, 
    [TotalValueOfSoldItems] MONEY NOT NULL, 
    [TotalValueReceivedByConsignor] MONEY NOT NULL,
	[ReturnedDate] DATE NULL, 
    [ReturnedBy] INT NULL, 
    PRIMARY KEY([ConsignorId], [ConsignmentPeriod]),
	CONSTRAINT [FK_ConsignmentResult_To_Consignor] FOREIGN KEY ([ConsignorId]) REFERENCES [Consignors]([ConsignorId]),
	CONSTRAINT [FK_ConsignmentResult_To_ConsignmentSummary] FOREIGN KEY ([ConsignmentPeriod]) REFERENCES [ConsignmentSummaries]([ConsignmentPeriod]),
	CONSTRAINT [FK_ConsignmentResult_To_Employee] FOREIGN KEY ([ReturnedBy]) REFERENCES [Employees]([EmployeeId])
)
