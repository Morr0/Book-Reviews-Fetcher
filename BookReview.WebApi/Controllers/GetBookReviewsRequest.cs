using System.ComponentModel.DataAnnotations;

namespace BookReview.WebApi.Controllers
{
    public class GetBookReviewsRequest
    {
        [Required] public string Topic { get; set; }
    }
}