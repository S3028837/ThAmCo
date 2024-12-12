using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

public class GetVenue
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new System.Uri("http://localhost:7011/");
        client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

        HttpResponseMessage response = await client.GetAsync("api/venue");
        if (response.IsSuccessStatusCode)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Ignore case when matching keys
            };
            // Reading the response content as a string.
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserializing the JSON response into a list of CategoryDto objects.
            var items = JsonSerializer.Deserialize<List<Venue>>(jsonResponse, jsonOptions);
        }
        else
        {
            // TODO: an appropriate reaction to receiving a bad response
            Debug.WriteLine("Received a bad response from the web service.");
        }
    }
}
