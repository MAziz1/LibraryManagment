using LibraryManagment.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data
{
    public static class DBInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryContext>();

                // Books
                Book book1 = new Book() { ID = 1, Name = "Book1 - A1", AuthorId = 1 };
                Book book2 = new Book() { ID = 2, Name = "Book2 - A1", AuthorId = 1 };
                Book book3 = new Book() { ID = 3, Name = "Book3 - A1", AuthorId = 1 };

                Book book4 = new Book() { ID = 4, Name = "Book1 - A2", AuthorId = 2 };
                Book book5 = new Book() { ID = 5, Name = "Book2 - A2", AuthorId = 2 };
                Book book6 = new Book() { ID = 6, Name = "Book3 - A2", AuthorId = 2 };

                // authors
                var author1 = new Author() { Name = "Author1", Books = new List<Book>() { book1, book2, book3 } };
                var author2 = new Author() { Name = "Author2" , Books = new List<Book>() { book4, book5, book6 } };
                var author3 = new Author() { Name = "Author3" };

                context.Authors.Add(author1);
                context.Authors.Add(author2);
                context.Authors.Add(author3);

                context.SaveChanges();
            }
        }
    }
}
