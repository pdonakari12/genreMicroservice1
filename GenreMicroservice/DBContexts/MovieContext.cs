using Microsoft.EntityFrameworkCore;
using GenreMicroservice.Models;

namespace GenreMicroservice.DBContexts
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
