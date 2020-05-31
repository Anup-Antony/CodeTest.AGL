using System.Collections.Generic;
using CodeTest.Agl.Api.Constants;

namespace CodeTest.Agl.Api.Models
{
    public class PetsOwner
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
