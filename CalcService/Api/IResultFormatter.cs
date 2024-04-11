using System.Numerics;

namespace CalcService.Api
{
    public interface IResultFormatter<T> where T : INumber<T>
    {
        IFormattedResult<T> FormatResult(T result, string format);
    }
}
