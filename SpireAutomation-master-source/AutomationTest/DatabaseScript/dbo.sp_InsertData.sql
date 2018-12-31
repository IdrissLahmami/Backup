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


sp_help sp_CreateTestCycleID

EXEC sp_CreateTestCycleId 'Verify Hospital Links', '45', '45','PASS', '1.0', '2018/11/02', '2', '5'

EXEC sp_CreateTestCycleId 'Verify Treatment Links', '40', '40','PASS', '1.0', '2018/12/02', '1', '2'


select TestCycleID, TestName, Expected, Actual, Result, DateOfExecution from tblTestCycle

select * from tblTestCycle

/*
@Test varchar(40),
@Expected  varchar(50),
@Actual varchar(50),
@Result     varchar(50),
@Build varchar(20),
@ExecutionTime varchar(20),
@BrowserType varchar(20)
*/