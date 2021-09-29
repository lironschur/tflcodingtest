using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace RoadStatusChecker
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            if (args.Length != 1 || !Regex.IsMatch(args[0], RoadStatusCheckerApp.RoadIdPattern))
            {
                serviceProvider.GetRequiredService<IConsoleLogger>().WriteLine($"Usage: {Assembly.GetExecutingAssembly().GetName().Name} <road id>");
                return RoadStatusCheckerApp.ExitCodes.BadInput;
            }

            var roadStatusCheckerApp = serviceProvider.GetRequiredService<RoadStatusCheckerApp>();
            var exitCode = await roadStatusCheckerApp.GetRoadStatusAsync(args[0]);
            return exitCode;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConsoleLogger, ConsoleLogger>();
            services.AddSingleton<RoadStatusCheckerApp>();
        }
    }
}
