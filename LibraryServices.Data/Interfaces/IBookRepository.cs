using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryServices.Models;

namespace LibraryServices.Data.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBook(int id);
        bool AddNewBook(Book book);
    }
}
