SELECT 
    p.ProductName,
    FORMAT(o.OrderDate, 'yyyy-MM') AS OrderMonth,
    SUM(od.Quantity) AS TotalQuantity
INTO #Sales
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.ProductName, FORMAT(o.OrderDate, 'yyyy-MM');

SELECT *
FROM (
    SELECT ProductName, OrderMonth, TotalQuantity
    FROM #Sales
) AS SourceTable
PIVOT (
    SUM(TotalQuantity)
    FOR OrderMonth IN ([2025-01], [2025-02], [2025-03])
) AS PivotTable;


SELECT ProductName, OrderMonth, TotalQuantity
FROM (
    SELECT ProductName, [2025-01], [2025-02], [2025-03]
    FROM (
        SELECT ProductName, OrderMonth, TotalQuantity
        FROM #Sales
    ) AS SourceTable
    PIVOT (
        SUM(TotalQuantity)
        FOR OrderMonth IN ([2025-01], [2025-02], [2025-03])
    ) AS Pivoted
) AS PivotedData
UNPIVOT (
    TotalQuantity FOR OrderMonth IN ([2025-01], [2025-02], [2025-03])
) AS Unpivoted;
