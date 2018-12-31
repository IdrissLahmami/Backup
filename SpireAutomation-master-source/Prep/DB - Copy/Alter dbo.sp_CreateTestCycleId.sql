USE [EARS_DB]
GO

/****** Object: SqlProcedure [dbo].[sp_CreateTestCycleId] Script Date: 06/11/2018 16:23:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROC [dbo].[sp_CreateTestCycleId]
@AUT varchar(40),
@ExecutedBy varchar(50),
@RequestedBy varchar(50),
@BuildNo varchar(50),
@ApplicationVersion varchar(20),
@MachineName varchar(20),
@TestType varchar(20)
AS
BEGIN
  INSERT INTO tblTestCycle (AUTName, ExecutedBy, RequestedBy, BuildNo, ApplicationVersion, 
  DateOfExecution, MachineName, TestType) Values (@AUT, @ExecutedBy, @RequestedBy, @BuildNo, @ApplicationVersion, 
  GETDATE(), @MachineName, @TestType)
END
