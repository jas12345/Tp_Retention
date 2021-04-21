/*Changes*/
/************************************************/
/* Ticket 9938467								*/
/* Created By: Jorge Gzz     					*/
/* Created On: 31/OCT/2017						*/
/************************************************/

USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  (119109,null,1,1077811,GETDATE())