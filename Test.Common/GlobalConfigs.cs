using Serilog;

namespace Test.Common
{
    public static class GlobalConfigs
    {
        public static ILogger CreateLogger(string logFilePath)
        {
            var outputTemplate = GlobalConstants.LogTemplate;

            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Logger(l => l
                    .WriteTo.File(outputTemplate: outputTemplate, path: logFilePath,
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 500)
                    .WriteTo.Console(outputTemplate: outputTemplate,
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information))
                .CreateLogger();
        }
    }
}
