namespace Plaisio_API.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Book> AuthoredBooks { get; set; } = new();
    }
}
