/*rollback*/
/************************************************/
/* ticket 8405846								*/
/* Created By: Brenda De Luna					*/
/* Created On: 27/OCT/2016						*/
/************************************************/



USE [TPRetention]
GO

DElete from [dbo].[CatRetentionAnalyst]
where employeeid in (1048499,833927,943067)



