using ExampleService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CalcController(ICalcService calcService, ILogger<CalcController> logger)
    {
        private readonly ICalcService _calcService = calcService;
        private readonly ILogger<CalcController> _logger = logger;

        [HttpGet(Name = "calc")]
        public int Calc(int a, int b)
        {
            _logger.LogTrace($"Calc request: [{a} + {b}].");
            return _calcService.calc(a, b);
        }
    }
}
