
using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;
using System.Text.Json;

namespace ThAmCo.Events.Services
{
    public class EventTypeService
    {


      public EventTypeService() { }


        // https://localhost:7088/api/eventtypes
        public async Task<List<EventTypeDTO>> GetEventTypesAsync()
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
                var items = JsonSerializer.Deserialize<List<EventTypeDTO>>(jsonResponse, jsonOptions);
                return items.ToList();
            }
            else
            {
                // TODO: an appropriate reaction to receiving a bad response
                Debug.WriteLine("Received a bad response from the web service.");
            }

            return null;

        }

        private static async Task<HttpResponseMessage> MyClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:7088/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = await client.GetAsync("api/eventtypes");
            return response;
        }
    }


    // {"id":"CON","title":"Conference"}
    public class EventTypeDTO
    {
        public string id { get; set; }
        public string title { get; set; }
    }
}
