using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MotorSports.AppOne.Models;

namespace MotorSports.AppOne.Services
{
    public class ApiService
    {
        private readonly HttpClient client;
        private const string BaseUrl = "https://motorsportapidev-cfgddcd9awb6gedr.uaenorth-01.azurewebsites.net/api";

        public ApiService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //  Event APIs
        public Task<string> GetAllEvents() => Get($"{BaseUrl}/events");
        public Task<string> GetRaceResults() => Get($"{BaseUrl}/participants/results");
        public Task<string> CreateEvent(EventCreationRequest request) => Post($"{BaseUrl}/events", request);
        public Task<string> AssignSponsorToEvent(int eventId, int sponsorId) => Post($"{BaseUrl}/events/AddSponsor", new { EventId = eventId, SponsorId = sponsorId });
        public Task<string> AssignTeamToEvent(int eventId, int teamId) => Post($"{BaseUrl}/events/AssignTeam", new { EventId = eventId, TeamId = teamId });

        //  Admin APIs
        public Task<string> AssignRoleToUser(int userId, int roleId) => Post($"{BaseUrl}/admin/AssignRole", new { UserId = userId, RoleId = roleId });
        public Task<string> RemoveUserRole(int userId, int roleId) => Delete($"{BaseUrl}/admin/Role", new { UserId = userId, RoleId = roleId });
        public Task<string> GetAllEventStatuses() => Get($"{BaseUrl}/admin/AllStatuses");

        //Participant APIs
        public Task<string> RegisterTeamForRace(RaceRegistration registration)
    => Post($"{BaseUrl}/participants", registration);


        // ✅ Get Users and Roles (Updated)
        public async Task<List<UserRole>> GetUsersAndRoles()
        {
            try
            {
                var response = await client.GetAsync($"{BaseUrl}/admin/AllRoles");
                if (!response.IsSuccessStatusCode) return new List<UserRole>();

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<UserRole>>(json) ?? new List<UserRole>();
            }
            catch
            {
                return new List<UserRole>();
            }
        }

        //  Helper Methods
        private async Task<string> Get(string url)
        {
            var response = await client.GetAsync(url);
            return await HandleResponse(response);
        }

        private async Task<string> Post(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            return await HandleResponse(response);
        }

        private async Task<string> Delete(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Delete, url) { Content = content };
            var response = await client.SendAsync(request);
            return await HandleResponse(response);
        }

        private static async Task<string> HandleResponse(HttpResponseMessage response)
        {
            string message = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode ? message : $"Error: {response.StatusCode} - {message}";
        }
    }
}
