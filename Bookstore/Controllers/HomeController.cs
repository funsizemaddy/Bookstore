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
        public IActionResult Index(string categories, int page_number = 1)
        {
            int page_size = 10;

            var x = new BookViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == categories || categories == null)
                .OrderBy(b => b.Title)
                .Skip((page_number - 1) * page_size)
                .Take(page_size),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (categories == null
                                        ? repo.Books.Count()
                                        : repo.Books.Where(x => x.Category == categories).Count()),
                    BooksPerPage = page_size,
                    CurrentPage = page_number
                }
            };

            return View(x);
        }
    }
}
