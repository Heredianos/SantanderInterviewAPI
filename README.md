# Hacker News API

Este proyecto es una API RESTful desarrollada con ASP.NET Core para recuperar y mostrar las mejores historias de la API de Hacker News.

## Funcionalidades
- Recuperar las historias mejor calificadas.
- Ver detalles de cada historia, como título, autor, puntaje, y URL.

## Requisitos
- .NET 6 o superior.
- Visual Studio o cualquier editor compatible con .NET.
- [Swagger](https://swagger.io/) para probar los endpoints.

## HOW TO USE
1. Clone the repository
   ```bash
   git clone <url-del-repositorio>
2. Go to the root 
   cd HackerNewsAPI
3. Restore package
    dotnet restore
4. Execute project
    dotnet run
5. Access to Swagger 
    http://localhost:5111/swagger
    
## EXAMPLES TO USE

GET http://localhost:5111/api/hackernews/beststories?n=5

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


