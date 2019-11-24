using ConsumingWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumingWebApi.Services
{
    public interface IAuthorRepository
    {
        IEnumerable<AuthorDto> GetAuthors();
        AuthorDto GetAuthor(int authorId);
        IEnumerable<BookDto> GetBookByAuthor(int authorId);
        IEnumerable<BookDto> GetAuthorsOfABook(int bookId);
    }
}
