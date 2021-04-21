/*Rollback*/
/************************************************/
/* ticket 9639928								*/
/* Created By: Brenda De Luna					*/
/* Created On: 24/Oct/2017						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (1771812)