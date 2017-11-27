using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Exercise_3.Models;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var authors = new List<Author>();
            authors.Add(new Author(1, "Author 1"));
            authors.Add(new Author(2, "Author 2"));
            authors.Add(new Author(3, "Author 3"));
            var catalogs = new List<Catalog>();
            catalogs.Add(new Catalog(1, "Catalog 1"));
            catalogs.Add(new Catalog(2, "Catalog 2"));
            catalogs.Add(new Catalog(3, "Catalog 3"));
            var books = new List<Book>();
            books.Add(new Book(1, "Title 1", 2000, 2, 3, 4.0));
            books.Add(new Book(2, "Title 2", 2001, 2, 1, 2.5));
            books.Add(new Book(3, "Title 3", 2006, 3, 2, 3.5));
            books.Add(new Book(4, "Title 4", 1997, 1, 1, 5.4));
            books.Add(new Book(5, "Title 5", 2001, 3, 2, 2.5));

            var listOfBooks = from b in books 
                              orderby b.Title
                              join a in authors
                              on b.AuthorId equals a.Id
                              join c in catalogs
                              on b.CatalogId equals c.Id
                              select new
                              {
                                  b.Id,
                                  b.Title,
                                  b.Rate, 
                                  catalog = c.Name,
                                  author = a.Name
                              };
            

            ConsoleTable.From(listOfBooks).Write();

            SplitBooksToPages(books, catalogs, authors, 2, 3);

            var listOfCatalogs = from c in catalogs
                                 join b in books
                                 on c.Id equals b.CatalogId
                                 into catalogDetails
                                 select new
                                 {
                                     c.Id,
                                     c.Name,
                                     averageRate = catalogDetails.Average(book => book.Rate),
                                     BooksExample = catalogDetails.Take(3).Select(b => b.Title).Aggregate((b1, b2) => b1 + ", " + b2),
                                     BooksCount = catalogDetails.Count()
                                 };
            ConsoleTable.From(listOfCatalogs).Write();

            var listOfAuthors = from a in authors
                                join b in books
                                on a.Id equals b.AuthorId
                                into authorsWithBooks
                                from author in authorsWithBooks
                                join c in catalogs
                                on author.CatalogId equals c.Id
                                select new
                                {
                                    a.Id,
                                    a.Name,
                                    averageRate = authorsWithBooks.Average(x => x.Rate),
                                    catalogsExample = authorsWithBooks.Take(3).Select(x => c.Name).Aggregate((x1, x2) => x1 + ", " + x2)
                                };
            ConsoleTable.From(listOfAuthors).Write();

            Console.Write("Enter the string for searching : ");
            var searchingString = Console.ReadLine();

            var searchResults = listOfBooks.Where(b =>
                (b.Title.Contains(searchingString) || 
                b.catalog.Contains(searchingString) ||
                b.author.Contains(searchingString)));
            ConsoleTable.From(searchResults).Write();


            Console.ReadKey();
        }

        static void SplitBooksToPages(List<Book> books, List<Catalog> catalogs, List<Author> authors, int pageId,
            int maxItemsParPage)
        {
            var listBooksOnPage = (from b in books
                            join a in authors
                            on b.AuthorId equals a.Id
                            join c in catalogs
                            on b.CatalogId equals c.Id
                            select new
                            {
                                b.Id,
                                b.Title,
                                b.Rate,
                                catalog = c.Name,
                                author = a.Name
                            }).Skip(maxItemsParPage * (pageId - 1)).Take(maxItemsParPage);
            ConsoleTable.From(listBooksOnPage).Write();
        }
        
    }
}
