using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF_lib
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LibraryContext>());
            using (LibraryContext db = new LibraryContext())
            {
                // creating two books
                Book book1 = new Book { Title = "Great Expectations", ISBN = 10 };
                Book book2 = new Book { Title = "Sherlock", ISBN = 12 };

                // creating two authors
                Author author1 = new Author { Name = "Tom", Surname = "Tomson", Book=book1};
                Author author2 = new Author { Name = "Sam", Surname = "Louise", Book=book2 };

                // adding rows into the database
                db.Books.AddRange(new List<Book> { book1, book2 });
                db.Authors.AddRange(new List<Author> { author1,author2});
               
                db.SaveChanges();
                Console.WriteLine("The objects have been successfully saved");

                // retrieving objects from the database and console output
                var authors = db.Authors;
                Console.WriteLine("Authors list:");
                foreach (Author u in authors)
                {
                    Console.WriteLine("{0} {1} wrote the book \"{2}\" with ISBN - {3}", u.Name, u.Surname, u.Book.Title,u.Book.ISBN);
                }
            }
            Console.Read();
        }
    }
}
