/*Rollback*/
/************************************************/
/* ticket 7946959								*/
/* Created By: Brenda De Luna					*/
/* Created On: 26/dec/2016						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (1420427,1045826)