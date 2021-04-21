/*Rollback*/
/************************************************/
/* ticket 8734333								*/
/* Created By: Brenda De Luna					*/
/* Created On: 27/ABR/2017						*/
/************************************************/


use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (2124004,2306447)