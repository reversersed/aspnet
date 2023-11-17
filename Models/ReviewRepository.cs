
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace aspnet.Models
{
    public class ReviewRepository : IReviewRepository
    {
        public List<Review>? LoadReviews(int filterId)
        {
            using (dbModel db = new())
            {
                switch (filterId)
                {
                    case 1:
                        return new List<Review>(db.reviews
                                            .ToList()
                                            .OrderByDescending(i => i.Text?.Length)
                                            .ThenByDescending(i => i.Rating)
                                            .ToList());
                    case 2:
                        return new List<Review>(db.reviews
                                            .ToList()
                                            .OrderByDescending(i => i.Rating)
                                            .ToList());
                    case 3:
                        return new List<Review>(db.reviews
                                            .ToList()
                                            .OrderBy(i => i.Rating)
                                            .ToList());
                    default:
                        return default;
                }
            }
        }
        public void CreateReview(Review review)
        {
            using (dbModel db = new())
            {
                db.reviews.Add(review);
                db.SaveChanges();
            }
        }

        public void DeleteReview(int id)
        {
            using(dbModel db = new())
            {
                var entity = db.reviews.FirstOrDefault(r => r.Id == id);
                if(entity != null)
                    db.reviews.Remove(entity);
                db.SaveChanges();
            }
        }

        public Review GetReview(int id)
        {
            using(dbModel db = new())
            {
                return db.reviews.First(i => i.Id == id);
            }
        }

        public List<Review> GetReviews(int offset = 0, int limit = 0)
        {
            List<Review> reviews = new List<Review>();
            using(dbModel db=new())
            {
                foreach (var rev in db.reviews.OrderByDescending(i => i.Id).Skip(offset).Take(limit).ToList())
                    reviews.Add(rev);
            }
            return reviews;
        }

        public void SetReviewText(int id, string text)
        {
            using(dbModel db= new())
            {
                Review r = db.reviews.Where(i => i.Id == id).First();
                r.Text = text;
                db.reviews.Update(r);
                db.SaveChanges();
            }
        }
    }
}
