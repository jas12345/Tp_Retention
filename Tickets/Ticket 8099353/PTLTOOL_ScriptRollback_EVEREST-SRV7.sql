/*Rollback*/
/************************************************/
/* ticket 8099353								*/
/* Created By: Brenda De Luna					*/
/* Created On: 20/ENE/2017						*/
/************************************************/



USE [TPRetention]


delete from [dbo].[CatRetentionAnalyst]
where EmployeeId in (715952,878471,483799,1003419,873316,1455337,1137810)

