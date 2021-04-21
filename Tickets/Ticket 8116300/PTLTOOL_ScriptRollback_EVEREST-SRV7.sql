/*Rollback*/
/************************************************/
/* ticket 8116300								*/
/* Created By: Brenda De Luna					*/
/* Created On: 20/ENE/2017						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (2104546)