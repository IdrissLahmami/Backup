USE [EARS_DB]
GO

/****** Object: SqlProcedure [dbo].[sp_GetFilterDataName] Script Date: 09/11/2018 13:38:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROC [dbo].[sp_GetFilterDataResult]
@Result varchar(20)
AS
BEGIN
select * from tblTestCycle where Result = @Result
End


Go

CREATE PROC [dbo].[sp_GetFilterDataDate]
@FromDate Date,
@ToDate Date
AS
BEGIN
   select * from tblTestCycle where CAST(DateOfExecution AS Date) between @FromDate and @ToDate
   RETURN
END 


--select * from tblTestCycle	Where CAST(DateOfExecution as Date) between @FromDate and @ToDate

--sp_helptext sp_GetFilterDataDate

/*

USE [EARS_DB]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[sp_GetFilterDataDate]
		@FromDate = "04/11/2018",
		@ToDate = "11/11/2018"

SELECT	@return_value as 'Return Value'

GO

*/

SELECT [TestCycleID],[AUTName], [ExecutedBy], [RequestedBy], [BuildNo], [DateOfExecution] FROM [tblTestCycle]


 select DateOfExecution from tblTestCycle where CONVERT(VARCHAR, DateOfExecution, 104) between '04/11/2018' and '12/11/2018'


 select * from tblTestCycle


 SELECT [TestCycleID],[AUTName], [ExecutedBy], [RequestedBy], [BuildNo], FORMAT([DateOfExecution],'d','en-gb') AS DateOfExecution  FROM [tblTestCycle]
 WHERE DateOfExecution between '04/11/2018' and '12/11/2018'


 select format (DateOfExecution, 'd', 'en-gb' ) as 'GB' from  tblTestCycle

SELECT [YYYY Month DD] = CAST(YEAR(GETDATE()) AS VARCHAR(4))+ ' ' + DATENAME(MM, GETDATE()) + ' ' + CAST(DAY(GETDATE()) AS VARCHAR(2))


SELECT [TestCycleID],[AUTName], [ExecutedBy], [RequestedBy], [BuildNo], [DateOfExecution] FROM [tblTestCycle]