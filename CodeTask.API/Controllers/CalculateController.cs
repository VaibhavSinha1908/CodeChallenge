using CodeTask.API.Models;
using CodeTask.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly IPremiumService _premiumService;
        private readonly IHostingEnvironment env;

        public CalculateController(IPremiumService service, IHostingEnvironment env)
        {
            this._premiumService = service;
            this.env = env;
        }
        // GET: api/Calculate
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Calculate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Calculate
        [HttpPost]
        public ActionResult CalculatePremium([FromBody] PremiumCalculationRequest obj)
        {
            var result = _premiumService.Calculate(obj, env);
            return Ok(result);
        }

        // PUT: api/Calculate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
