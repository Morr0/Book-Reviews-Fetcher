using System.Collections.Generic;

namespace BookReview.App.Abstractions
{
    public class Book
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public List<string> Authors { get; set; }
        public string Published { get; set; }
        public List<string> ISBNs { get; set; }
        public int PageCount { get; set; }
        public string PrintType { get; set; }
        public int Ratings { get; set; }
        public double AvgRating { get; set; }
        public string GoogleBooksUrl { get; set; }
        public double RetailPriceUSD { get; set; }
    }
}