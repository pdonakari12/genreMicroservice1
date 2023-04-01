using GenreMicroservice.Models;

namespace GenreMicroservice.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();
        IEnumerable<Movie> GetMovieByGenre(string genre);

        void InsertMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int movieId);
        

    }
}
