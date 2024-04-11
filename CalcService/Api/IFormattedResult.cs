namespace CalcService.Api
{
    public interface IFormattedResult<T>
    {
        T Value { get; }
    }
}
