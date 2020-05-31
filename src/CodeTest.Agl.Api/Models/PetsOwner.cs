using System.Collections.Generic;

namespace CodeTest.Agl.Api.Models
{
    public class PetsOwner
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
