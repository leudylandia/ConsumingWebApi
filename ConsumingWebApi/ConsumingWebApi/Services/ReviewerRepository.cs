using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConsumingWebApi.Dtos;

namespace ConsumingWebApi.Services
{
    public class ReviewerRepository : IReviewerRepository
    {
        public ReviewerDto GetReviewerById(int reviewrId)
        {
            ReviewerDto reviewers = new ReviewerDto();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60039/api/");
            var response = client.GetAsync($"reviewers/{reviewrId}");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTaks = result.Content.ReadAsAsync<ReviewerDto>();
                readTaks.Wait();

                reviewers = readTaks.Result; ;
            }

            return reviewers;
        }

        public ReviewerDto GetReviewerOfAReview(int reviewId)
        {
            ReviewerDto reviewers = new ReviewerDto();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60039/api/");
            var response = client.GetAsync($"reviewers/{reviewId}/reviewer");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTaks = result.Content.ReadAsAsync<ReviewerDto>();
                readTaks.Wait();

                reviewers = readTaks.Result; ;
            }

            return reviewers;
        }

        public IEnumerable<ReviewerDto> GetReviewers()
        {
            IEnumerable<ReviewerDto> reviewers = new List<ReviewerDto>();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60039/api/");
            var response = client.GetAsync("reviewers");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTaks = result.Content.ReadAsAsync<IList<ReviewerDto>>();
                readTaks.Wait();

                reviewers = readTaks.Result; ;
            }

            return reviewers;
        }

        public IEnumerable<ReviewDto> GetReviewerByReviewer(int reviewerId)
        {
            IEnumerable<ReviewDto> review = new List<ReviewDto>();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60039/api/");
            var response = client.GetAsync($"reviewers/{reviewerId}/reviews");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTaks = result.Content.ReadAsAsync<IList<ReviewDto>>();
                readTaks.Wait();

                review = readTaks.Result; ;
            }

            return review;
        }
    }
}
