using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{
    public class BookRepository : Repoistory<Book>, IBookRepository
    {
        private readonly LibraryContext context;
        public BookRepository(LibraryContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetAllBooksWithAuthors()
        {
            return this.context.Books.Include(a => a.Author);
        }
    }
}
