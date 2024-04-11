using System.Numerics;

namespace CalcService.Api
{
    public class ResultFormatter<T> : IResultFormatter<T> where T : INumber<T>
    {
        public IFormattedResult<T> FormatResult(T result, string format)
        {
            switch(format) {            
                case "simple": return new SimpleFormattedResult<T>(result);
                case "colored": return new ColoredFormattedResult<T>(result);
                default: return new SimpleFormattedResult<T>(result);
            }
        }
    }
}
