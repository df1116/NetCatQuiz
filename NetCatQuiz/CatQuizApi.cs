namespace NetCatQuiz;

public class CatQuizApi
{
    private readonly CatApiClient _catApiClient = new();

    private readonly CatQuizService _catQuizService = new();

    // All breeds of cats
    private static readonly List<string> AllBreeds = [
        "Abyssinian", "Aegean", "American Bobtail", "American Curl", "American Shorthair",
        "American Wirehair", "Arabian Mau", "Australian Mist", "Balinese", "Bambino",
        "Bengal", "Birman", "Bombay", "British Longhair", "British Shorthair", "Burmese",
        "Burmilla", "California Spangled", "Chantilly-Tiffany", "Chartreux", "Chausie",
        "Cheetoh", "Colorpoint Shorthair", "Cornish Rex", "Cymric", "Cyprus", "Devon Rex",
        "Donskoy", "Dragon Li", "Egyptian Mau", "European Burmese", "Exotic Shorthair",
        "Havana Brown", "Himalayan", "Japanese Bobtail", "Javanese", "Khao Manee", "Korat",
        "Kurilian", "LaPerm", "Maine Coon", "Malayan", "Manx", "Munchkin", "Nebelung",
        "Norwegian Forest Cat", "Ocicat", "Oriental", "Persian", "Pixie-bob", "Ragamuffin",
        "Ragdoll", "Russian Blue", "Savannah", "Scottish Fold", "Selkirk Rex", "Siamese",
        "Siberian", "Singapura", "Snowshoe", "Somali", "Sphynx", "Tonkinese", "Toyger",
        "Turkish Angora", "Turkish Van", "York Chocolate"
    ];

    public CatQuiz GetCatQuiz()
    {
        var cat = _catApiClient.GetCat();

        var breed = cat.Breeds.First().Name;

        var randomBreeds = GetRandomBreeds(breed);

        return new CatQuiz(cat.Url, breed, randomBreeds);
    }
    
    public void GradeCatQuiz(string userId, bool correct)
    {
        _catQuizService.GradeCatQuiz(userId, correct);
    }
    
    public IEnumerable<(string name, int score)> GetLeaderboard()
    {
        return _catQuizService.GetLeaderboard();
    }

    // Gets 4 random breeds of cats that aren't the supplied one 
    private static IEnumerable<string> GetRandomBreeds(string givenBreed)
    {
        var rand = new Random();
        var randomBreeds = AllBreeds
            .Where(b => b != givenBreed)
            .OrderBy(_ => rand.Next())
            .Take(4);
        return randomBreeds;
    }
}