using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.AppOne.Services
{
    class EventApiService
    {
        readonly HttpClient client = new();

        public async Task<string> GetAllEvents()
        {
            string apiUrl = "https://localhost:7060/api/events";

            string jsonString = string.Empty;

            try
            {
                var result = await client.GetAsync(apiUrl);

                if (result.IsSuccessStatusCode)
                {
                    jsonString = await result.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"API Error: {result.StatusCode}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception: {ex.Message}");
            }

            return jsonString;
        }

    }
}
