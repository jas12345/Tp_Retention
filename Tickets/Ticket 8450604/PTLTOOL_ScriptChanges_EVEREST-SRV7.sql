/*Changes*/
/************************************************/
/* ticket 8450604								*/
/* Created By: Brenda De Luna					*/
/* Created On: 14/MAR/2017						*/
/************************************************/



USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  (2417477,null,1,1052944,GETDATE())