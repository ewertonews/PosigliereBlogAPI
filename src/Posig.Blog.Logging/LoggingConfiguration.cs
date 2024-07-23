using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.File.Archive;
using System.IO.Compression;

namespace Posig.Blog.Logging
{
    /// <summary>
    /// Represents the Logging Configuration options specified in the app settings.
    /// </summary>
    public static class LoggingConfiguration
    {
        /// <summary>
        /// Extension method for configuring logging in the application builder
        /// </summary>
        /// <param name="builder">the WebApplicationBuilder</param>
        public static void AddLogging(this WebApplicationBuilder builder)
        {
            SerilogOptions serilogOptions = new();

            builder.Host.UseSerilog((ctx, logConfiguration) =>
            {
                ctx.Configuration.Bind(SerilogOptions.SectionName, serilogOptions);

                if (!serilogOptions.Enabled)
                {
                    return;
                }

                var outputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {NewLine}{Exception}";

                logConfiguration
                    .ReadFrom.Configuration(ctx.Configuration)
                    .Enrich.FromLogContext();


                if (serilogOptions.ConsoleLogging)
                {
                    logConfiguration.WriteTo.Console(outputTemplate: outputTemplate);
                }

                if (serilogOptions.FileLogging.Enabled)
                {
                    var compressionLevel = serilogOptions.FileLogging.CompressArchive
                        ? CompressionLevel.Fastest
                        : CompressionLevel.NoCompression;

                    var archiveConfig = new ArchiveHooks(compressionLevel, serilogOptions.FileLogging.ArchivePath);
                    logConfiguration.WriteTo.File(
                        path: serilogOptions.FileLogging.LogsPath,
                        outputTemplate: outputTemplate,
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: (10 * 1024 * 1024),
                        retainedFileCountLimit: serilogOptions.FileLogging.RetainedFileCountLimit,
                        hooks: archiveConfig);
                }


                if (serilogOptions.SeqLogging.Enabled)
                {
                    logConfiguration.WriteTo
                        .Seq(serilogOptions.SeqLogging.Server, apiKey: serilogOptions.SeqLogging.ApiKey);
                }               
            });

        }
    }
}
