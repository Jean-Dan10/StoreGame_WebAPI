﻿USE [StoreGame_WebAPI]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[DropAllTables]

SELECT	@return_value as 'Return Value'

GO