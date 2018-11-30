using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooks.Client.Models;
using Refit;

namespace MyBooks.Client.Services
{
    public interface IMyBookApiService
    {
        [Get("/api/Book/{id}")]
        Task<Book> GetBookAsync(int id);

        [Get("/api/Book")]
        Task<List<Book>> GetBooksAsync();
    }
}