using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{
    public class AuthorRepository : Repoistory<Author>, IAuthorRepository
    {

        public AuthorRepository(LibraryContext context) : base(context)
        {
        }

        public void DeleteAuthor(int Id)
        {
            var deletetedAuthor = GetAuthorById(Id);
            _context.Authors.Remove(deletetedAuthor);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.Include(a => a.Books);
        }

        public Author GetAuthorById(int Id)
        {
            return _context.Authors.Where(a => a.ID == Id).Include(a => a.Books).FirstOrDefault();
        }   
    }
}
