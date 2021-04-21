/*Rollback*/
/************************************************/
/* ticket 10209018 								*/
/* Created By: Brenda De Luna					*/
/* Created On: 13/DIC/2017						*/
/************************************************/
use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (724056)