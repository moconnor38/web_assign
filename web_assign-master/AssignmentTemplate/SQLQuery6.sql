USE [C:\USERS\MARKO\WEB_ASSIGN\WEB_ASSIGN-MASTER\ASSIGNMENTTEMPLATE\SAMPLETEMPLATE\APP_DATA\CADATA.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[uspCreateLibraryEntryTable]

SELECT	@return_value as 'Return Value'

GO
