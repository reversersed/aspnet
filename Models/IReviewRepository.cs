namespace aspnet.Models
{
    public interface IReviewRepository
    {
        List<Review> GetReviews(int offset = 0, int limit = 0);
        void DeleteReview(int id);
        void SetReviewText(int id, string text);
        void CreateReview(Review review);
        Review GetReview(int id);
    }
}
