using Weekdays.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Weekdays.Controllers
{
    [Route("v1/[controller]")]
    public class DefaultController : ControllerBase
    {
        private const string ErrorMessage = "failed to process request";

        private readonly ICalculationService _calculationService;

        public DefaultController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeekdays(string from, string to)
        {
            int count = -1;

            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                count = await _calculationService.GetWeekdays(from, to);
            };

            if (count < 0) return BadRequest(ErrorMessage);
           
            return Ok(JsonConvert.SerializeObject(count));
        }
    }
}