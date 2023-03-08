USE employee;
GO
CREATE PROCEDURE dbo.GetEmployeeWithPositionAndDate   
    @PositionName nvarchar(50),   
    @Date Date  
AS   

    SET NOCOUNT ON;  
    SELECT e.FirstName, e.LastName FROM EmployeePosition ep INNER JOIN JobPosition jp on ep.JobPositionId = jp.Id INNER JOIN Employee e on ep.EmployeeId = e.Id
	WHERE ep.DateFrom <= @Date and ep.DateTo >= @Date and jp.PositionName = @PositionName
GO
