/*Rollback*/
/************************************************/
/* ticket 9740027 								*/
/* Created By: Brenda De Luna					*/
/* Created On: 02/OCT/2017						*/
/************************************************/

use [TPRetention]

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (771812)