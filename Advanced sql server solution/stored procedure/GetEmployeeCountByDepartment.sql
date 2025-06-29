-- Filename: GetEmployeeCountByDepartment.sql

-- Stored Procedure: Returns the count of employees in a department

CREATE PROCEDURE GetEmployeeCountByDepartment
    @DeptID INT
AS
BEGIN
    SELECT COUNT(*) AS EmployeeCount
    FROM Employees
    WHERE DepartmentID = @DeptID;
END;
