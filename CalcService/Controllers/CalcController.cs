using CalcService.Api;
using CalcService.Math.Expression;
using CalcService.Math.Expression.Builder;
using Microsoft.AspNetCore.Mvc;

namespace CalcService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CalcController(ILogger<CalcController> logger, IExpressionBuilder<decimal> builder, IResultFormatter<decimal> formatter)
    {
        private readonly ILogger<CalcController> _logger = logger;
        private readonly IExpressionBuilder<decimal> _builder = builder;
        private readonly IResultFormatter<decimal> _formatter = formatter;

        [HttpGet(Name = "calc")]
        public IFormattedResult<decimal> CalcDecimal(string expressionString, string resultFormat = "simple")
        {
            _logger.LogTrace($"Calc request: [{expressionString}].");
            IEvaulable<decimal> expression = _builder.Build(expressionString);
            decimal result = expression.Eval();
            return _formatter.FormatResult(result, resultFormat);
        }
    }
}
