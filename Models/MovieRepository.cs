
namespace aspnet.Models
{
    public class MovieRepository : IMovieRepository
    {
        public Movie Get(int id)
        {
            using (dbModel db = new())
            {
                return db.movies.Find(id) ?? new Movie();
            }
        }

        public List<Movie> GetMany()
        {
            var list = new List<Movie>();
            using (dbModel db = new())
            {
                foreach(var movie in db.movies)
                    list.Add(movie);
            }
            return list;
        }
    }
}
