using System.Numerics;
using CalcService.Math.Expression;
namespace CalcService.Math.Operator
{
    public class AddOperator<T> : IOperator<T> where T : INumber<T>
    {
        public string Key => "+";

        public string RegexKey => @"\+";

        public Result<T> Apply(IEnumerable<IEvaulable<T>> operands)
        {
            if (operands == null || operands.Count() != 2)
            {
                throw new ArgumentException("Wrong operands count for binary operator [+].");
            }
            var operand1 = Convert.ToDecimal(operands.ElementAt(0).Eval());
            var operand2 = Convert.ToDecimal(operands.ElementAt(1).Eval());
            T result = (T)Convert.ChangeType(operand1 + operand2, typeof(T));
            return new Result<T>(result);
        }
    }
}
