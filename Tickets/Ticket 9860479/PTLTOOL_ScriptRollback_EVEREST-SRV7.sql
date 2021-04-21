/*Rollback*/
/************************************************/
/* ticket 9860479 								*/
/* Created By: Brenda De Luna					*/
/* Created On: 10/OCT/2017						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (1795442)