using System.Numerics;

namespace CalcService.Math.Expression.Builder
{
    public interface IExpressionBuilder<T> where T : INumber<T>
    {
        IEvaulable<T> Build(string expression);
    }
}
