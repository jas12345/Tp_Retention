/*Changes*/
/************************************************/
/* ticket 8346974								*/
/* Created By: Rubén Zavala					    */
/* Created On: 06/03/2017						*/
/************************************************/

/*
Retention:
942118
*/

USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  
(942118,null,1,1362202,GETDATE())
GO