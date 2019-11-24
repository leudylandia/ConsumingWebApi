using ConsumingWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumingWebApi.Services
{
    public interface IReviewerRepository
    {
        IEnumerable<ReviewerDto> GetReviewers();
        ReviewerDto GetReviewerById(int reviewrId);
        IEnumerable<ReviewDto> GetReviewersByReviewer(int reviewerId);
        ReviewDto GetReviewerOfAReview(int reviewId);
    }
}
