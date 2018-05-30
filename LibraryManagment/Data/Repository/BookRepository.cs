using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
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

        
    }
}
