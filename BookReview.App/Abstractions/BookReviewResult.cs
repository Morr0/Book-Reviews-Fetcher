using System.Collections.Generic;

namespace BookReview.App.Abstractions
{
    public class BookReviewResult
    {
        public Book Book { get; set; }
        public List<Video> Videos { get; set; }
    }
}