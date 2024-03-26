# Net Cat Quiz

Set of API endpoints to be used for a website that tests and ranks users knowledge 
of cat breeds.

## Endpoints

To interact with the endpoints, run the C# application by:
- Running the application from Visual Studio/Rider
- Running `dotnet run NetCatQuiz` on the command line in the folder that the
  application lives in

And then head to `http://localhost:5067/swagger/index.html`.

#### **GET** GetCatQuiz
Gets a new instance of a Cat Quiz which includes the URL of 
the image of the cat, the breed of said cat and 4 random cat breeds. For example:
```
{
  "imageUrl": "https://cdn2.thecatapi.com/images/hYG6uIRWL.jpg",
  "breed": "Himalayan",
  "possibleBreeds": [
    "Cheetoh",
    "American Bobtail",
    "Turkish Angora",
    "Turkish Van"
  ]
}
```
#### **POST** GradeCatQuiz
Sends the result of a Cat Quiz back to the system to be added to the Leaderboard. The endpoint has
two parameters:
- `userId`: string uniquely identifying user ID
- `correct`: bool representing whether the user's answer was correct or not

#### **GET** GetLeaderboard
Gets the Leaderboard of the Cat Quiz. The returned object is a list of tuples of user IDs and scores
as a percentage. For example:
```
[
    ("aeg547", 86),
    ("aske12", 81),
    ("mfas91", 72),
    ("asd172", 97),
    ("jsad81", 64)
]
```