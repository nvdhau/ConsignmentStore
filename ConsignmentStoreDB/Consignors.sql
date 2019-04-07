CREATE TABLE [dbo].[Consignors]
(
	[ConsignorId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ConsignorName] NVARCHAR(50) NOT NULL, 
    [ConsignorDOB] DATE NULL, 
    [ConsignorPhone] NCHAR(15) NULL UNIQUE, 
    [ConsignorEmail] NVARCHAR(50) NOT NULL UNIQUE
)

