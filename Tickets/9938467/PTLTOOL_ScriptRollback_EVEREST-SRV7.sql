/*Rollback*/
/************************************************/
/* Ticket 9938467								*/
/* Created By: Jorge Gzz     					*/
/* Created On: 31/OCT/2017						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (119109)
