using ConsumingWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumingWebApi.Services
{
    public interface IBookRepository
    {
        IEnumerable<BookDto> GetBooks();
        BookDto GetBook(int bookId);
        BookDto GetBookByIsbn(string bookIsbn);
        decimal GetBookRating(int bookId);
    }
}
