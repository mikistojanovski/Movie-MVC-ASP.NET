using soprosopro.Areas.Identity.Data;

namespace soprosopro.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? userId { get; set; }

        public soprosoproUser? user { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
