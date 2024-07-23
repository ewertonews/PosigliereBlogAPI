namespace Posig.Blog.Logging
{
    public class SeqLoggingOptions
    {
        /// <summary>
        /// Used to disable/enable logging using Seq.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The Seq server address
        /// </summary>
        public string Server { get; set; } = string.Empty;

        /// <summary>
        /// The Seq api key (for online usage). Not necessary for local usage.
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;
    }
}