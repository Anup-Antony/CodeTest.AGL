using System.Collections.Generic;
using System.Threading.Tasks;
using CodeTest.Agl.Api.Models;

namespace CodeTest.Agl.Api.Interfaces
{
    public interface IPetsService
    {
        Task<List<CatsSortedResult>> GetCatsByGenderOfOwner();
    }
}
