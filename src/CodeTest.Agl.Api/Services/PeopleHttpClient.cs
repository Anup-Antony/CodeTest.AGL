using System;
using System.Net.Http;
using System.Threading.Tasks;
using CodeTest.Agl.Api.Configuration;
using Microsoft.Extensions.Options;

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

        public async Task GetPeopleData()
        {
            var response = await _httpClient.GetAsync(_peopleApiSettings.CurrentValue.ApiEndpoint);
            var data = await response.Content.ReadAsStringAsync();
        }
    }
}
