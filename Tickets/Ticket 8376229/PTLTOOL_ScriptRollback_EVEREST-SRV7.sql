/*Rollback*/
/************************************************/
/* ticket 8346974								*/
/* Created By: Rubén Zavala			    		*/
/* Created On: 06/03/2017						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId = 942118