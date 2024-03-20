using RWP.Models;

namespace RWP.Service
{
    public interface IMovieService
    {
        public Task<bool> Create(Movie movie);
        public  Task<bool> Delete(int id);
        public  Task<Movie> Edit(Movie movie);
        public  Task<IList<Movie>> Get();
        public  Task<Movie> Get(int id);
    }
}