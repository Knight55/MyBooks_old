using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBooks.Client.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Book id: ");
            var id = System.Console.ReadLine();
            await GetBookAsync(int.Parse(id));

            System.Console.ReadKey();
        }

        private static async Task GetBookAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(new Uri($"http://localhost:5000/api/Book/{id}"));
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    System.Console.WriteLine(json);
                }
            }
        }
    }
}
