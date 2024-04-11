using CalcService.Api;
using CalcService.Math.Operator;

namespace CalcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            builder.Services.AddOperators();
            builder.Services.AddParsers(builder.Configuration);
            builder.Services.AddResultFormatters();

            var app = builder.Build();
            app.UseHealthChecks("/_health");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
