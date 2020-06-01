using System.Collections.Generic;
using System.Threading.Tasks;
using CodeTest.Agl.Api.Constants;
using CodeTest.Agl.Api.Interfaces;
using CodeTest.Agl.Api.Models;
using CodeTest.Agl.Api.Services;
using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using Xunit;

namespace CodeTest.Agl.Api.Tests
{
    public class PetsServiceTests
    {
        private readonly IPeopleHttpClient _peopleHttpClient;
        private readonly IPetsService _petsService;
        public PetsServiceTests()
        {
            _peopleHttpClient = Substitute.For<IPeopleHttpClient>();
            _petsService = new PetsService(_peopleHttpClient);
        }

        [Fact]
        public async Task SuccessfullyCategorizeCatsWhenPeopleApiResponds()
        {
            var json =
                "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
            var peopleApiResponse = JsonConvert.DeserializeObject<List<PetsOwner>>(json);

            _peopleHttpClient.GetPeopleData().Returns(peopleApiResponse);
            var result = await _petsService.GetCatsByGenderOfOwner();

            result[0].OwnerGender.Should().Be(Gender.Male);
            result[0].PetNames.Should().NotBeEmpty();
            result[0].PetNames.Count.Should().Be(4);

            result[1].OwnerGender.Should().Be(Gender.Female);
            result[1].PetNames.Should().NotBeEmpty();
            result[1].PetNames.Count.Should().Be(3);

        }

        [Fact]
        public async Task NoCategorizationWhenPeopleApiReturnsEmpty()
        {
            var json = "[]";
            var peopleApiResponse = JsonConvert.DeserializeObject<List<PetsOwner>>(json);

            _peopleHttpClient.GetPeopleData().Returns(peopleApiResponse);
            var result = await _petsService.GetCatsByGenderOfOwner();

            result.Count.Should().Be(0);

        }
    }
}
