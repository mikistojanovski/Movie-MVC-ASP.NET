using soprosopro.Models;

namespace soprosopro.ViewModels
{
    public class Filter
    {
        public IList<Movie> Movies { get; set; }
        public string searchTitle { get; set; }
    }
}
