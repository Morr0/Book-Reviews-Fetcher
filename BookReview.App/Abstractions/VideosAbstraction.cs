using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace BookReview.App.Abstractions
{
    public static class VideosAbstraction
    {
        private static string YoutubeUrl = "https://www.youtube.com/watch?v=";
        
        public static List<Video> GetVideos(string apiKey, string bookTitle)
        {
            using var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "BookReview"
            });

            var searchRequest = youtubeService.Search.List("snippet");
            searchRequest.Q = $"{bookTitle} Book Review";
            searchRequest.MaxResults = 5;
            searchRequest.Type = "video";

            var searchResponse = searchRequest.Execute();
            return MapResponseToVideosModel(searchResponse.Items);
        }

        private static List<Video> MapResponseToVideosModel(IList<SearchResult> results)
        {
            var videos = new List<Video>();
    
            foreach (var result in results)
            {
                var video = new Video();
                videos.Add(video);

                video.Title = result.Snippet.Title;
                video.Url = $"{YoutubeUrl}{result.Id.VideoId}";
            }
            
            return videos;
        }
    }
}