using Serilog;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace TachographSimulation
{
    public static class LoggerConfigurationService
    {
        public static ILogger logger() 
        {
            var log = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Logs.log"), rollingInterval: RollingInterval.Day)
              .CreateLogger();
            return log;
        }
    }
}
