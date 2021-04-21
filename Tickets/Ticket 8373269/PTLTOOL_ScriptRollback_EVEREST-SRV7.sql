/*Rollback*/
/************************************************/
/* ticket 8346974								*/
/* Created By: Rubén Zavala			    		*/
/* Created On: 01/03/2017						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId = 836895