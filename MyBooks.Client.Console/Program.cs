using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyBooks.Client.Services;
using Refit;

namespace MyBooks.Client.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var myBooksApiService = RestService.For<IMyBookApiService>("http://localhost:5000");

            System.Console.WriteLine("Book id: ");
            var id = System.Console.ReadLine();
            var book = await myBooksApiService.GetBookAsync(int.Parse(id));
            System.Console.WriteLine($"Title: {book.Title}");

            System.Console.ReadKey();
        }
    }
}
