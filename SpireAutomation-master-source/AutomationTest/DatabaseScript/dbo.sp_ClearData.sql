USE [EARS_DB]
GO

/****** Object: SqlProcedure [dbo].[sp_GetFilterData] Script Date: 08/11/2018 16:49:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_ClearData]
AS
BEGIN
	delete from tblFailureReport
	delete from tblDetailReport
	delete from tblTestCycle
End

GO



exec sp_ClearData





