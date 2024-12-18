using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Text.Json;

namespace ThAmCo.Events.Services
{
    public class VenueAvailabilityService
    {
        //https://localhost:7088/api/Availability?eventType=WED&beginDate=2022-11-01&endDate=2022-11-30
        //Get method
        public async Task<List<VenueAvailabilityDto>> GetVenueAvailabilityAsync()
        {
            HttpResponseMessage response = await MyClient();

            if (response.IsSuccessStatusCode)
            {
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Ignore case when matching keys
                };
                // Reading the response content as a string.
                var jsonResponse = await response.Content.ReadAsStringAsync();
                // Deserializing the JSON response into a list of CategoryDto objects.
                var items = JsonSerializer.Deserialize<List<VenueAvailabilityDto>>
                    (jsonResponse, jsonOptions);
                return items.ToList();
            }
            else
            {
                // TODO: an appropriate reaction to receiving a bad response
                Debug.WriteLine("Received a bad response from the web service.");
            }

            return null;

        }

        //Gets response from api
        private static async Task<HttpResponseMessage> MyClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:7088/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = await client.GetAsync("api/Availability?eventType=WED&begin" +
                "Date=2022-11-01&endDate=2022-11-30");
            return response;
        }
    }

    //dto for data relevant to the api controller
    public class VenueAvailabilityDto
    {
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int capacity { get; set; }
        public DateTime date { get; set; }
        public double costPerHour { get; set; }
    }
}