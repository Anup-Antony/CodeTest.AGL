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
        public async Task GetCatsByGenderOfOwner()
        {
            var petsOwners = await _peopleHttpClient.GetPeopleData();
        }
    }
}
