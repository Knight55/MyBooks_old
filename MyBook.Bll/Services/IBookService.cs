using System.Collections.Generic;
using MyBooks.Bll.Entities;

namespace MyBooks.Bll.Services
{
    public interface IBookService
    {
        Book GetBook(int bookId);
        IEnumerable<Book> GetBooks();
        Book InsertBook(Book newBook);
        void UpdateBook(int bookId, Book updatedBook);
        void DeleteBook(int bookId);
    }
}