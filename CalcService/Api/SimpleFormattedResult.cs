using System.Text.Json.Serialization;

namespace CalcService.Api
{
    public class SimpleFormattedResult<T>(T value) : IFormattedResult<T>
    {
        [JsonPropertyName("result")]
        public T Value { get; private set; } = value;
    }
}
