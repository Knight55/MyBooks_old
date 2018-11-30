using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooks.Client.Models;
using Refit;

namespace MyBooks.Client.Services
{
    public interface IMyBookApiService
    {
        [Get("/api/Books/{id}")]
        Task<Book> GetBookAsync(int id);

        [Get("/api/Books")]
        Task<List<Book>> GetBooksAsync();
    }
}