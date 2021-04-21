/*rollback*/
/************************************************/
/* ticket 8450604								*/
/* Created By: Brenda De Luna					*/
/* Created On: 14/MAR/2017						*/
/************************************************/



USE [TPRetention]
GO

DElete from [dbo].[CatRetentionAnalyst]
where employeeid in (2417477)
