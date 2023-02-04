using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producer.VK_API;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VK_APIController : ControllerBase
    {
        private readonly IVK_API VKservice;

		public VK_APIController(IVK_API vkService)
		{
			VKservice = vkService;
		}

		[Route("[action]/{message}")]
		[HttpGet]
		public IActionResult StartMethod()
		{
			VKservice.StartMethod();

			return Ok("VK API работает");
		}
	}
}
