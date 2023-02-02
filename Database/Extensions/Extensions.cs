using LibraryManagementDatabase.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementDatabase.Extensions
{
    public static class Extensions
    {
        public static BookModel AsModel(this Book book)
        {
            return new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };
        }

        public static Book AsEntity(this BookModel book)
        {
            return new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
            };
        }
    }
}
