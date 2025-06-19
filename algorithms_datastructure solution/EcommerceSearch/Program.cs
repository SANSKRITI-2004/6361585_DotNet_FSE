using System;

public class Product
{
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

public class Program
{

    public static Product LinearSearch(Product[] products, string targetName)
    {
        foreach (var product in products)
        {
            if (product.ProductName == targetName)
            {
                return product;
            }
        }
        return null;
    }

    public static Product BinarySearch(Product[] products, string targetName)
    {

        Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));

        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int result = string.Compare(products[mid].ProductName, targetName);

            if (result == 0)
            {
                return products[mid];
            }
            else if (result < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return null;
    }
    public static void Main()
    {
        Product[] inventory = new Product[]
        {
            new Product(1, "Laptop", "Electronics"),
            new Product(2, "Shirt", "Clothing"),
            new Product(3, "Book", "Stationery"),
            new Product(4, "Phone", "Electronics")
        };

        Console.WriteLine("Searching for: Phone");

        var linearResult = LinearSearch(inventory, "Phone");
        Console.WriteLine(linearResult != null
            ? $"[Linear Search] Found: {linearResult.ProductName}, Category: {linearResult.Category}" 
            : "Not found using Linear Search");

        var binaryResult = BinarySearch(inventory, "Phone");
        Console.WriteLine(binaryResult != null 
            ? $"[Binary Search] Found: {binaryResult.ProductName}, Category: {binaryResult.Category}" 
            : "Not found using Binary Search");
    }
}
