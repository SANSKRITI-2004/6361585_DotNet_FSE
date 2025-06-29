WITH RankedProducts AS (
  SELECT Category,ProductName,Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
  FROM Products
)

SELECT *
FROM RankedProducts
WHERE RowNum <= 3;

SELECT 
  Category,
  ProductName,
  Price,
  RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS PriceRank,
  DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DensePriceRank
FROM Products;
