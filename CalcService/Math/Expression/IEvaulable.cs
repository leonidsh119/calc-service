using System.Numerics;

namespace CalcService.Math.Expression
{
    public interface IEvaulable<T> where T : INumber<T>
    {
        T Eval();
    }
}
