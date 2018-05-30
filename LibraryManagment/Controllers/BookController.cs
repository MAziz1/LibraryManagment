using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using LibraryManagment.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        public BookController(IBookRepository bookRepository,IAuthorRepository authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Book book = this.bookRepository.GetById(id);
            BookViewModel bookViewModel = new BookViewModel() { Book = book, Authors = this.authorRepository.GetAll() };
            return View("Edit", bookViewModel);
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            this.bookRepository.Update(book);
            return RedirectToAction("Edit", "Author", new { id = book.AuthorId });
        }

        public IActionResult Delete(int id)
        {
            Book book = this.bookRepository.GetById(id);
            this.bookRepository.Delete(book);
            return RedirectToAction("Edit", "Author", new { id = book.AuthorId });
        }

        public IActionResult Books(int AuthorID)
        {
            IEnumerable<Book> books = this.authorRepository.GetAuthorById(AuthorID).Books;
            return View(books);
        }
    }
}