﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;
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

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books.GetAllBooks();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var book = books.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        [HttpPost]
        public IHttpActionResult PostBook(Book book)
        {
            bool result = books.AddNewBook(book);
            if (result)
            {
                return Ok(book);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            if (books.Remove(id))
            {
                return Ok(books.GetAllBooks());
            }

            return NotFound();
        }

        [HttpPut]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            var ubook = books.UpdateBook(id, book);
            if (ubook != null)
            {
                return Ok(ubook);
            }

            return NotFound();
        }
    }
}
