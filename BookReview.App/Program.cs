using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BookReview.App.Abstractions;
using Microsoft.Extensions.Configuration;

namespace BookReview.App
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a topic (one word) as 1st argument");
                return;
            }
            else if (args.Length == 1)
            {
                Console.WriteLine("Please enter a *.json to save to as 2nd argument");
                return;
            }

            string searchTerm = args[0];
            string filePath = args[1];
            Console.WriteLine($"Searching for books in {searchTerm}");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", true)
                .AddJsonFile("appsettings.json")
                .Build();

            string apiKey = config.GetSection("GoogleApiKey").Value;
            var bookReviews = GetBookReviews(apiKey, searchTerm);
            Console.WriteLine($"Writing to {filePath} the contents");
            WriteToFile(filePath, bookReviews);
            Console.WriteLine("Done writing");
        }

        private static List<BookReviewResult> GetBookReviews(string apiKey, string searchTerm)
        {
            var bookReviews = new List<BookReviewResult>();
            var books = BooksAbstraction.GetBooks(apiKey, searchTerm);
            foreach (var book in books)
            {
                bookReviews.Add(new BookReviewResult
                {
                    Book = book,
                    Videos = VideosAbstraction.GetVideos(apiKey, book.Title)
                });
            }

            return bookReviews;
        }

        private static void WriteToFile(string file, List<BookReviewResult> results)
        {
            string json = JsonSerializer.Serialize(results, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(file, json);
        }
    }
}