/*Changes*/
/************************************************/
/* ticket 8734333								*/
/* Created By: Brenda De Luna					*/
/* Created On: 27/ABR/2017						*/
/************************************************/



USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  (2124004,null,1,1052944,GETDATE()),
(2306447,null,1,1052944,GETDATE())
GO

