USE [TPRetention]
GO

INSERT INTO [dbo].[CatRetentionAnalyst]
           ([EmployeeId]
           ,[SiteId]
           ,[Active]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DeactivatedBy]
           ,[DeactivationDate]
           ,[LastModifiedBy]
           ,[LastModifiedDate]
           ,[LastModifiedFromPCName])
     VALUES
           (119759
           ,NULL
           ,1
           ,1362202
           ,GETDATE()
           ,0
           ,NULL
           ,1362202
           ,GETDATE()
           ,HOST_NAME()
		   )
GO


