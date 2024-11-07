using System.ComponentModel.DataAnnotations;

namespace Plaisio_API.Domain
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(100)] public string? Title { get; set; }
        public Author? Author { get; set; }
        public int? AuthorId { get; set; }
        public string? Publisher { get; set; }
        public Member? RentedTo { get; set; }
    }
}
