CREATE TABLE [dbo].[Employees]
(
	[EmployeeId] INT NOT NULL PRIMARY KEY IDENTITY,
	[EmployeeName] NVARCHAR(50) NOT NULL, 
    [EmployeePhone] NCHAR(15) NOT NULL UNIQUE, 
    [EmployeeEmail] NVARCHAR(50) NOT NULL UNIQUE,
	[EmployeePassword] NVARCHAR(50) NOT NULL, 
    [EmployeeType] NCHAR(10) NOT NULL DEFAULT 'employee', 
)
