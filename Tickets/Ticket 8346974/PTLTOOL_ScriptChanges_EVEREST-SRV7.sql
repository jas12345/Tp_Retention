/*Changes*/
/************************************************/
/* ticket 8346974								*/
/* Created By: Rubén Zavala					    */
/* Created On: 01/03/2017						*/
/************************************************/

/*
Retention:

831294	Delgado Araya, Rebeca
849589	Aguilar Bustamante, Gabriel E
867312	Garcia Vargas, Lidier
672019	Castro Valverde, Diego
724282	Solis Barboza, Aaron J
671984	Masis Mora, Maria A
671989	Arce Espinoza, Yendry M
1528098	Fuentes Ramirez, Jorge H
1576069	Gonzalez Gonzalez, Roger G
1527544	Lopez Alvarez, Alma V
866607	Barrientos Rojas, Kenneth J
2119062	Rivera Moscatelli, Jesus A
1529678	Rojas Hernandez, Melissa D
870003	Coto Colomer, Monica M
1528142	Sage Hernandez, Max D
1527955	Lacayo Mejia, Jaime A
1547634	Solorzano Sancho, Natalia M
868641	Jimenez Diaz, Ronny
1626670	Maria Rojas Carvajal
1690125	Cristy Garbanzo Guerrero
1542554	Valeria Quesada
1999265	Catalina Salazar Sanchez
*/

USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]([EmployeeId],[SiteId],[Active],[CreatedBy],[CreatedDate])
VALUES  
(831294,null,1,1052944,GETDATE()),
(849589,null,1,1052944,GETDATE()),
(867312,null,1,1052944,GETDATE()),
(672019,null,1,1052944,GETDATE()),
(724282,null,1,1052944,GETDATE()),
(671984,null,1,1052944,GETDATE()),
(671989,null,1,1052944,GETDATE()),
(1528098,null,1,1052944,GETDATE()),
(1576069,null,1,1052944,GETDATE()),
(1527544,null,1,1052944,GETDATE()),
(866607,null,1,1052944,GETDATE()),
(2119062,null,1,1052944,GETDATE()),
(1529678,null,1,1052944,GETDATE()),
(870003,null,1,1052944,GETDATE()),
(1528142,null,1,1052944,GETDATE()),
(1527955,null,1,1052944,GETDATE()),
(1547634,null,1,1052944,GETDATE()),
(868641,null,1,1052944,GETDATE()),
(1626670,null,1,1052944,GETDATE()),
(1690125,null,1,1052944,GETDATE()),
(1542554,null,1,1052944,GETDATE()),
(1999265,null,1,1052944,GETDATE())

GO