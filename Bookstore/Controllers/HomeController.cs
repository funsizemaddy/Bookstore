using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int page_number = 1)
        {
            int page_size = 10;

            var x = new BookViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((page_number - 1) * page_size)
                .Take(page_size),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = page_size,
                    CurrentPage = page_number
                }
            };

            return View(x);
        }
    }
}
