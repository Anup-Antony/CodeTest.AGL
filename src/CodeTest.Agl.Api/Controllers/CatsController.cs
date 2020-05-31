using System.Threading.Tasks;
using CodeTest.Agl.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Agl.Api.Controllers
{
    [Route("pets")]
    public class CatsController: Controller
    {
        private readonly IPetsService _petsService;
        public CatsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        [HttpGet]
        [Route("catsSorted")]
        public async Task<IActionResult> GetCatsSortedByOwnerGender()
        {
            var res = _petsService.GetCatsByGenderOfOwner();
            return Ok();
        }
    }
}
