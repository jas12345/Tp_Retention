UPDATE 
[dbo].[CatRetentionAnalyst]
set Active = 0, [DeactivatedBy] = 1362202, [DeactivationDate] = GETDATE()
WHERE [EmployeeId] = 119759