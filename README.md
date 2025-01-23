# Hacker News API
This project is a RESTful API developed with ASP.NET Core to retrieve and display the top stories from the Hacker News API.

## Features   
- Retrieve top-rated stories.
- View details of each story, such as title, author, score, and URL.

## Requirements
- .NET 6 or higher.
- Visual Studio or any editor compatible with .NET.
- Swagger to test the endpoints.

## HOW TO USE
1. Clone the repository
   ```
   git clone https://github.com/Heredianos/SantanderInterviewAPI
2. Go to the root
   ``` 
   cd HackerNewsAPI
4. Restore package
   ```
    dotnet restore
6. Execute project
   ```
    dotnet run
7. Access to Swagger 
    http://localhost:5111/swagger
    
## EXAMPLES TO USE

GET http://localhost:5111/api/hackernews/beststories?n=5

Return of API
[
  {
    "title": "Ross Ulbricht granted a full pardon",
    "uri": "https://twitter.com/Free_Ross/status/1881851923005165704",
    "postedBy": "Ozarkian",
    "time": "2025-01-22T00:10:52.0000000+00:00",
    "score": 1793,
    "commentCount": 2089
  }
]


