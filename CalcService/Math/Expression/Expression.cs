using CalcService.Math.Operator;
using System.Numerics;

namespace CalcService.Math.Expression
{
    public class Expression<T>(IOperator<T> oper, params IEvaulable<T>[] operands) : IEvaulable<T> where T : INumber<T>
    {
        private readonly IOperator<T> _operator = oper;
        private readonly IEnumerable<IEvaulable<T>> _operands = operands;

        public T Eval()
        {
            return _operator.Apply(_operands).Eval();
        }
    }
}
