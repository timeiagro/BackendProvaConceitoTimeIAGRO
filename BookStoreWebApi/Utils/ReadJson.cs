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
            // return System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json);

            //var json = File.ReadAllText(@"C:\Users\caiot\source\repos\BackendProvaConceitoTimeIAGRO\Json\books.json");
            //string json = @"./books.json";

            //var jsonString = File.ReadAllLines(json);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);

            return books;
        }
    }
}
