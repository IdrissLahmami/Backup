--------------------------------------------------------------------------------------------
-- Name		: Execute Test Automation Reporting System backend script
-- Testhor	: Idriss Lahmami
-- Version	: Initial release
--------------------------------------------------------------------------------------------

USE EARS_DB
Go

--DROP PROCEDURE sp_CreateTestCycleID
--GO

CREATE PROC [dbo].[sp_CreateTestCycleID]
@TestName nvarchar(40),
@Expected  nvarchar(50),
@Actual nvarchar(50),
@Result     nvarchar(50),
@BuildNo nvarchar(20),
@DateOfExecution datetime NULL, 
@TestType int,
@ExecutionTime nvarchar(20)
AS
BEGIN
	INSERT into tblTestCycle (TestName,Expected,Actual,Result,BuildNo,
	DateOfExecution,TestType, ExecutionTime) values (@TestName,@Expected,@Actual,@Result,@BuildNo,
	@DateOfExecution, @TestType, @ExecutionTime)
END

Go

sp_help sp_CreateTestCycleID

GO
sp_help tblTestCycle

--DROP PROCEDURE sp_GetFilterData

/*
CREATE PROC [dbo].[sp_GetFilterData]
@TestCycleID int = 0,
@Expected varchar(20) = null,
@FromDate Date = null,
@ToDate Date = null
as
Begin
	If @Expected != null
		select * from tblTestCycle where Expected = @Expected
	ELSE IF @TestCycleID != -1
		Select * from tblTestCycle where TestCycleID = @TestCycleID
	ELSE IF @FromDate != null
		select * from tblTestCycle	Where CAST(DateOfExecution as Date) between @FromDate and @ToDate
End
*/

Go

--USE THIS
CREATE PROC [dbo].[sp_GetFilterData]
@TestCycleID int
as
Begin
	
	IF @TestCycleID != -1
		Select * from tblTestCycle where TestCycleID = @TestCycleID
	
End

GO


CREATE PROC [dbo].[sp_GetLastTestCycleID]
@ID int output
as
BEGIN
Select @ID = IDENT_CURRENT('tblTestCycle')
PRINT @ID
END

Go

CREATE PROC [dbo].[sp_InsertResult]
@FeatureName varChar(100),
@ScenarioName varchar(800),
@StepName varchar(1000),
@Exception varchar(5000) = null,
@Result varchar(200)=null
as
Begin
	Declare @ID int
	Select @ID = IDENT_CURRENT('tblTestCycle')
	Insert into tblDetailReport (ParentCycleID,FeatureName,ScenarioName,StepName,Exception,Result)
	Values(@ID,@FeatureName,@ScenarioName,@StepName,@Exception,@Result)
	-- For Future request only
	--If (@Result = 'FAILED')
	--BEGIN
	--	Select @ID = IDENT_CURRENT('tblDetailReport')
	--	--Insert into tblFailureReport (FailureReportID,FailureDetails) Values (@ID,@FailureReason)
	--END
End

--EXEC sp_InsertResult 'TestFeature', 'TestScenario','Test Step', '', 'PASSED'
--SELECT * FROM tblDetailReport


Go
CREATE PROC [dbo].[sp_TCDetailsCount]
@ParentCycleID int
as
	Begin
		Select COUNT(ParentCycleID) as [Total Steps] from tblDetailReport where ParentCycleID = @ParentCycleID
		Select count(distinct StepName) as StepsCount from tblDetailReport where ParentCycleID = 163 
		Select COUNT(Result) as [Total Passed] from tblDetailReport where Result = 'PASSED'
		Select COUNT(Result) as [Total Failed] from tblDetailReport where Result = 'FAILED'
	End
GO


--drop procedure sp_GetFilterDataDate


CREATE PROC [dbo].[sp_GetFilterDataDate]
@FromDate Date,
@ToDate Date
AS
BEGIN
   select * from tblTestCycle where CAST(DateOfExecution AS Date) between @FromDate and @ToDate
   RETURN
END 

GO

CREATE PROC [dbo].[sp_GetFilterDataResult]
@Result varchar(20)
AS
BEGIN
select * from tblTestCycle where Result = @Result
End


-- select * from tblTestCycle where Expected = 'Idriss Lahmami'

select * from tblTestCycle where CAST(DateOfExecution AS Date) between '2018-11-01' and '2018-12-31'

