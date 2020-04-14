/****** Object:  StoredProcedure [dbo].[ImportLogs]    Script Date: 19/07/2019 06:14:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ImportLogs] @filepath   NVARCHAR(500), 
                                @bulkinsert NVARCHAR(2000) 
AS 
    IF Object_id('event_logs') IS NOT NULL 
      BEGIN 
		  -- The bulk insert command must be built as a string because the filepath of the CSV file cannot be passed as a paramter.
		  -- https://stackoverflow.com/questions/15671971/syntax-error-when-defining-a-parameter-for-bulk-insert
          SET @bulkinsert = N'BULK INSERT event_logs FROM ''' 
                            + @filepath 
                            + 
          N''' WITH (FIELDTERMINATOR = '','', ROWTERMINATOR = ''\n'')' 
	  EXEC sp_executesql @bulkinsert
      END 
    ELSE 
      BEGIN 
          /****** Object:  Table [dbo].[event_logs]    Script Date: 19/07/2019 05:57:04 ******/ 
          SET ansi_nulls ON 
          SET quoted_identifier ON 

          CREATE TABLE [dbo].[event_logs] 
            ( 
			   [guid]                   [VARCHAR](100) NOT NULL, 
               [level]                  [VARCHAR](100) NULL, 
               [date_and_time]          [VARCHAR](100) NULL, 
               [source]                 [VARCHAR](100) NULL, 
               [event_id]               [SMALLINT] NULL, 
               [task_category]          [VARCHAR](100) NULL, 
               [extracted_account_name] [VARCHAR](100) NOT NULL, 
               CONSTRAINT [PK_event_logs] PRIMARY KEY CLUSTERED ( [guid] ASC ) 
               WITH ( 
               pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = 
               OFF, 
               allow_row_locks = on, allow_page_locks = on) ON [PRIMARY] 
            ) 
          ON [PRIMARY] 

          SET ansi_padding ON 

          /****** Object:  Index [IX_date_and_time]    Script Date: 19/07/2019 05:57:04 ******/ 
          CREATE NONCLUSTERED INDEX [IX_date_and_time] 
            ON [dbo].[event_logs] ( [date_and_time] ASC ) 
            WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb 
          = 
          OFF, 
          drop_existing = OFF, online = OFF, allow_row_locks = ON, 
          allow_page_locks 
          = 
          ON) ON [PRIMARY] 

          /****** Object:  Index [IX_event_id]    Script Date: 19/07/2019 05:57:04 ******/ 
          CREATE NONCLUSTERED INDEX [IX_event_id] 
            ON [dbo].[event_logs] ( [event_id] ASC ) 
            WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb 
          = 
          OFF, 
          drop_existing = OFF, online = OFF, allow_row_locks = ON, 
          allow_page_locks 
          = 
          ON) ON [PRIMARY] 

          SET ansi_padding ON 

          /****** Object:  Index [IX_extracted_account_name]    Script Date: 19/07/2019 05:57:04 ******/
          CREATE NONCLUSTERED INDEX [IX_extracted_account_name] 
            ON [dbo].[event_logs] ( [extracted_account_name] ASC ) 
            WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb 
          = 
          OFF, 
          drop_existing = OFF, online = OFF, allow_row_locks = ON, 
          allow_page_locks 
          = 
          ON) ON [PRIMARY] 

          SET ansi_padding ON 

          /****** Object:  Index [IX_task_category]    Script Date: 19/07/2019 05:57:04 ******/ 
          CREATE NONCLUSTERED INDEX [IX_task_category] 
            ON [dbo].[event_logs] ( [task_category] ASC ) 
            WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb 
          = 
          OFF, 
          drop_existing = OFF, online = OFF, allow_row_locks = ON, 
          allow_page_locks 
          = 
          ON) ON [PRIMARY] 

		  -- Import records once database has been created.
          SET @bulkinsert = N'BULK INSERT event_logs FROM ''' 
                            + @filepath 
                            + 
          N''' WITH (FIELDTERMINATOR = '','', ROWTERMINATOR = ''\n'')' 
	  EXEC sp_executesql @bulkinsert

      END 
GO


