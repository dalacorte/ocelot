using Microsoft.AspNetCore.Mvc;

namespace NeptuneAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UranusController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                var builder = new UriBuilder("https://api.le-systeme-solaire.net/rest.php/bodies/uranus");

                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(builder.ToString())
                };

                var response = await client.SendAsync(httpRequest);

                return Ok(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
