using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumingWebApi.Dtos;
using ConsumingWebApi.Services;
using ConsumingWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConsumingWebApi.Controllers
{
    public class ReviewersController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IReviewRepository _reviewRepository;

        public ReviewersController(IReviewerRepository reviewerRepository, IReviewRepository reviewRepository)
        {
            this._reviewerRepository = reviewerRepository;
            this._reviewRepository = reviewRepository;
        }

        public IActionResult Index()
        {
            var reviewers = _reviewerRepository.GetReviewers();

            if (reviewers == null || reviewers.Count() <= 0)
            {
                ViewBag.Message = "There was a problem or not reviewers exists";
            }

            return View(reviewers);
        }

        public IActionResult GetReviewerById(int reviewerId)
        {
            var reviewer = _reviewerRepository.GetReviewerById(reviewerId);

            if (reviewer == null)
            {
                ModelState.AddModelError("", "Some kind of error getting reviewer");
                ViewBag.ReviewerMessage = $"There was a problem retireveing reviewer or no reviewer exist";
                reviewer = new Dtos.ReviewerDto();
            }

            var reviews = _reviewerRepository.GetReviewerByReviewer(reviewerId);

            if (reviews.Count() <= 0)
            {
                ViewBag.ReviewMessage = $"Reviewer {reviewer.FirstName} has no reviews";
            }

            IDictionary<ReviewDto, BookDto> reviewAndBook = new Dictionary<ReviewDto, BookDto>();

            foreach (var review in reviews)
            {
                var book = _reviewRepository.GetBookOfAReview(review.Id);
                reviewAndBook.Add(review, book);
            }

            var reviewerReviwsBooksVM = new RewiewerReviewsBooksVM
            {
                Reviewer = reviewer,
                ReviewBook = reviewAndBook
            };

            return View(reviewerReviwsBooksVM);
        }
    }
}