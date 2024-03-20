using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RWP.Models;

namespace RWP.Service
{

    public class MovieService : IMovieService
    {
        private readonly RWP.Data.RWPContext _context;
        public MovieService(RWP.Data.RWPContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Movie movie)
        {
            try
            {
                _context.Movie.Add(movie);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return false;
                }
                var movie = await _context.Movie.FindAsync(id);
                if (movie != null)
                {
                    _context.Movie.Remove(movie);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Movie> Edit(Movie movie)
        {
            try
            {
                var movieState = await _context.Movie.FindAsync(movie.Id);
                if (movieState == null) return new();

                movieState.Price= movie.Price;
                movieState.Title= movie.Title;
                movieState.Genre= movie.Genre;
                movieState.ReleaseDate= movie.ReleaseDate;

                await _context.SaveChangesAsync();
                return movieState;
            }
            catch
            {
                return new();
            }
        }

        public async Task<IList<Movie>> Get()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task<Movie> Get(int id)
        {
            return await _context.Movie.FindAsync(id);
        }
    }
}
