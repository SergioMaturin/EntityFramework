using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF_lib3
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LibraryContext>());
            using (LibraryContext db = new LibraryContext())
            {
                // creating two objects
                Book book1 = new Book { Title = "Great Expectations", ISBN = 10 };
                Book book2 = new Book { Title = "Sherlock", ISBN = 12 };
                Book book3 = new Book { Title = "Grapes of Wrath", ISBN = 19 };
                Book book4 = new Book { Title = "Solaris", ISBN = 9 };
                Author author1 = new Author { Name = "Tom", Surname = "Tomson", Books = { book1, book2, book4 } };
                Author author2 = new Author { Name = "Sam", Surname = "Louise", Books = { book2, book3, book4 } };

                // adding them into the database
                db.Authors.Add(author1);
                db.Authors.Add(author2);
                db.Books.AddRange(new List<Book> { book1,book2});
               
                db.SaveChanges();
                Console.WriteLine("The objects have been successfully saved");

                // retrieving objects from the database and console output
                var authors = db.Authors;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The list of authors and books they wrote:");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (Author author in authors)
                {
                    Console.WriteLine("Author {0} {1} wrote the book:", author.Name, author.Surname);
                    if (author.Books == null) continue;
                    foreach(var book in author.Books)
                    {
                        Console.WriteLine("\t\"{0}\" with ISBN - {1}", book.Title,book.ISBN);
                    }
                }
                Console.WriteLine("--------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                
                foreach(Book book in db.Books)
                {
                    Console.WriteLine("The Book '{0}' is written by:", book.Title);
                    if (book.Authors == null) continue;
                    foreach (var author in book.Authors)
                    {
                        Console.WriteLine("\t{0} {1}", author.Name, author.Surname);
                    }
                }
            }
            Console.Read();
        }
    }
}
