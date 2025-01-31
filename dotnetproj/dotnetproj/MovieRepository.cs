namespace dotnetproj
{
    public class MovieRepository
    {
        private List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>
            {
                new Movie { Title = "Dune: Part Two", Director = "Denis Villeneuve", Year = 2024 },
                new Movie { Title = "Nosferatu", Director = "Robert Eggers", Year = 2024 },
                new Movie { Title = "Interstellar", Director = "Christopher Nolan", Year = 2014 },
                new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", Year = 2008 },
                new Movie { Title = "Pulp Fiction", Director = "Quentin Tarantino", Year = 1994 }
            };
        }

        public List<Movie> SearchMovies(string searchTerm, string director = null, int? year = null)
        {
            return _movies.Where(m =>
                (string.IsNullOrEmpty(searchTerm) || m.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(director) || m.Director.Contains(director, StringComparison.OrdinalIgnoreCase)) &&
                (!year.HasValue || m.Year == year)
            ).ToList();
        }

    }
}