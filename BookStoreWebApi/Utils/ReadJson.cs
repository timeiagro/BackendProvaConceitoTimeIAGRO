using BookStoreWebApi.Interfaces;
using BookStoreWebApi.Models.Entities;
using Newtonsoft.Json;
using System.Reflection;

namespace BookStoreWebApi.Utils
{
    public class ReadJson : IReadJson
    {
        public List<Book> ReadBookList()
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\Json\books.json";
            string json = File.ReadAllText(filePath);

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);

            return books;
        }
    }
}
