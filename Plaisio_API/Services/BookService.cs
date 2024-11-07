using Plaisio_API.Data;
using Plaisio_API.DTOs;
using Microsoft.EntityFrameworkCore;
using Plaisio_API.Domain;

namespace Plaisio_API.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;
        public BookService(LibraryContext context) 
        {
            _context = context;  
        }


        public async Task<BookDto> CreateBook(BookDto dto)
        {
            Author? author = null;

            if (dto.Author is not null)
            {
                author = await _context.Authors.Where(a => a.Id == dto.Author.Id).SingleOrDefaultAsync();
            }

            Book book = new Book()
            {
                Title = dto.Title,
                Publisher = dto.Publisher,
            };

            if (author is not null) book.Author = author;

            _context.Books.Add(book);
            _context.SaveChanges();

            return ConvertBook(book);
        }

        public Task<bool> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            return await _context.Books
                .Select(b => ConvertBook(b)) //Book to BookDto
                .ToListAsync();
        }

        public async Task<BookDto?>? GetBook(int id)
        {
            Book? book = await _context.Books
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();
           
            if (book == null) return null;

            var result = ConvertBook(book);
            return result;
        }

        public Task<BookDto> UpdateBook(BookDto book)
        {
            throw new NotImplementedException();
        }

        public static BookDto ConvertBook(Book book)
        {
            Author? author = book.Author;
            AuthorDto authorDto = new();

            if (author == null)
            {
                authorDto = new AuthorDto() { FirstName = "", LastName = "" };
            }

            else
            {
                authorDto = new AuthorDto() { FirstName = author.FirstName, LastName = author.LastName };
            }

            return new BookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Author = authorDto,
                Publisher = book.Publisher
            };

        }
    }
}
