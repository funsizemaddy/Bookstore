using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookstore.Models;
using Bookstore.Infrastructure;

namespace Bookstore.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public BuyModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

       
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
           
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            double p = (repo.Books.Where(x => x.BookId == bookId).Select(x => x.Price).Sum());

            basket.AddItem(b, 1, p) ;

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        public IActionResult OnPostRemove ( int bookId, string returnUrl)
        {
            //In Basket.cs
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage (new { ReturnUrl = returnUrl });
        }
    }
}
