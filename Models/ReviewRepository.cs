
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public List<Review> GetReviews(int offset = 0, int limit = 0, int movie = 0)
        {
            List<Review> reviews = new List<Review>();
            using(dbModel db=new())
            {
                foreach (var rev in movie == 0 ?    db.reviews.OrderByDescending(i => i.Id).Skip(offset).Take(limit).ToList() :
                                                    db.reviews.Where(x => x.MovieId == movie).OrderByDescending(i => i.Id).Skip(offset).Take(limit).ToList())
                    reviews.Add(rev);
            }
            return reviews;
        }

        public void SetReview(Review review)
        {
            using(dbModel db= new())
            {
                db.reviews.Update(review);
                db.SaveChanges();
            }
        }
    }
}
