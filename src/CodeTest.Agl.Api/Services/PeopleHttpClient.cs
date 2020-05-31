using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CodeTest.Agl.Api.Configuration;
using CodeTest.Agl.Api.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CodeTest.Agl.Api.Services
{
    public class PeopleHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOptionsMonitor<PeopleApiSettings> _peopleApiSettings;

        public PeopleHttpClient(HttpClient client, IOptionsMonitor<PeopleApiSettings> peopleApiSettings)
        {
            client.BaseAddress = new Uri(peopleApiSettings.CurrentValue.BaseUrl);
            _httpClient = client;
            _peopleApiSettings = peopleApiSettings;
        }

        public async Task<List<PetsOwner>> GetPeopleData()
        {
            var response = await _httpClient.GetAsync(_peopleApiSettings.CurrentValue.ApiEndpoint);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<PetsOwner>>(data);
            return result;
        }
    }
}
