﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;

namespace LibraryServices.Data.Repositories
{
    public class BookDatabase: IBookRepository
    {
        private LibraryContext db = new LibraryContext();

        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }

        public bool AddNewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return true;
        }

        public bool Remove(int id)
        {
            var book = GetBook(id);
            if (book == null)
            {
                return false;
            }

            db.Books.Remove(book);
            db.SaveChanges();
            return true;
        }

        public List<Book> UpdateBook(int id, Book book)
        {
            if (this.Remove(id))
            {
                this.AddNewBook(book);
                db.SaveChanges();
                return db.Books.ToList();
            }

            return db.Books.ToList();
        }
    }
}
