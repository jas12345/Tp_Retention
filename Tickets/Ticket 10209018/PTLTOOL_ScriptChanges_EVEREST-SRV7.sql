/*Changes*/
/************************************************/
/* ticket 10209018 								*/
/* Created By: Brenda De Luna					*/
/* Created On: 13/DIC/2017						*/
/************************************************/



USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  (724056,null,1,1183686,GETDATE())
GO
