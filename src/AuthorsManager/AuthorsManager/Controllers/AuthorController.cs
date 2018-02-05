using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsManager.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        // GET: Author
        public ActionResult Index()
        {
            return View(_authorRepo.getAuthorList());
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            Author authorDetails = _authorRepo.getAuthorById(id);
            return View(authorDetails);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author newAuthor, IFormCollection collection)
        {
            if (!ModelState.IsValid) return View(newAuthor);

            try
            {
                // TODO: Add insert logic here

                _authorRepo.Add(newAuthor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {   
                return View(newAuthor);
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_authorRepo.getAuthorById(id));
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author updateAuthor, int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _authorRepo.Edit(updateAuthor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_authorRepo.getAuthorById(id));
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Author deleteAuthor, int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _authorRepo.Delete(deleteAuthor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(deleteAuthor);
            }
        }
    }
}