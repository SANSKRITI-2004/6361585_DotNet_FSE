using System;

public class Order
{
    public int OrderId;
    public string CustomerName;
    public double TotalPrice;

    public Order(int id, string name, double price)
    {
        OrderId = id;
        CustomerName = name;
        TotalPrice = price;
    }

    public void Print()
    {
        Console.WriteLine($"OrderId: {OrderId}, Customer: {CustomerName}, TotalPrice: {TotalPrice}");
    }
}

public class Program
{
    public static void BubbleSort(Order[] orders)
    {
        int n = orders.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                
                    var temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                }
            }
        }
    }

    public static void QuickSort(Order[] orders, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(orders, low, high);
            QuickSort(orders, low, pivotIndex - 1);
            QuickSort(orders, pivotIndex + 1, high);
        }
    }

    public static int Partition(Order[] orders, int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice <= pivot)
            {
                i++;

                var temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
        }


        var t = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = t;

        return i + 1;
    }

    public static void PrintOrders(Order[] orders, string title)
    {
        Console.WriteLine($"\n--- {title} ---");
        foreach (var order in orders)
        {
            order.Print();
        }
    }

    public static void Main()
    {
        Order[] orders = new Order[]
        {
            new Order(101, "Alice", 300.50),
            new Order(102, "Bob", 150.00),
            new Order(103, "Charlie", 700.00),
            new Order(104, "David", 200.00)
        };

       
        Order[] bubbleSorted = (Order[])orders.Clone();
        BubbleSort(bubbleSorted);
        PrintOrders(bubbleSorted, "Bubble Sort (By TotalPrice)");

        Order[] quickSorted = (Order[])orders.Clone();
        QuickSort(quickSorted, 0, quickSorted.Length - 1);
        PrintOrders(quickSorted, "Quick Sort (By TotalPrice)");
    }
}
