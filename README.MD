# Books Reviews Fetcher
This project is a result of an article I wrote at:
https://www.ramihikmat.net/Article/2021/topic-books-and-reviews-aggregator%3A-using-c%23-and-google%27s-books-and-youtube-apis

## Description
Feed this program a one-word topic to search using the Google Books API V1 for a max of 10 books. For each
book, will search for a max of 5 youtube videos as reviews using the Youtube Data V3 API. Then will group
results into book and review and all written to a specified json file.

## How to Use
```c#
dotnet restore
dotnet run <Topic> <File path>
```

## Technical description
Uses the Google client libraries. The `Abstractions` directory holds the abstractions for things I need from
the API so I don't have plenty of details I don't need.

**Feel free to customize it as you wish**.