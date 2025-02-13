using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MotorSports.AppOne.Models;
using System.Net.Http.Headers;

namespace MotorSports.AppOne.Services
{
    class ApiService
    {
        private readonly HttpClient client;

        private readonly string baseUrl = "https://motorsportapidev-cfgddcd9awb6gedr.uaenorth-01.azurewebsites.net/api";

        public ApiService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // if API requires authentication
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Token");
        }

        // Get All Events
        public async Task<string> GetAllEvents()
        {
            return await GetApiResponse($"{baseUrl}/events");
        }

        // Get Race Results
        public async Task<string> GetRaceResults()
        {
            return await GetApiResponse($"{baseUrl}/participants/results");
        }

        // Create a new Event
        public async Task<string> CreateEvent(EventCreationRequest eventRequest)
        {
            return await PostApiResponse($"{baseUrl}/events", eventRequest);
        }

        // Assign Sponsor to Event
        public async Task<string> AssignSponsorToEvent(int eventId, int sponsorId)
        {
            var requestBody = new
            {
                EventId = eventId,
                SponsorId = sponsorId
            };

            return await PostApiResponse($"{baseUrl}/events/AddSponsor", requestBody);
        }

        public async Task<string> AssignTeamToEvent(int eventId, int teamId)
        {
            var requestBody = new
            {
                EventId = eventId,
                TeamId = teamId
            };

            // this API does not exist
            string url = $"{baseUrl}/events/AssignTeam";

            return await PostApiResponse(url, requestBody);
        }


        // Helper Method for GET Requests (with logging)
        private async Task<string> GetApiResponse(string url)
        {
            try
            {
                Console.WriteLine($"[DEBUG] Sending GET request to: {url}");

                var response = await client.GetAsync(url);
                string responseMessage = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"[DEBUG] Response: {response.StatusCode} - {responseMessage}");

                return response.IsSuccessStatusCode ? responseMessage : $"Error: {response.StatusCode} - {responseMessage}";
            }
            catch (HttpRequestException httpEx)
            {
                return $"Network error: {httpEx.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}";
            }
        }

        // Helper Method for POST Requests (with logging)
        private async Task<string> PostApiResponse(string url, object requestData)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                Console.WriteLine($"[DEBUG] Sending POST request to: {url}");
                Console.WriteLine($"[DEBUG] Request Body: {jsonContent}");

                var response = await client.PostAsync(url, content);
                string responseMessage = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"[DEBUG] Response: {response.StatusCode} - {responseMessage}");

                return response.IsSuccessStatusCode ? responseMessage : $"Error: {response.StatusCode} - {responseMessage}";
            }
            catch (HttpRequestException httpEx)
            {
                return $"Network error: {httpEx.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}";
            }
        }
    }
}
