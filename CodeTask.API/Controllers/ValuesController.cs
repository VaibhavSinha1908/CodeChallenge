using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CodeTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHostingEnvironment env;

        public ValuesController(IHostingEnvironment env)
        {
            this.env = env;
        }
        // GET api/values

        [HttpGet]
        public ActionResult Get()
        {

            var contentRootPath = env.ContentRootPath;
            var jsonFilePath = System.IO.Path.Combine(contentRootPath, "App_Data\\resx.json");
            var jsonObject = System.IO.File.ReadAllText(jsonFilePath);
            return Ok(jsonObject);

        }

    }
}
