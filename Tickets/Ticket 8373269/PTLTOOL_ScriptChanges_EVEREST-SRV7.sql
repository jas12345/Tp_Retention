/*Changes*/
/************************************************/
/* ticket 8346974								*/
/* Created By: Rubén Zavala					    */
/* Created On: 01/03/2017						*/
/************************************************/

/*
Retention:
Manuel Alejandro Romero CCMS 836895
*/

USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  
(836895,null,1,1052944,GETDATE())
GO