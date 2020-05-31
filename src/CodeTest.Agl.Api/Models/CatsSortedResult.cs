using System.Collections.Generic;
using CodeTest.Agl.Api.Constants;

namespace CodeTest.Agl.Api.Models
{
    public class CatsSortedResult
    {
        public Gender OwnerGender { get; set; }
        public List<string> PetNames { get; set; }
    }
}
