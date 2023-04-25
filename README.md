# FilmSystemAPIUsingRepositoryPattern
### This Film System API made by using REST architecture and this API is built using MVC pattern.
This is a Film System API that allows you to manage people, genres, movies, and movie ratings. 

# Endpoints.

###  (Get) all people in the system.

Get all people in the system. (Need to add a person first, then you can run this function).

HTTP method: GET
Endpoint: https://localhost:7146/Person/GetAllPeople

Example Response:
### Example Response

```
[
  {
    "personId": 5,
    "name": "Dipayan Sarker",
    "email": "dipayan@chas.se"
  },
  {
    "personId": 2,
    "name": "Kristian",
    "email": "kristian@chas.se"
  }
]
```

###  (Get) all genres associated with a specific person.
Get all genres associated with a specific person. (Need to do Add Person & Add Genre and AddToNewGenre(Person) first, then you can run this function).

HTTP method: GET
Endpoint: https://localhost:7146/Genre/GetAllGenreByPersonID/{personId}

Example Response:
```
{
  "personId": 1,
  "name": "Ruhul Amin",
  "email": "ruhul@chas.se",
  "genres": [
    {
      "id": 1,
      "title": "Action",
      "description": "AcitonBased Movies"
    },
    {
      "id": 2,
      "title": "Comedy",
      "description": "ComedyBased Movies"
    }   
  ]
}
``` 
###  Download all videos associated with a specific person.
Download all videos associated with a specific person. (Need to add a person, genre, and movie first, then you can run this function).

HTTP method: GET
Endpoint: https://localhost:7146/Movie/GetAllMoviesByPersonId/{personId}

Example Response:
```
[
  {
    "movieId": 1,
    "link": "https://www.themoviedb.org/movie/502356-the-super-mario-bros-movie"
  },
  {
    "movieId": 2,
    "link": "https://www.themoviedb.org/movie/842945-supercell"
  }
]
```
###  Enter and retrieve "rating" on films linked to a person.
Enter and retrieve "rating" on films linked to a person. (Need to add a person, genre, movie, and movie rating first using POST method, then you can run this function).

HTTP method: POST (to create a new rating) or GET (to retrieve an existing rating)
Endpoint POST: https://localhost:7146/Person/Add/MovieRatings{personId}{movieId}{rating}

Example Request:
```
{
  "personId": 2,
  "movieId": 4,
  "rating": 9
}
```

### Endpoint GET: https://localhost:7146/Movie/GetAllRatingsByPersonId/{personId}
Example Response:
```
[
  {
    "movieId": 1,
    "link": "https://www.themoviedb.org/movie/842945-supercell",
    "rating": 6
  },
  {
    "movieId": 2,
    "link": "https://www.themoviedb.org/movie/502356-the-super-mario-bros-movie",
    "rating": 7
  }
]
```

### Connect a person to a new genre
HTTP method: POST
Endpoint: https://localhost:7146/Person/AddToNewGenre{PersonId}{GenreID}

Example: You need to give PersonId and GenreId to connect a person to a new Genre t.ex: 
```
'{
  "personId": 5,
  "genreId": 3
}'
```

## Posting new links for a specific person and a specific genre
HTTP method: POST
Endpoint:https://localhost:7146/Movie/Add{PersonId}{GenreId}{link}

Example:
```
{
"personId": 5,
  "genreId": 4,
  "link": "Batman.se"
}
```

## Get suggestions for movies in a certain genre from an external API, eg TMDB
—For this you can use TMDB/GetAllGenres EndPoint to see the GenreId and then use that GenreId to get Movie Suggestions from TMDB
HTTP method: GET
Endpoint: https://localhost:7146/TMDB/TMDB/GetMoviesByGenreId/{GenreId}

Example:
```
{"results":[{"id":502356,"title":"The Super Mario Bros. Movie","overview":"While working underground to fix a water main, Brooklyn plumbers—and brothers—Mario and Luigi are transported down a mysterious pipe and wander into a magical new world. But when the brothers are separated, Mario embarks on an epic quest to find Luigi.","poster_path":"/qNBAXBIQlnOThrVvA6mA2B5ggV6.jpg","release_date":"2023-04-05T00:00:00","vote_average":7.5}```



