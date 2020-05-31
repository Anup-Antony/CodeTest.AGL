using System.Threading.Tasks;
using CodeTest.Agl.Api.Interfaces;

namespace CodeTest.Agl.Api.Services
{
    public class PetsService : IPetsService
    {
        private readonly PeopleHttpClient _peopleHttpClient;

        public PetsService(PeopleHttpClient peopleHttpClient)
        {
            _peopleHttpClient = peopleHttpClient;
        }
        public Task GetCatsByGenderOfOwner()
        {
            throw new System.NotImplementedException();
        }
    }
}
