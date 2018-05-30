using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Author> Authors = _authorRepository.GetAllAuthors();
            if (Authors.Count() > 0)
            {
                return View("list", Authors);
            }
            else
            {
                return View("Empty");
            }
        }

        public IActionResult Edit(int Id)
        {
            var author = _authorRepository.GetAuthorById(Id);
            return View("Edit", author);
        }

        [HttpPost]
        public IActionResult Update(Author author)
        {
            _authorRepository.Update(author);
            return View("list", _authorRepository.GetAllAuthors());
        }

        public IActionResult Delete(int Id)
        {
            _authorRepository.DeleteAuthor(Id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateNew()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _authorRepository.Create(author);
            return RedirectToAction("Index");
        }        
    }
}