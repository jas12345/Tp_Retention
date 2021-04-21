/*Changes*/
/************************************************/
/* ticket 11194415 								*/
/* Created By: Brenda De Luna					*/
/* Created On: 02/MAY/2018						*/
/************************************************/



USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  (1167201 ,null,1,1052944,GETDATE())