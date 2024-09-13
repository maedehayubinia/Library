using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Program
    {
        public class Book
        {
            public string Title { get; private set; }
            public string Author { get; private set; }
            public int Price { get; private set; }
            public int PageNumber { get; private set; }

            public Book(string title, string author, int price, int pageNumber)
            {
                Title = title;
                Author = author;
                Price = price;
                PageNumber = pageNumber;
            }

            public void DisplayBook()
            {
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Author: {Author}");
                Console.WriteLine($"Price: {Price}");
                Console.WriteLine($"Page Number: {PageNumber}");
            }

            public override string ToString()
            {
                return $"Title: {Title}, Author: {Author}, Price: {Price}, Page Number: {PageNumber}";
            }
        }

        public class Librarian
        {
            private Dictionary<string, Book> books;

            public Librarian(Dictionary<string, Book> books)
            {
                this.books = books;
            }

            public void Add(Book book)
            {
                if (!books.ContainsKey(book.Title))
                {
                    books[book.Title] = book;
                    Console.WriteLine($"Added book: {book.Title}");
                }
                else
                {
                    Console.WriteLine("The book is already in the library.");
                }
            }

            public void Remove(string title)
            {
                if (books.Remove(title))
                {
                    Console.WriteLine($"Removed book: {title}");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }

            public void Display()
            {
                Console.WriteLine("Library Books:");
                foreach (var book in books.Values)
                {
                    book.DisplayBook();
                    Console.WriteLine();
                }
            }
        }

        public class Reader
        {
            private List<Book> shoppingCart = new List<Book>();
            private Dictionary<string, Book> availableBooks;

            public Reader(Dictionary<string, Book> books)
            {
                availableBooks = books;
            }

            public void DisplayBooks()
            {
                Console.WriteLine("Available Books:");
                foreach (var book in availableBooks.Values)
                {
                    book.DisplayBook();
                    Console.WriteLine();
                }
            }

            public void Order(string title)
            {
                if (availableBooks.TryGetValue(title, out var book))
                {
                    shoppingCart.Add(book);
                    Console.WriteLine($"Added to shopping cart: {book.Title}");
                }
                else
                {
                    Console.WriteLine("Book not available.");
                }
            }

            public void ShowShoppingCart()
            {
                Console.WriteLine("Your Shopping Cart:");
                foreach (var book in shoppingCart)
                {
                    book.DisplayBook();
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            var books = new Dictionary<string, Book>();
            var librarian = new Librarian(books);
            var reader = new Reader(books);
            librarian.Add(new Book("White Nights", "F. Dostoevsky", 200000, 120));

            while (true)
            {
                try
                {
                    Console.WriteLine("1. Display Books");
                    Console.WriteLine("2. Add Book");
                    Console.WriteLine("3. Remove Book");
                    Console.WriteLine("4. Order Book");
                    Console.WriteLine("5. Show Shopping Cart");
                    Console.WriteLine("0. Exit");
                    Console.Write("Select an option: ");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            librarian.Display();
                            break;
                        case "2":
                            // Add a new book
                            Console.Write("Enter title: ");
                            var title = Console.ReadLine();
                            Console.Write("Enter author: ");
                            var author = Console.ReadLine();
                            Console.Write("Enter price: ");
                            var price = int.Parse(Console.ReadLine());
                            Console.Write("Enter page number: ");
                            var pageNumber = int.Parse(Console.ReadLine());
                            librarian.Add(new Book(title, author, price, pageNumber));
                            break;
                        case "3":
                            // Remove a book
                            Console.Write("Enter the title of the book to remove: ");
                            librarian.Remove(Console.ReadLine());
                            break;
                        case "4":
                            // Order a book
                            Console.Write("Enter the title of the book to order: ");
                            reader.Order(Console.ReadLine());
                            break;
                        case "5":
                            reader.ShowShoppingCart();
                            break;
                        case "0":
                            return; // Exit the program
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}












