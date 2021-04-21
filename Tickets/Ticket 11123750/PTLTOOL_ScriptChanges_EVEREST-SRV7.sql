/*Changes*/
/************************************************/
/* ticket 11123750								*/
/* Created By: Brenda De Luna					*/
/* Created On: 25/APR/2016						*/
/************************************************/



USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  (2331662 ,null,1,1052944,GETDATE())