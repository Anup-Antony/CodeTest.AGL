using System.Collections.Generic;
using CodeTest.Agl.Api.Constants;
using CodeTest.Agl.Api.Models;

namespace CodeTest.Agl.Api.Tests.TestDataBuilder
{
    public class PeopleApiResponseBuilder
    {
        private readonly List<PetsOwner> _petOwnersResult;
        private PeopleApiResponseBuilder()
        {
            _petOwnersResult = new List<PetsOwner>();
        }

        public List<PetsOwner> Build()
        {
            return _petOwnersResult;
        }

        public static PeopleApiResponseBuilder GiveEmptyResponse()
        {
            return new PeopleApiResponseBuilder();
        }

        public PeopleApiResponseBuilder AddMaleOwnerWithPet(PetType petType, string petName)
        {
            _petOwnersResult.Add(new PetsOwner
            {
                Gender = Gender.Male,
                Pets = new List<Pet>
                {
                    new Pet
                    {
                        Name = petName,
                        Type = petType
                    }
                }
            });
            return this;
        }

        public PeopleApiResponseBuilder AddFemaleOwnerWithPet(PetType petType, string petName)
        {
            _petOwnersResult.Add(new PetsOwner
            {
                Gender = Gender.Female,
                Pets = new List<Pet>
                {
                    new Pet
                    {
                        Name = petName,
                        Type = petType
                    }
                }
            });
            return this;
        }
    }
}
