using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryServices.Data.Interfaces;
using LibraryServices.Models;

namespace LibraryServices.Controllers
{
    public class BooksController : ApiController
    {
        private IBookRepository books;

        public BooksController(IBookRepository books)
        {
            this.books = books;
        }


        public IEnumerable<Book> Get()
        {
            return books.GetAllBooks();
        }

        public IHttpActionResult Get(int id)
        {
            var book = books.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
