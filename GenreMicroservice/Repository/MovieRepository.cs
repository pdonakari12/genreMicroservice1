using GenreMicroservice.DBContexts;
using GenreMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace GenreMicroservice.Repository
{
    public class MovieRepository : IMovieRepository
    { 
    private readonly MovieContext _dbContext;
        public MovieRepository(MovieContext dbContext)
        {
            _dbContext= dbContext;
        }
    
        public void DeleteMovie(int movieId)
        {
            var movie=_dbContext.Movies.Find(movieId);
            if (movie != null) {
            _dbContext.Movies.Remove(movie);
            };
            _dbContext.SaveChanges();
        }

        public IEnumerable<Movie> GetMovieByGenre(string genre)
        {
            if (genre != null) {
                return _dbContext.Movies.Where(x=>x.Genre==genre).ToList();    
            }
            return Enumerable.Empty<Movie>();
           
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public void InsertMovie(Movie movie)
        {
            _dbContext.Add(movie);
            _dbContext.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _dbContext.Entry(movie).State=EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
