/*Changes*/
/************************************************/
/* ticket 7568447								*/
/* Created By: Brenda De Luna					*/
/* Created On: 27/OCT/2016						*/
/************************************************/



USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  (384744,null,1,1052944,GETDATE()),
(666018,null,1,1052944,GETDATE())
GO


