using ConsumingWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumingWebApi.Services
{
    public interface IReviewRepository
    {
        IEnumerable<ReviewDto> GetReviews();
        ReviewDto GetReviewById(int reviewId);
        IEnumerable<ReviewDto> GetReviewsOfABook(int bookId);
        BookDto GetBookOfAReview(int reviewId);
    }
}
