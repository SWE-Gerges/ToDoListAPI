﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Infrastructure
{
    public class APIConsumer
    {
        private readonly HttpClient _httpClient;

        public APIConsumer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ReadFromAPI(string apiURL)
        {
            try
            {
                var response = await _httpClient.GetAsync(apiURL);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return data;
            }
            catch (Exception ex)
            {
                return "Error in getting data";

            }
        }
    }
}