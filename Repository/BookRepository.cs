using AutoMapper.QueryableExtensions;
using Database;
using LibraryManagement.Web.Helpers;
using LibraryManagementDatabase.Entities;
using LibraryManagementDatabase.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository
{
    public class BookRepository: IBookrepository
    {
       
        
        private readonly DataContext _context;

        public BookRepository(DataContext context )
        {
            _context = context;
        }

        public void AddBook(BookModel b)
        {
            _context.Books.Add(b.AsEntity());
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var entity = _context.Books.Where(a => a.Id == id).FirstOrDefault();
            _context.Books.Remove(entity);
            _context.SaveChanges(); 

        }

        public IEnumerable<BookModel> GetBooks()
        {
            return _context.Books.Select(x=>x.AsModel());
        }

        public BookModel GetBook(int id)
        {
            return _context.Books.Find(id).AsModel();
        }

        public void UpdateBook(BookModel data)
        {
            var entity = _context.Books.Where(a => a.Id == data.Id).FirstOrDefault();
            entity.Id = data.Id;
            entity.Title = data.Title;
            entity.Author = data.Author;
            _context.SaveChanges();
        }

        public IEnumerable<BookModel> Search( string searchstring)
        {
            IQueryable<Book> query = _context.Books;
            

            if (!string.IsNullOrWhiteSpace(searchstring))
            {
                query = query.Where(a => a.Title.ToLower().Contains(searchstring.ToLower()) || a.Author.ToLower().Contains(searchstring.ToLower()))
                        ;
            }

            return query.OrderBy(sort => sort.Title.ToLower()).Select(x => x.AsModel()).ToList();
        }

        public IEnumerable<BookModel> Filter(string filter)
        {
            IQueryable<Book> query = _context.Books;
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(a => a.Author.Contains(filter) || a.Title.Contains(filter));
            }
            return query.Select(x=>x.AsModel());
        }
        

    }
}