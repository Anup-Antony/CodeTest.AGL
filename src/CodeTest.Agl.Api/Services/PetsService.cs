using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTest.Agl.Api.Constants;
using CodeTest.Agl.Api.Interfaces;
using CodeTest.Agl.Api.Models;

namespace CodeTest.Agl.Api.Services
{
    public class PetsService : IPetsService
    {
        private readonly PeopleHttpClient _peopleHttpClient;

        public PetsService(PeopleHttpClient peopleHttpClient)
        {
            _peopleHttpClient = peopleHttpClient;
        }

        public async Task<List<CatsSortedResult>> GetCatsByGenderOfOwner()
        {
            var petsOwners = await _peopleHttpClient.GetPeopleData();
            var result =
                petsOwners
                    .Where(owner =>
                        owner.Pets != null &&
                        owner.Pets.Any(pet => pet.Type.Equals(PetType.Cat)))
                    .GroupBy(owner => owner.Gender)
                    .Select(genderGroup => new CatsSortedResult
                    {
                        OwnerGender = genderGroup.Key,
                        PetNames = genderGroup
                            .SelectMany(person =>
                                person.Pets.Where(pet => pet.Type.Equals(PetType.Cat)))
                            .OrderBy(pet => pet.Name)
                            .Select(pet => pet.Name).ToList()
                    }).ToList();

            return result;
        }
    }
}
