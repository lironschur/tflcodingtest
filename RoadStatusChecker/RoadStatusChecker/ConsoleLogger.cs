using System;

namespace RoadStatusChecker
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}