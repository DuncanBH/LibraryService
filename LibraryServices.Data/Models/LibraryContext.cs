using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Data.Models
{
    class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryContext"){}

        public DbSet<LibraryServices.Data.Models.Book> Books { get; set; }

    }
}
