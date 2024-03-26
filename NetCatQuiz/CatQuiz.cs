namespace NetCatQuiz;

public class CatQuiz(string imageUrl, string breed, IEnumerable<string> possibleBreeds)
{
    public string ImageUrl { get; set; } = imageUrl;

    public string Breed { get; set; } = breed;

    public IEnumerable<string> PossibleBreeds { get; set; } = possibleBreeds;
}