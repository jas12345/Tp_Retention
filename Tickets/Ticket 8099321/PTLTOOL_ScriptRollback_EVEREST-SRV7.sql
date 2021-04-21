/*Rollback*/
/************************************************/
/* ticket 8099321								*/
/* Created By: Brenda De Luna					*/
/* Created On: 18/ENE/2017						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (428653)