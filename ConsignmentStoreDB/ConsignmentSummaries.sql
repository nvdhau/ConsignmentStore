CREATE TABLE [dbo].[ConsignmentSummaries]
(
	[ConsignmentPeriod] INT NOT NULL PRIMARY KEY, 
    [NumberOfConsingors] INT NOT NULL, 
    [NumberOfConsignedItems] INT NOT NULL, 
    [TotalValueOfConsignedItems] MONEY NOT NULL, 
    [NumberOfSoldItems] INT NOT NULL, 
    [TotalValueOfSoldItems] MONEY NOT NULL, 
    [TotalValueOfActualSoldValue] MONEY NOT NULL, 
    [NumberOfReturnedItems] INT NOT NULL , 
    [TotalValueOfReturnedItems] MONEY NOT NULL , 
    [NumberOfLostItems] INT NOT NULL DEFAULT 0, 
    [TotalValueOfLostItems] MONEY NOT NULL DEFAULT 0.0, 
    [TotalValueReceivedByConsignors] MONEY NULL
)
