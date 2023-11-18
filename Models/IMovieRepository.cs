namespace aspnet.Models
{
    public interface IMovieRepository
    {
        Movie Get(int id);
        List<Movie> GetMany();
    }
}
