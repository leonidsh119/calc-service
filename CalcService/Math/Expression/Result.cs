using System.Numerics;

namespace CalcService.Math.Expression
{
    public class Result<T>(T value) : IEvaulable<T> where T : INumber<T>
    {
        public T Value { get; private set; } = value;

        public T Eval()
        {
            return Value;
        }
    }
}
