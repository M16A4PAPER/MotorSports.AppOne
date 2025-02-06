using Microsoft.AspNetCore.Mvc;
using MotorSports.AppOne.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MotorSports.AppOne.Services
{
     class ApiService
    {
        readonly HttpClient client = new();
        string apiUrl = "https://motorsportapidev-cfgddcd9awb6gedr.uaenorth-01.azurewebsites.net/api/events";

        public async Task<string> GetAllEvents()
        {
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

        public async Task<string> GetRaceResults()
        {
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

        public async Task<string> CreateEvent(EventCreationRequest eventRequest)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(eventRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync(); // Success response
                }
                else
                {
                    // Get detailed error message
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return $"Error: {response.StatusCode} - {errorMessage}";
                }
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
