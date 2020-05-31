using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Agl.Api.Controllers
{
    [Route("pets")]
    public class CatsController: Controller
    {
        public CatsController()
        {
            
        }

        [HttpGet]
        [Route("catsSorted")]
        public async Task<IActionResult> GetCatsSortedByOwnerGender()
        {
            return Ok();
        }
    }
}
