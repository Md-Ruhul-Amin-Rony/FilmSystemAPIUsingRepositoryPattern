# FilmSystemAPIUsingRepositoryPattern
### This Film System API made by using REST architecture and this API is built using MVC pattern.
This is a Film System System API that allows you to manage people, genres, movies, and movie ratings. 

# Endpoints
Get all people in the system
Get all people in the system. (Need to add a person first, then you can run this function).

HTTP method: GET
Endpoint: https://localhost:7146/Person/GetAllPeople

Example Response:


[
  {
    "personId": 5,
    "name": "Dipayan Sarker",
    "email": "dipayan@chas.se"
  },
  {
    "personId": 2,
    "name": "Kamrul Hasan",
    "email": "kamrul@chas.se"
  }
]
Get all genres associated with a specific person
Get all genres associated with a specific person. (Need to do Add Person & Add Genre and AddToNewGenre(Person) first, then you can run this function).

HTTP method: GET
Endpoint: https://localhost:7146/Genre/GetAllGenreByPersonID/{personId}

Example Response:


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
Download all videos associated with a specific person
Download all videos associated with a specific person. (Need to add a person, genre, and movie first, then you can run this function).

HTTP method: GET
Endpoint: https://localhost:7146/Movie/GetAllMoviesByPersonId/{personId}

Example Response:

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
Enter and retrieve "rating" on films linked to a person
Enter and retrieve "rating" on films linked to a person. (Need to add a person, genre, movie, and movie rating first using POST method, then you can run this function).

HTTP method: POST (to create a new rating) or GET (to retrieve an existing rating)
Endpoint POST: https://localhost:7146/Person/Add/MovieRatings

Example Request:

{
  "personId": 2,
  "movieId": 4,
  "rating": 9
}
Example Response:


{
  "personId": 2,
  "name": "Kamrul Hasan",
  "email": "kamrul@chas.se",
  "movies": [
    {
      "id": 4,
      "link": "Devdas.se",
      "ratings": 9
    }
  ]
}