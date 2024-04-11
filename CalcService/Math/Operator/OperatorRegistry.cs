using CalcService.Math.Expression.Builder;

namespace CalcService.Math.Operator
{
    public static class OperatorRegistry
    {
        public static IServiceCollection AddOperators(this IServiceCollection services)
        {
            services.AddSingleton<IOperator<decimal>, AddOperator<decimal>>();
            services.AddSingleton<IOperator<decimal>, SubtractOperator<decimal>>();
            services.AddSingleton<IOperator<decimal>, MultiplyOperator<decimal>>();
            services.AddSingleton<IOperator<decimal>, DivideOperator<decimal>>();
            return services;
        }

        public static IServiceCollection AddParsers(this IServiceCollection services, IConfiguration configuration)
        {
            string key = configuration["ExpressionBuilderKey"];
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception(string.Format("Missing Expression Builder configuration."));
            }
            switch (key) {
                case "SDEB":
                    services.AddSingleton<IExpressionBuilder<decimal>, SimpleDecimalExpressionBuilder>();
                    break;
                default:
                    throw new NotImplementedException(string.Format("Unsupported Expression Builder key [{0}]", key));
            }
            return services;
        }
    }
}
