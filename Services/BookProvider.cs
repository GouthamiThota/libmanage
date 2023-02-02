
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using System.Collections.Immutable;
using System.Drawing;

namespace Services
{
    
    public class BookProvider : IBookProvider
    {
        //private readonly int _pagesize = 2;
        // private readonly DataContext _context;

        public IBookrepository _bookRepository;
            
        public BookProvider(IBookrepository bookrepository)
        {
            _bookRepository = bookrepository;
        }
            
        public void AddBook(BookModel book)
        {
            _bookRepository.AddBook(book);
        }

        public void  DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public BookModel GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public IEnumerable<BookModel> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        public BooksPaginationModel pagedBooks(int pgno)
        {
            var paged=_bookRepository.GetBooks();
            var PageSize =5f ;
            var totalPages = Math.Ceiling(paged.Count() / PageSize);
            var totalElements = paged.Count();
            var Books = paged.Skip((int)PageSize * (pgno - 1)).Take((int)PageSize).OrderBy(c=>c.Title).ToList();
            var books = new BooksPaginationModel()
            {
                Books = Books,
                TotalItems=totalElements,
                TotalPages=(int)totalPages,
                CurrentPage=pgno,
                ItemsPerPage=(int)PageSize
            };

            return books;
        }

        public void UpdateBook(BookModel data)
        {
            _bookRepository.UpdateBook(data);
        }

        public IEnumerable<BookModel> Search(string searchstring)
        {
           return _bookRepository.Search(searchstring);
        }

        public IEnumerable<BookModel> Filter(string author)
        {
            return _bookRepository.Filter(author); ;
        }
    }
}