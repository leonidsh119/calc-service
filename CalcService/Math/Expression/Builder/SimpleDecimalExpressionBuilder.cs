using CalcService.Math.Operator;
using System.Text.RegularExpressions;

namespace CalcService.Math.Expression.Builder
{
    public class SimpleDecimalExpressionBuilder : IExpressionBuilder<decimal>
    {
        private readonly ILogger _logger;
        private readonly IDictionary<string, IOperator<decimal>> _operators;
        private readonly Regex _decimalMatcher;
        private readonly Regex _operatorMatcher;

        public SimpleDecimalExpressionBuilder(ILogger<SimpleDecimalExpressionBuilder> logger, IEnumerable<IOperator<decimal>> operators)
        {
            _logger = logger;
            _operators = operators.ToDictionary(x => x.Key, x => x);
            _decimalMatcher = new Regex(@"\G([\s,\t]*)([\+,-]?)([0-9]+)([.]([0-9]+))?([\s,\t]*)");
            string operatorMatcherPattern = @"\G(" + string.Join("|", _operators.Values.Select(x => x.RegexKey)) + ")";
            _logger.LogTrace("Creating Operator Matcher with pattern [{}].", operatorMatcherPattern);
            _operatorMatcher = new Regex(operatorMatcherPattern);
        }

        public IEvaulable<decimal> Build(string expression)
        {
            int matchIdx = 0;
            var operand1 = MatchDecimal(expression, ref matchIdx);
            var oper = MatchOperator(expression, ref matchIdx);
            var operand2 = MatchDecimal(expression, ref matchIdx);
            _logger.LogTrace("Building expression [{} {} {}]", operand1.Value, oper.Key, operand2.Value);
            return new Expression<decimal>(oper, operand1, operand2);
        }

        protected IOperator<decimal> MatchOperator(string expression, ref int matchIdx)
        {
            _logger.LogTrace("Matching operator at index {}", matchIdx);
            Match matchedOperator = _operatorMatcher.Match(expression, matchIdx);
            if (!matchedOperator.Success)
            {
                throw new Exception(string.Format("Failed to match an OPERATOR at index [{0}] in expression [{1}] using SimpleDecimalExpressionBuilder. Check that the operator implementing class is registered in the OperatorRegistry.", matchIdx, expression));
            }
            _logger.LogTrace("Matchied operator {} at index {}", matchedOperator.Value, matchIdx);
            matchIdx += matchedOperator.Length;
            return _operators[matchedOperator.Value.Trim()];
        }

        protected Result<decimal> MatchDecimal(string expression, ref int matchIdx)
        {
            _logger.LogTrace("Matching decimal at index {}", matchIdx);
            Match matchedDecimal = _decimalMatcher.Match(expression, matchIdx);
            if (!matchedDecimal.Success)
            {
                throw new Exception(string.Format("Failed to match a DECIMAL at index [{0}] in expression [{1}] using SimpleDecimalExpressionBuilder.", matchIdx, expression));
            }
            _logger.LogTrace("Matchied decimal {} at index {}", matchedDecimal.Value, matchIdx);
            matchIdx += matchedDecimal.Length;
            return new Result<decimal>(decimal.Parse(matchedDecimal.Value.Trim()));
        }
    }
}
