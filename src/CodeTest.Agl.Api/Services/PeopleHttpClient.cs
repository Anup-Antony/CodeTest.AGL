using System;
using System.Net.Http;

namespace CodeTest.Agl.Api.Services
{
    public class PeopleHttpClient
    {
        private readonly HttpClient _httpClient;
        public PeopleHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://agl-developer-test.azurewebsites.net/");
            _httpClient = client;
        }
    }
}
