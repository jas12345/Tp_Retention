/*Rollback*/
/************************************************/
/* ticket 8860073								*/
/* Created By: Brenda De Luna					*/
/* Created On: 05/JUN/2017						*/
/************************************************/



USE [TPRetention]


delete from [dbo].[CatRetentionAnalyst]
where employeeid=877741