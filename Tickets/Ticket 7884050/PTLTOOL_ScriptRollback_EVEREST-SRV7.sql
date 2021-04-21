/*Rollback*/
/************************************************/
/* ticket 7884050								*/
/* Created By: Brenda De Luna					*/
/* Created On: 13/dec/2016						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (2183765)