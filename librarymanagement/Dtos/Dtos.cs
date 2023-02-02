using System;

namespace LibraryManagement.Web.Dtos
{
    public record BookDto(int Id, string Title, string Author);
    public record CreateBookDto(string Name, string Author);
    public record UpdateBookDto(string Name, string Author);
}
