using LibraryManagement.Web.Dtos;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Models;

namespace LibraryManagement.Web.Extensions
{
    public static class Extensions
    {
        public static BookDto AsDto(this BookModel book)
        {
            return new BookDto(book.Id, book.Title, book.Author);
        }

        public static BookModel AsModel(this BookDto book)
        {
            return new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };
        }
    }
}
