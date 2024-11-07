using Plaisio_API.DTOs;

namespace Plaisio_API.Services
{
    public interface IBookService
    {
        public Task<BookDto?>? GetBook(int id);
        public Task<List<BookDto>> GetAllBooks();
        public Task<BookDto> CreateBook(BookDto book);
        public Task<BookDto> UpdateBook(BookDto book);
        public Task<bool> DeleteBook(int id);
    }
}
