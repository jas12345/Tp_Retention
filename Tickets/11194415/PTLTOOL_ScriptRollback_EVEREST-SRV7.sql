/*rollback*/
/************************************************/
/* ticket 11194415 								*/
/* Created By: Brenda De Luna					*/
/* Created On: 02/MAY/2018						*/
/************************************************/



USE [TPRetention]
GO

DElete from [dbo].[CatRetentionAnalyst]
where employeeid in (1167201)
