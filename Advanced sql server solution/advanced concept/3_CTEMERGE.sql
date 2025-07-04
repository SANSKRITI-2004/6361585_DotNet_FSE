WITH CalendarCTE AS (
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate
    UNION ALL
    SELECT DATEADD(DAY, 1, CalendarDate)
    FROM CalendarCTE
    WHERE CalendarDate < '2025-01-31'
)
SELECT * FROM CalendarCTE;

CREATE TABLE StagingProducts (
    ProductID INT,
    ProductName VARCHAR(50),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);


INSERT INTO StagingProducts (ProductID, ProductName, Category, Price)
VALUES
    (1, 'Mouse', 'Electronics', 25.99),
    (4, 'Keyboard', 'Electronics', 45.99),
    (5, 'Speaker', 'Audio', 35.49);


MERGE INTO Products AS Target
USING StagingProducts AS Source
ON Target.ProductID = Source.ProductID
WHEN MATCHED THEN
    UPDATE SET 
        Target.Price = Source.Price,
        Target.ProductName = Source.ProductName,
        Target.Category = Source.Category
WHEN NOT MATCHED THEN
    INSERT (ProductID, ProductName, Category, Price)
    VALUES (Source.ProductID, Source.ProductName, Source.Category, Source.Price);