/*Rollback*/
/************************************************/
/* ticket 8346974								*/
/* Created By: Rubén Zavala			    		*/
/* Created On: 01/03/2017						*/
/************************************************/



use TPRetention

DELETE FROM [dbo].[CatRetentionAnalyst]
WHERE EmployeeId in (831294,
849589,
867312,
672019,
724282,
671984,
671989,
1528098,
1576069,
1527544,
866607,
2119062,
1529678,
870003,
1528142,
1527955,
1547634,
868641,
1626670,
1690125,
1542554,
1999265
)