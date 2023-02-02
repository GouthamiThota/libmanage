using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;
namespace Services
{
    public interface IBookProvider
    {
        public void AddBook(BookModel book);

        public void DeleteBook(int id);

        public IEnumerable<BookModel> GetBooks();

        public BookModel GetBook(int id);

        public void UpdateBook(BookModel data);

        public BooksPaginationModel pagedBooks(int pgno);

        public  IEnumerable<BookModel> Search(string searchstring);

        public IEnumerable<BookModel> Filter(string author);

    }
}
