namespace Plaisio_API.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<Book> RentedBooks { get; set; } = [];
    }
}
