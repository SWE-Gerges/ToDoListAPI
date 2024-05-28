using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Core.Models;

namespace ToDoListAPI.Infrastructure
{
    public class APIConsumer
    {
        private readonly HttpClient _httpClient;

        public APIConsumer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ToDo>> ReadFromAPI(string apiURL)
        {
            try
            {
                var response = await _httpClient.GetAsync(apiURL);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsAsync<IEnumerable<ToDo>>();
                return data;
            }
            catch (Exception ex)
            {
                return default;

            }
        }
    }
}
