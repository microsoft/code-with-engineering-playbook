// Licensed to ZF and contributors under one or more agreements.
// ZF and contributors licenses this file to you under the MIT license.

namespace DocLinkChecker
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using CommandLine;
    using DocLinkChecker.Domain;
    using DocLinkChecker.Helpers;

    /// <summary>
    /// Main program class for documentation link checker tool. It's a command-line tool
    /// that takes parameters. Use -help as parameter to see the syntax.
    /// </summary>
    public class Program
    {
        private static CommandlineOptions options;
        private static int returnvalue;
        private static MessageHelper message;

        private static List<string> allFiles = new List<string>();
        private static List<string> allLinks = new List<string>();

        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args">Commandline options described in <see cref="CommandlineOptions"/> class.</param>
        /// <returns>0 if succesful, 1 on error.</returns>
        private static int Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<CommandlineOptions>(args)
                                   .WithParsed<CommandlineOptions>(RunLogic)
                                   .WithNotParsed(HandleErrors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: Parsing arguments threw an exception with message `{ex.Message}`");
                returnvalue = 1;
            }

            Console.WriteLine($"Exit with return code {returnvalue}");

            return returnvalue;
        }

        /// <summary>
        /// Run the logic of the app with the given parameters.
        /// Given folders are checked if they exist.
        /// </summary>
        /// <param name="o">Parsed commandline options.</param>
        private static void RunLogic(CommandlineOptions o)
        {
            options = o;
            message = new MessageHelper(options);

            // correction needed if relative path is given as parameter
            o.DocFolder = Path.GetFullPath(o.DocFolder);

            message.Verbose($"Documentation folder: {options.DocFolder}");
            message.Verbose($"Verbose             : {options.Verbose}");

            foreach (string file in Directory.EnumerateFiles(options.DocFolder, "*.*", SearchOption.AllDirectories))
            {
                allFiles.Add(file.ToLowerInvariant());
            }

            if (!Directory.Exists(options.DocFolder))
            {
                message.Error($"ERROR: Documentation folder '{options.DocFolder}' doesn't exist.");
                returnvalue = 1;
                return;
            }

            // we start at the root to generate the TOC items
            DirectoryInfo rootDir = new DirectoryInfo(options.DocFolder);
            WalkDirectoryTree(rootDir);

            if (options.Attachments)
            {
                CheckUnreferencedAttachments();
            }
        }

        /// <summary>
        /// On parameter errors, we set the returnvalue to 1 to indicated an error.
        /// </summary>
        /// <param name="errors">List or errors (ignored).</param>
        private static void HandleErrors(IEnumerable<Error> errors)
        {
            returnvalue = 1;
        }

        /// <summary>
        /// Main function going through all the folders, files and subfolders.
        /// </summary>
        /// <param name="folder">The folder to search.</param>
        private static void WalkDirectoryTree(DirectoryInfo folder)
        {
            message.Verbose($"Processing folder {folder.FullName}");

            // process MD files in this folder
            ProcessFiles(folder);

            // process other sub folders
            DirectoryInfo[] subDirs = folder.GetDirectories();
            foreach (DirectoryInfo dirInfo in subDirs)
            {
                WalkDirectoryTree(dirInfo);
            }
        }

        /// <summary>
        /// Check the .attachments folder for files that are not referenced by any of the docs.
        /// If the cleanup option is given as well, we'll remove those files from disc.
        /// </summary>
        private static void CheckUnreferencedAttachments()
        {
            string attachmentsPath = Path.Combine(options.DocFolder, ".attachments");
            bool errorHeader = false;

            if (allLinks.Any() && Directory.Exists(attachmentsPath))
            {
                List<string> attachments = Directory.GetFiles(attachmentsPath).ToList();
                foreach (string attachment in attachments)
                {
                    if (!allLinks.Contains(attachment.ToLowerInvariant()))
                    {
                        if (options.Cleanup)
                        {
                            File.Delete(attachment);
                            message.Warning($"{attachment} deleted.");
                        }
                        else
                        {
                            if (!errorHeader)
                            {
                                message.Output($"\nFiles not referenced:\n");
                                errorHeader = true;
                            }

                            message.Error($"{attachment}");

                            // mark error in returnvalue of the tool
                            returnvalue = 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the list of the files in the current directory.
        /// </summary>
        /// <param name="folder">The folder to search.</param>
        private static void ProcessFiles(DirectoryInfo folder)
        {
            message.Verbose($"Process {folder.FullName} for files.");

            List<FileInfo> files = folder.GetFiles("*.md").OrderBy(f => f.Name).ToList();
            if (files == null)
            {
                message.Verbose($"No MD files found in {folder.FullName}.");
                return;
            }

            foreach (FileInfo fi in files)
            {
                message.Verbose($"Processing {fi.FullName}");
                string content = File.ReadAllText(fi.FullName);

                // first see if there are links in this file
                Regex rxContent = new Regex(@"(\[{1}.*\]{1}\({1}.*\){1}?)");
                if (rxContent.Matches(content).Any())
                {
                    message.Verbose($"- Links detected.");

                    // it has references, so check in detail
                    ProcessFile(folder, fi.FullName);
                }

                message.Verbose($"{fi.FullName} processed.");
            }
        }

        /// <summary>
        /// Process given file in give folder. Check all references.
        /// </summary>
        /// <param name="folder">Folder where file live.</param>
        /// <param name="filepath">Complete path of the file to check.</param>
        private static void ProcessFile(DirectoryInfo folder, string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);

            // get matches per line to be able to reference a line in a file.
            int linenr = 1;
            foreach (string line in lines)
            {
                Regex rxLine = new Regex(@"(\[[^\]]+\]{1}\({1}[^\)]+\){1})");
                MatchCollection matches = rxLine.Matches(line);
                if (matches.Any())
                {
                    // process all matches
                    foreach (Match match in matches)
                    {
                        // get just the reference
                        int start = match.Value.IndexOf("](") + 2;
                        string relative = match.Value.Substring(start);
                        int end = relative.IndexOf(")");
                        relative = relative.Substring(0, end);

                        // relative string contain not only URL, but also "title", get rid of it
                        int positionOfLinkTitle = relative.IndexOf('\"');
                        if (positionOfLinkTitle > 0)
                        {
                            relative = relative.Substring(0, relative.IndexOf('\"')).Trim();
                        }

                        // strip in-doc references using a #
                        if (relative.Contains("#"))
                        {
                            relative = relative.Substring(0, relative.IndexOf("#"));
                        }

                        // decode possible HTML encoding
                        relative = HttpUtility.UrlDecode(relative);

                        // check link if not to a URL, in-doc link or e-mail address
                        if (!relative.StartsWith("http:") &&
                            !relative.StartsWith("https:") &&
                            !relative.StartsWith("#") &&
                            !relative.Contains("@") &&
                            !string.IsNullOrEmpty(Path.GetExtension(relative)) &&
                            !string.IsNullOrWhiteSpace(relative))
                        {
                            // check validity of the link
                            string absolute = Path.GetFullPath(relative, folder.FullName);

                            // check that paths are relative
                            if (Path.IsPathFullyQualified(relative))
                            {
                                // link is full path - not allowed
                                message.Output($"{filepath} {linenr}:{match.Index}");
                                message.Error($"Full path '{relative}' used. Use relative path.");
                                returnvalue = 1;
                            }

                            // don't need to check if reference is to a directory
                            if (!Directory.Exists(absolute))
                            {
                                // check if we have file in allFiles list or if it exists on disc
                                if (!allFiles.Contains(absolute.ToLowerInvariant()) && !File.Exists(absolute))
                                {
                                    // ERROR: link to non existing file
                                    message.Output($"{filepath} {linenr}:{match.Index}");
                                    message.Error($"Not found: {relative}");

                                    // mark error in returnvalue of the tool
                                    returnvalue = 1;
                                }
                                else
                                {
                                    if (!allLinks.Contains(absolute.ToLowerInvariant()))
                                    {
                                        // register reference unique in list
                                        allLinks.Add(absolute.ToLowerInvariant());
                                    }
                                }
                            }
                        }
                    }
                }

                linenr++;
            }
        }
    }
}
