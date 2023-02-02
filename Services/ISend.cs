using LibraryManagement.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public  interface ISend
    {
        public void AddBook(BookModel book);

        public void DeleteBook(int id);

        public IEnumerable<BookModel> GetBooks();

        public BookModel GetBook(int id);

        public void UpdateBook(BookModel data);

        public BooksPaginationModel pagedBooks(int pgno);

        public IEnumerable<BookModel> Search(string title);

        public IEnumerable<BookModel> Filter(string author);

    }
}
