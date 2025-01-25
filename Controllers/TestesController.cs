using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestesController : ControllerBase
    {
        private IEnumerable<string> countries;
        public TestesController()
        {
            countries = new List<string>()
            {
                "Angola",
                "Cabo-Verde",
                "Brasil",
                "Moçambique"
            };
        }
        [HttpGet("Get-list")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(countries);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
