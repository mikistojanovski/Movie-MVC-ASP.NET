namespace soprosopro.Models
{
    public class ClientMovies
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
