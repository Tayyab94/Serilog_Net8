using Serilog;
using Serilog.Formatting.Json;

namespace Serilog_Net8.Services
{
    public static class AppExtension
    {
        public static void SerilogConfiguration(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog(configureLogger: (context, loggerConfig) =>
            {

                //loggerConfig.WriteTo.Console();

                //// Write the log in file.
                ////loggerConfig.WriteTo.File("appLogs.txt");
                //  loggerConfig.WriteTo.File(new JsonFormatter(), "logs/applogs.txt", rollingInterval: RollingInterval.Day); ;
            

                // Alternate 
                loggerConfig.ReadFrom.Configuration(context.Configuration);
            });
        }
    }
}
