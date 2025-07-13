using System;
using System.Collections.Generic;

class Book
{
    public int BookId;
    public string Title;
    public string Author;

    public Book(int bookId, string title, string author)
    {
        BookId = bookId;
        Title = title;
        Author = author;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {BookId}, Title: {Title}, Author: {Author}");
    }
}

class Library
{
    public List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // Linear Search
    public void SearchByTitleLinear(string title)
    {
        Console.WriteLine("\nLinear Search Result:");
        bool found = false;

        foreach (var book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                book.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Book not found.");
        }
    }

    // Binary Search - requires sorting first
    public void SearchByTitleBinary(string title)
    {
        Console.WriteLine("\nBinary Search Result:");

        books.Sort((b1, b2) => b1.Title.CompareTo(b2.Title)); // Sort alphabetically

        int low = 0;
        int high = books.Count - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparison = books[mid].Title.CompareTo(title);

            if (comparison == 0)
            {
                books[mid].Display();
                return;
            }
            else if (comparison < 0)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        Console.WriteLine("Book not found.");
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine("\nAll Books in Library:");
        foreach (var book in books)
        {
            book.Display();
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        // Add sample books
        library.AddBook(new Book(1, "C# Programming", "Sanskrit"));
        library.AddBook(new Book(2, "Data Structures", "rahul"));
        library.AddBook(new Book(3, "Algorithms", "aaryaman"));
        library.AddBook(new Book(4, "C# Programming", "Alice"));

        library.DisplayAllBooks();


        library.SearchByTitleLinear("C# Programming");
        library.SearchByTitleBinary("Algorithms");
    }
}
