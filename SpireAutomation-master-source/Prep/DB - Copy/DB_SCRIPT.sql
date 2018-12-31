USE Master
GO

--DROP DATABASE EARS_DB

CREATE DATABASE EARS_DB
GO

USE [EARS_DB]
GO

--Drop table tblDetailReport

CREATE TABLE [dbo].[tblDetailReport] (
    [ParentCycleId] [int]  NOT NULL,
    [TestReportId]  [int] IDENTITY(200,1) NOT NULL,
    [FeatureName]   [varchar](100) NULL,
    [ScenarioName]  [varchar](800) NULL,
    [StepName]      [varchar](1000) NULL,
    [Exception]     [varchar](5000) NULL,
    [Result]        [varchar](200) NULL,
CONSTRAINT [PK_tblDetailReport] PRIMARY KEY CLUSTERED
(
    [TestReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]


--SELECT * FROM tblDetailReport

--Drop table tblFailureReport

CREATE TABLE [dbo].[tblFailureReport]
(
	[FailureReportId] [int] NOT NULL, 
    [FailureDetails] [varchar](5000) NULL, 
    [ScreenShot] [binary](1) NULL,
CONSTRAINT [PK_tblFailureReport] PRIMARY KEY CLUSTERED
(
    [FailureReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]   


--SELECT * FROM tblFailureReport


--Drop table tblTestCycle


/*

CREATE TABLE [dbo].[tblTestCycle]
(
	[TestCycleId] [int] IDENTITY(100,1) NOT NULL, 
    [AUTName] [varchar](40) NULL, 
    [ExecutedBy] [varchar](50) NULL, 
    [RequestedBy] [varchar](50) NULL, 
    [BuildNo] [varchar](50) NULL, 
    [ApplicationVersion] [varchar](20) NULL, 
    [DateOfExecution] [datetime] NULL, 
    [TestType] [int] NULL, 
    [MachineName] [varchar](20) NULL,    
  CONSTRAINT [PK_tblTestCycleMain] PRIMARY KEY CLUSTERED
(
    [TestCycleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]   

GO
*/

CREATE TABLE [dbo].[tblTestCycle]
(
	[TestCycleId] [int] IDENTITY(100,1) NOT NULL, 
    [TestName] [nvarchar](40) NULL, 
    [Expected] [nvarchar](50) NULL, 
    [Actual] [nvarchar](50) NULL, 
    [BuildNo] [nvarchar](50) NULL, 
	[Result] [NVARCHAR](20) NULL,
    [DateOfExecution] [datetime] NULL, 
    [TestType] [int] NULL, 
    [ExecutionTime] [nvarchar](20) NULL,    
  CONSTRAINT [PK_tblTestCycleMain] PRIMARY KEY CLUSTERED
(
    [TestCycleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]   

GO


/*

ALTER TABLE [dbo].[tblDetailReport] WITH CHECK ADD CONSTRAINT [FK_tblDetailReport_ParentCycleId] FOREIGN KEY([ParentCycleId]) 
REFERENCES [dbo].[tblTestCycle] ([TestCycleId])
GO

ALTER TABLE [dbo].[tblDetailReport] CHECK CONSTRAINT [FK_tblDetailReport_ParentCycleId]  
GO

ALTER TABLE [dbo].[tblFailureReport] WITH CHECK ADD CONSTRAINT [FK_tblFailureReport_tblDetailReport] FOREIGN KEY([FailureReportId]) 
REFERENCES [dbo].[tblDetailReport] ([TestReportId])
GO

ALTER TABLE [dbo].[tblFailureReport] CHECK CONSTRAINT [FK_tblFailureReport_tblDetailReport]  
GO

*/


-- CREATE STORED PROCEDURES

/*
CREATE PROC [dbo].[sp_CreateTestCycleId]
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
  MachineName, TestType) Values (@AUT, @ExecutedBy, @RequestedBy, @BuildNo, @ApplicationVersion, 
  @MachineName, @TestType )
END

GO
---1


CREATE PROC [dbo].[sp_GetFilterData]
@TestCycleId int = 0,
@ExecutedBy varchar(20) = null,
@FromDate Date = null,
@ToDate Date = null
AS
BEGIN
   IF @ExecutedBy != null 
       SELECT * FROM tblTestCycle WHERE ExecutedBy = @ExecutedBy
   ELSE IF @TestCycleId != -1
       SELECT * FROM tblTestCycle WHERE TestCycleId = @TestCycleId
   ELSE IF @FromDate != null
       SELECT * FROM tblTestCycle WHERE CAST(DateOfExecution AS DATE) BETWEEN @FromDate AND @ToDate
END

GO
---2

CREATE PROC [dbo].[sp_GetLastTestCycleId]
@ID int output
AS
BEGIN
  SELECT @ID = IDENT_CURRENT('tblTestCycle')
  PRINT @ID
END

---3
GO

CREATE PROC [dbo].[sp_InsertResult]
@FeatureName varchar(100),
@ScenarioName varchar(800),
@StepName varchar(1000),
@Exception varchar(5000) = null,
@Result varchar(200) = null
AS
BEGIN
   DECLARE @ID INT
   SELECT @ID = IDENT_CURRENT('tblTestCycle')
   INSERT INTO tblDetailReport (ParentCycleId, FeatureName, ScenarioName, StepName, Exception, Result)
   VALUES (@ID, @FeatureName, @ScenarioName, @StepName, @Exception, @Result )
   -- For Future request only
   -- IF (@Result = 'FAILED')
   -- BEGIN
   --   SELECT @ID = IDENT_CURRENT('tblDetailReport')
   --   INSERT INTO tblFailureReport (FailureReportID, FailureDetails) VALUES (@ID,
   -- END 
END

---4 /*** DOUBLE CHECK *****/
GO

CREATE PROC [dbo].[sp_TCDetailsCount]
@ParentCycleId int
AS
  BEGIN
     SELECT COUNT(ParentCycleId) AS [Total Steps] FROM tblDetailReport WHERE ParentCycleId  = @ParentCycleId
     SELECT COUNT(DISTINCT StepName) AS StepsCount FROM tblDetailReport WHERE ParentCycleId = @ParentCycleId
	 SELECT COUNT(Result) AS [Total Passed] FROM tblDetailReport WHERE Result = 'PASS'
	 SELECT COUNT(Result) AS [Total Failed] FROM tblDetailReport WHERE Result = 'FAIL'
  END
GO



EXEC sp_CreateTestCycleId 'Test Client', 'Expected', 'Actual','Passed', '3.0', CAST("12-12-2018") AS DATE), '1', '2'

--client.CreateTestCycle("Test Client", "Expected", "Actual", "Passed", "2.0",sDate, "1", "2");

*/

--@myDate varchar 

--Check date conversion
DECLARE @myDate DATETIME
SET @myDate = cast('2018/12/24' as datetime)


BEGIN

   EXEC sp_CreateTestCycleId 'Test Client2', 'Expected', 'Actual','Passed', '4.0', @myDate, '1', '2'
    
END

sp_help sp_CreateTestCycleId


SELECT * FROM dbo.tblTestCycle

--@myDate cast (convert(varchar(2),month(getdate())) + '/15/' + 
--convert(varchar(4),year(getdate())) as datetime). 

