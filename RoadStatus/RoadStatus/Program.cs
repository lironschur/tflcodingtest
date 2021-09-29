using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RoadStatus.Domain;
using RoadStatus.Repository;
using RoadStatus.Service;

namespace RoadStatus
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            if (args.Length != 1 || !Regex.IsMatch(args[0], RoadStatusApp.RoadIdPattern))
            {
                serviceProvider.GetRequiredService<IConsoleLogger>().WriteLine($"Usage: {Assembly.GetExecutingAssembly().GetName().Name}.exe <road id>");
                return RoadStatusApp.ExitCodes.BadInput;
            }

            var roadStatusApp = serviceProvider.GetRequiredService<RoadStatusApp>();
            var exitCode = await roadStatusApp.GetRoadStatusAsync(args[0]);
            return exitCode;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConsoleLogger, ConsoleLogger>();
            services.AddSingleton<RoadStatusApp>();
            services.AddSingleton<IRoadStatusService, RoadStatusService>();
            services.AddSingleton<IRoadStatusDomainService, RoadStatusDomainService>();
            services.AddSingleton<IRoadStatusRepository, RoadStatusRepository>();
            services.AddSingleton<RepositorySettings>();
        }
    }
}
