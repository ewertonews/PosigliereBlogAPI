using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posig.Blog.Logging
{
    /// <summary>
    /// Represents the options specified in the app settings for logging using Serilog.
    /// </summary>
    public class SerilogOptions
    {

        /// <summary>
        /// Used to enable/disable global logging.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Used to enable/disable logging into console
        /// </summary>
        public bool ConsoleLogging { get; set; }

        /// <summary>
        /// Property containing the configuration for file logging.
        /// </summary>
        public FileLoggingOptions FileLogging { get; set; } = new FileLoggingOptions();

        /// <summary>
        /// Property containing the configuration for Seq logging.
        /// </summary>
        public SeqLoggingOptions SeqLogging { get; set; } = new SeqLoggingOptions();

        
        /// <summary>
        /// The app settings section name where the logging options are specified.
        /// </summary>
        public static string SectionName => $"Logging:{nameof(SerilogOptions)}";
    }
}
