using System.Threading.Tasks;
using CodeTest.Agl.Api.Interfaces;
using CodeTest.Agl.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Agl.Api.Controllers
{
    [Route("pets")]
    public class PetsController: Controller
    {
        private readonly IPetsService _petsService;
        public PetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        /// <summary>
        /// Gets cats sorted by gender of owner
        /// </summary>
        /// <response code="200">Returns list of sorted cat names categorized by the gender of their owners </response>
        /// <response code="500">Internal Server Error</response>   
        [HttpGet()]
        [Route("catsSorted")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CatsSortedResult>> GetCatsSortedByOwnerGender()
        {
            var res = await _petsService.GetCatsByGenderOfOwner();
            return Ok(res);
        }
    }
}
