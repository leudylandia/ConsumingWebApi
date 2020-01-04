using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConsumingWebApi.Dtos;

namespace ConsumingWebApi.Services
{
    public class ReviewRepository : IReviewRepository
    {
        public BookDto GetBookOfAReview(int reviewId)
        {
            BookDto reviews = new BookDto();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60039/api/");
            var response = client.GetAsync($"reviews/{reviewId}/book");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTaks = result.Content.ReadAsAsync<BookDto>();
                readTaks.Wait();

                reviews = readTaks.Result; ;
            }

            return reviews;
        }

        public ReviewDto GetReviewById(int reviewId)
        {
            ReviewDto review = new ReviewDto();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60039/api/");
            var response = client.GetAsync($"reviews/{reviewId}");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTaks = result.Content.ReadAsAsync<ReviewDto>();
                readTaks.Wait();

                review = readTaks.Result; ;
            }

            return review;
        }

        public IEnumerable<ReviewDto> GetReviews()
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60039/api/");
            var response = client.GetAsync("reviews");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTaks = result.Content.ReadAsAsync<IList<ReviewDto>>();
                readTaks.Wait();

                reviews = readTaks.Result; ;
            }

            return reviews;
        }

        public IEnumerable<ReviewDto> GetReviewsOfABook(int bookId)
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60039/api/");
            var response = client.GetAsync($"reviews/books/{bookId}");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTaks = result.Content.ReadAsAsync<IList<ReviewDto>>();
                readTaks.Wait();

                reviews = readTaks.Result; ;
            }

            return reviews;
        }
    }
}
