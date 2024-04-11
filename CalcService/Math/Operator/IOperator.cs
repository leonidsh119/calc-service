using System.Numerics;
using CalcService.Math.Expression;

namespace CalcService.Math.Operator
{
    public interface IOperator<T> where T : INumber<T>
    {
        string Key { get; }

        string RegexKey { get; }

        Result<T> Apply(IEnumerable<IEvaulable<T>> operands);
    }
}
