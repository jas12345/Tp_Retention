/*Changes*/
/************************************************/
/* ticket 8405846								*/
/* Created By: Brenda De Luna					*/
/* Created On: 27/OCT/2016						*/
/************************************************/



USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  (1048499,null,1,1052944,GETDATE()),
(833927,null,1,1052944,GETDATE()),
(943067,null,1,1052944,GETDATE())
GO


