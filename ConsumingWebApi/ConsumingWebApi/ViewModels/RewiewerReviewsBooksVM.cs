using ConsumingWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumingWebApi.ViewModels
{
    public class RewiewerReviewsBooksVM
    {
        public ReviewerDto Reviewer { get; set; }
        public IDictionary<ReviewDto, BookDto> ReviewBook { get; set; }

    }
}
