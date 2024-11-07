namespace Plaisio_API.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Publisher { get; set; }
        public AuthorDto? Author { get; set; }

        //public string? AuthorFirstName { get; set; }
        //public string? AuthorLastName { get; set; }

    }
}
