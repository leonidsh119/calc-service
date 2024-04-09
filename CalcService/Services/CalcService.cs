namespace ExampleService.Services
{
    public class CalcService(ILogger<CalcService> logger) : ICalcService
    {
        private readonly ILogger<CalcService> _logger = logger;

        public int calc(int a, int b)
        {
            var result = a + b;
            _logger.LogTrace($"{a} + {b} = {result}");
            return result;
        }

    }
}
