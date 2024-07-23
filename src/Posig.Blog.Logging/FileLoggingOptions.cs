namespace Posig.Blog.Logging
{
    public class FileLoggingOptions
    {
        /// <summary>
        /// Used to disable/enable the logging into a file
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The path of the log file
        /// </summary>
        public string LogsPath { get; set; } = "logs/log_.txt";

        /// <summary>
        /// Determines if the log files will be compressed before archiving. The type of compression used is "Fatest". See <see cref="LoggingConfiguration" />, line 44.
        /// </summary>
        public bool CompressArchive { get; set; } = true;

        /// <summary>
        /// The path where the log files will be moved to.
        /// </summary>
        public string ArchivePath { get; set; } = string.Empty;

        /// <summary>
        /// The max number of files that remain in the LogsPath. The exceeding files will be moved to the ArchivePath.
        /// </summary>
        public int RetainedFileCountLimit { get; set; }
    }
}