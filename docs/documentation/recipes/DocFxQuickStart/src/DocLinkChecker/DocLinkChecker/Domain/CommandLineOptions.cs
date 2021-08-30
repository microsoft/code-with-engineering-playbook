// Licensed to ZF and contributors under one or more agreements.
// ZF and contributors licenses this file to you under the MIT license.

namespace DocLinkChecker.Domain
{
    using CommandLine;

    /// <summary>
    /// Class for command line options.
    /// </summary>
    public class CommandlineOptions
    {
        /// <summary>
        /// Gets or sets the folder with documents.
        /// </summary>
        /// <value>Root of the documentation.</value>
        [Option('d', "docfolder", Required = true, HelpText = "Folder containing the documents.")]
        public string DocFolder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether verbose information is shown in the output.
        /// </summary>
        /// <value>If true, verbose messages will be shown in the output.</value>
        [Option('v', "verbose", Required = false, HelpText = "Show verbose messages.")]
        public bool Verbose { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we need to check .attachments folder for unreferenced files.
        /// </summary>
        /// <value>If true, the .attachments folder will be validated for unreferenced files.</value>
        [Option('a', "attachments", Required = false, HelpText = "Check unreferenced files in .attachments.")]
        public bool Attachments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to cleanup unreferenced files in .attachments.
        /// </summary>
        /// <value>If true, unreferenced files in .attachments will be removed from the folder.</value>
        [Option('c', "cleanup", Required = false, HelpText = "Cleanup unreferenced files in .attachments.")]
        public bool Cleanup { get; set; }
    }
}
