using System.Collections.Generic;
using System.Threading.Tasks;
using BookReview.App.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookReview.WebApi.Controllers
{
    [ApiController]
    [Route("Book/Reviews")]
    public class BooksReviewsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IConfiguration configuration, [FromQuery] GetBookReviewsRequest request)
        {
            string googleApiKey = configuration.GetSection("GoogleApiKey").Value;

            var bookReviews = new List<BookReviewResult>();
            var books = BooksAbstraction.GetBooks(googleApiKey, request.Topic);
            foreach (var book in books)
            {
                bookReviews.Add(new BookReviewResult
                {
                    Book = book,
                    Videos = VideosAbstraction.GetVideos(googleApiKey, book.Title)
                });
            }

            return Ok(bookReviews);
        }
    }
}