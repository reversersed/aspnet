namespace aspnet.Models
{
    public interface IReviewRepository
    {
        List<Review> GetReviews(int offset = 0, int limit = 0, int movie = 0);
        void DeleteReview(int id);
        void SetReview(Review review);
        void CreateReview(Review review);
        Review GetReview(int id);
    }
}
