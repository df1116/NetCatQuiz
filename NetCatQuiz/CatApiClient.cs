using Newtonsoft.Json;
using RestSharp;

namespace NetCatQuiz;

public class CatApiClient
{
    private readonly RestClient _restClient;

    public CatApiClient()
    {
        // Only fetch cats that have a breed by using `has_breeds=1`
        var options = new RestClientOptions("https://api.thecatapi.com/v1/images/search?has_breeds=1");
        var restClient = new RestClient(options);
        // Include the API key in all requests
        restClient.AddDefaultHeader(
            "x-api-key", 
            "live_toevpW4sD8fnEoCLIZKlYC8ke60RbZGO9bQtKSARApkF2pOWunXJBhFZt6Cb04mS");
        _restClient = restClient;
    }

    public Cat GetCat()
    {
        // Continue fetching cats until a cat with a single breed is fetched
        while (true)
        {
            var request = new RestRequest();
            var restResponse = _restClient.Get(request);

            if (restResponse.Content is null) continue;
            
            var cats = JsonConvert.DeserializeObject<IEnumerable<Cat>>(restResponse.Content);

            if (cats is null) continue;
            
            var cat = cats.ToList().First();

            if (cat.Breeds.Count() > 1) continue;

            return cat;
        }
    }
}