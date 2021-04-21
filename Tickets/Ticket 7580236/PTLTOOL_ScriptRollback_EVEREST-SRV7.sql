/*Rollback*/
/************************************************/
/* ticket 7568447								*/
/* Created By: Brenda De Luna					*/
/* Created On: 27/OCT/2016						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (384744,666018)