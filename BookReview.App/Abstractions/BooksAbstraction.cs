using System.Collections.Generic;
using System.Linq;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;

namespace BookReview.App.Abstractions
{
    public static class BooksAbstraction
    {
        public static List<Book> GetBooks(string apiKey, string searchQuery)
        {
            using var booksService = new BooksService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "BookReview"
            });

            var listRequest = new VolumesResource.ListRequest(booksService, searchQuery);
            listRequest.MaxResults = 10;
            listRequest.ShowPreorders = false;

            var listResponse = listRequest.Execute();
            return MapResponsesToBooksModel(listResponse.Items);
        }

        private static List<Book> MapResponsesToBooksModel(IList<Volume> volumes)
        {
            var books = new List<Book>();

            foreach (var volume in volumes)
            {
                var book = new Book();
                books.Add(book);

                book.Title = volume.VolumeInfo.Title;
                book.Subtitle = volume.VolumeInfo.Subtitle;
                book.Description = volume.VolumeInfo.Description;
                book.Authors = volume.VolumeInfo.Authors is null ? new List<string>() : new List<string>(volume.VolumeInfo.Authors);
                book.Published = volume.VolumeInfo.PublishedDate;
                book.PageCount = volume.VolumeInfo.PageCount ?? -1;
                book.ISBNs = volume.VolumeInfo.IndustryIdentifiers.Select(x => x.Identifier).ToList();
                book.PrintType = volume.VolumeInfo.PrintType;
                book.Ratings = volume.VolumeInfo.RatingsCount ?? 0;
                book.AvgRating = volume.VolumeInfo.AverageRating ?? 0;
                book.GoogleBooksUrl = volume.VolumeInfo.PreviewLink;
                book.RetailPriceUSD = volume.SaleInfo?.RetailPrice?.Amount ?? -1;
            }
            
            return books;
        }
    }
}