using GenreMicroservice.Models;
using GenreMicroservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace GenreMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

   

        [HttpGet("{genre}",Name ="Get")]
        public IActionResult Get(string genre)
        {
            var movies = _movieRepository.GetMovieByGenre(genre);
            if(movies.Count()==0)
                return BadRequest("Movies not found");
            return new OkObjectResult(movies);
        }

      
    }
}
