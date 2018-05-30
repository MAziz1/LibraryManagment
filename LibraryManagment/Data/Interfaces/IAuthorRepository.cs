using LibraryManagment.Data.Model;
using LibraryManagment.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorById(int Id);
        IEnumerable<Author> GetAllAuthors();
        void DeleteAuthor(int Id);        
    }


}
