using System;
using System.IO;
using BookReview.App.Abstractions;
using Google.Apis.Books.v1;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;

namespace BookReview.App
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a topic");
                return;
            }

            string searchTerm = args[0];
            Console.WriteLine(searchTerm);

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", true)
                .AddJsonFile("appsettings.json")
                .Build();

            string apiKey = config.GetSection("GoogleApiKey").Value;

            var books = BooksAbstraction.GetBooks(apiKey, searchTerm);
            foreach (var book in books)
            {
                Console.WriteLine($"Book");
                foreach (var prop in book.GetType().GetProperties())
                {
                    Console.WriteLine($"-{prop.Name}: {prop.GetValue(book)}");
                }
            }
        }
    }
}