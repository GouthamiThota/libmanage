using Models;

namespace Repository
{
    public interface IBookrepository
    {
        public IEnumerable<BookModel> Search( string title);
        public IEnumerable<BookModel> Filter(string author);
        public void AddBook(BookModel b);
        public void DeleteBook(int id);
        public IEnumerable<BookModel> GetBooks();
        public BookModel GetBook(int id);
        public void UpdateBook(BookModel data);

    }
}
