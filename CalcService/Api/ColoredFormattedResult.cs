using System.Text.Json.Serialization;

namespace CalcService.Api
{
    public class ColoredFormattedResult<T>(T value) : SimpleFormattedResult<T>(value)
    {
        [JsonPropertyName("color")]
        public string Color { 
            get {
                return Convert.ToDecimal(Value) % 2 != 0 ? "Red" : "Green";
            }
        }
    }
}
