/*rollback*/
/************************************************/
/* ticket 11123750 								*/
/* Created By: Brenda De Luna					*/
/* Created On: 25/APR/2016						*/
/************************************************/



USE [TPRetention]
GO

DElete from [dbo].[CatRetentionAnalyst]
where employeeid in (2331662)
