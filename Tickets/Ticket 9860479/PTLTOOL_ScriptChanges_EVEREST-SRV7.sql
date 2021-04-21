/*Changes*/
/************************************************/
/* ticket 9860479								*/
/* Created By: Brenda De Luna					*/
/* Created On: 27/OCT/2016						*/
/************************************************/



USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  (1795442,null,1,1052944,GETDATE())
GO
