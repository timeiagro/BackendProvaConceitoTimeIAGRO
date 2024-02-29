﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using WebLivros.Interfaces;
using WebLivros.Models;

namespace WebLivro.Controllers
{

    [ApiController]
    [Route("/Book")]
    public class BookController : ControllerBase
    {
        private IBookService bookService;
        public BookController(IBookService _bookService) { 

            this.bookService = _bookService;
        }

        [HttpGet]
        public List<Book> Get()
        {
            return bookService.GetBooks();
        }

     
        [HttpGet("nome/{name}")]
        public List<Book> GetByName(string name)
        {            
            return bookService.GetByName(name);
        }
        [HttpGet("illustrator/{name}")]
        public List<Book> GetByIllustrator(string name)
        {
            return bookService.GetByIllustrator(name);
        }
        [HttpGet("genere/{name}")]
        public List<Book> GetByGenres(string name)
        {
            return bookService.GetByGenres(name);
        }
        [HttpGet("autor/{name}")]
        public List<Book> GetByAuthor(string name)
        {
            return bookService.GetByAuthor(name);
        }

        [HttpGet("desc")]
        public List<Book> GetByDesc()
        {
            return bookService.GetByDesc();
        }

        [HttpGet("asc")]
        public List<Book> GetByAsc()
        {
            return bookService.GetByAsc();
        }

        [HttpGet("frete/{id}")]
        public double GetValueFrete(int id)
        {
            return bookService.GetValueFrete(id);
        }
    }
}
