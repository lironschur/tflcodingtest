using System;
using System.Threading.Tasks;
using RoadStatusChecker.Service;

namespace RoadStatusChecker
{
    public class RoadStatusCheckerApp
    {
        public const string RoadIdPattern = "[a-zA-Z0-9]+";

        public static class ExitCodes
        {
            public static int Success => 0;
            public static int NotFound => 1;
            public static int BadInput => 2;
            public static int Failure => 3;
        }

        private readonly IRoadStatusCheckerService _roadStatusCheckerService;
        private readonly IConsoleLogger _logger;

        public RoadStatusCheckerApp(IRoadStatusCheckerService roadStatusCheckerService, IConsoleLogger logger)
        {
            _roadStatusCheckerService = roadStatusCheckerService;
            _logger = logger;
        }

        public async Task<int> GetRoadStatusAsync(string id)
        {
            try
            {
                var results = await _roadStatusCheckerService.GetRoadCorridorsAsync(id);
                foreach (var result in results)
                {
                    _logger.WriteLine($"The status of the {result.DisplayName} is as follows");
                    _logger.WriteLine($"\tRoad Status is {result.StatusSeverity}");
                    _logger.WriteLine($"\tRoad Status Description is {result.StatusSeverityDescription}");
                }

                return ExitCodes.Success;
            }
            catch (RoadNotFoundException)
            {
                _logger.WriteLine($"{id} is not a valid road");
                return ExitCodes.NotFound;
            }
            catch (Exception ex)
            {
                _logger.WriteLine($"Failure encountered: {ex.Message}");
                return ExitCodes.Failure;
            }
        }
    }
}
