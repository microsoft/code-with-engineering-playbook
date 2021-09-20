// Licensed to DocFX Companion Tools and contributors under one or more agreements.
// DocFX Companion Tools and contributors licenses this file to you under the MIT license.

namespace DocFxTocGenerate
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using CommandLine;
    using TocDocFxCreation.Domain;
    using TocDocFxCreation.Helpers;

    /// <summary>
    /// Toc generator.
    /// </summary>
    internal class TocGenerator
    {
        private static CommandlineOptions options;
        private static int returnvalue;
        private static MessageHelper message;

        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args">Commandline options described in <see cref="CommandlineOptions"/> class.</param>
        /// <returns>0 if succesful, 1 on error.</returns>
        private static int Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandlineOptions>(args)
                               .WithParsed<CommandlineOptions>(RunLogic)
                               .WithNotParsed(HandleErrors);

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

            if (string.IsNullOrEmpty(options.OutputFolder))
            {
                options.OutputFolder = options.DocFolder;
            }

            message.Verbose($"Documentation folder: {options.DocFolder}");
            message.Verbose($"Output folder       : {options.OutputFolder}");
            message.Verbose($"Verbose             : {options.Verbose}");
            message.Verbose($"Use .order          : {options.UseOrder}");
            message.Verbose($"Use .override       : {options.UseOverride}");
            message.Verbose($"Auto index          : {options.AutoIndex}\n");

            if (!Directory.Exists(options.DocFolder))
            {
                message.Error($"ERROR: Documentation folder '{options.DocFolder}' doesn't exist.");
                returnvalue = 1;
                return;
            }

            if (!Directory.Exists(options.OutputFolder))
            {
                message.Error($"ERROR: Destination folder '{options.OutputFolder}' doesn't exist.");
                returnvalue = 1;
                return;
            }

            // we start at the root to generate the TOC items
            TocItem tocRootItems = new TocItem();
            DirectoryInfo rootDir = new DirectoryInfo(options.DocFolder);
            WalkDirectoryTree(rootDir, tocRootItems);

            // we have the TOC, so serialize to a string
            using (StringWriter sw = new StringWriter())
            {
                using (IndentedTextWriter writer = new IndentedTextWriter(sw, "  "))
                {
                    writer.WriteLine("# This is an automatically generated file");
                    Serialize(writer, tocRootItems, true);
                }

                // now write the TOC to disc
                File.WriteAllText(Path.Combine(options.OutputFolder, "toc.yml"), sw.ToString());
            }

            message.Verbose($"{Path.Combine(options.OutputFolder, "toc.yml")} created.");
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
        /// <param name="yamlNode">An item.</param>
        /// <returns>Full path of the entry-file of this folder.</returns>
        private static string WalkDirectoryTree(DirectoryInfo folder, TocItem yamlNode)
        {
            message.Verbose($"Processing folder {folder.FullName}");

            List<string> order = GetOrderList(folder);
            Dictionary<string, string> overrides = options.UseOverride ? GetOverrides(folder) : new Dictionary<string, string>();

            // add doc files to the node
            GetFiles(folder, order, yamlNode, overrides);

            // add directories with content to the node
            GetDirectories(folder, order, yamlNode, overrides);

            if (yamlNode.Items != null)
            {
                // now sort the files and directories with the order-list and further alphabetically
                yamlNode.Items = new Collection<TocItem>(yamlNode.Items.OrderBy(x => x.Sequence).ThenBy(x => x.SortableTitle).ToList());
                message.Verbose($"Items ordered in {folder.FullName}");
            }

            if (!string.IsNullOrWhiteSpace(yamlNode.Filename))
            {
                // if indicated, add a folder index - but not for the root folder.
                if (options.AutoIndex)
                {
                    string indexFile = AddIndex(folder, yamlNode, GetOverrides(folder.Parent));
                    if (!string.IsNullOrEmpty(indexFile))
                    {
                        yamlNode.Href = GetRelativePath(indexFile, options.DocFolder);
                    }
                }
                else
                {
                    if (yamlNode.Items != null && yamlNode.Items.Any())
                    {
                        yamlNode.Href = GetRelativePath(yamlNode.Items.First().Filename, options.DocFolder);
                    }
                }
            }

            return yamlNode.Items == null ? string.Empty : yamlNode.Items.First().Filename;
        }

        /// <summary>
        /// Get the list of the files in the current directory.
        /// </summary>
        /// <param name="folder">The folder to search.</param>
        /// <param name="order">Order list.</param>
        /// <param name="yamlNode">The current toc node.</param>
        /// <param name="overrides">The overrides.</param>
        private static void GetFiles(DirectoryInfo folder, List<string> order, TocItem yamlNode, Dictionary<string, string> overrides)
        {
            message.Verbose($"Process {folder.FullName} for files.");

            List<FileInfo> files = folder
                .GetFiles("*.md")
                .OrderBy(f => f.Name)
                .ToList();

            if (files == null)
            {
                message.Verbose($"No MD files found in {folder.FullName}.");
                return;
            }

            foreach (FileInfo fi in files)
            {
                if (fi.Name.StartsWith(".", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // see if the file is mentioned in the order-list for ordering.
                int sequence = int.MaxValue;
                if (order.Contains(Path.GetFileNameWithoutExtension(fi.Name)))
                {
                    sequence = order.IndexOf(Path.GetFileNameWithoutExtension(fi.Name));
                }

                string title = string.Empty;
                if (options.UseOverride && (overrides.Count > 0))
                {
                    // get possible title override from the .override file
                    var key = fi.Name.Substring(0, fi.Name.Length - 3);
                    if (overrides.ContainsKey(key))
                    {
                        title = overrides[key];
                    }
                }

                title = title.Length == 0 ? GetCleanedFileName(fi) : title;

                yamlNode.AddItem(new TocItem
                {
                    Sequence = sequence,
                    Filename = fi.FullName,
                    Title = title,
                    Href = GetRelativePath(fi.FullName, options.DocFolder),
                });

                message.Verbose($"Add file seq={sequence} title={title} href={GetRelativePath(fi.FullName, options.DocFolder)}");
            }
        }

        /// <summary>
        /// Get the override file for given folder and process.
        /// </summary>
        /// <param name="folder">Current folder.</param>
        /// <returns>Dictionary containing overrides.</returns>
        private static Dictionary<string, string> GetOverrides(DirectoryInfo folder)
        {
            Dictionary<string, string> overrides = new Dictionary<string, string>();

            // Read the .override file
            string overrideFile = Path.Combine(folder.FullName, ".override");
            if (File.Exists(overrideFile))
            {
                message.Verbose($"Read existing overrideFile file {overrideFile}");
                foreach (var over in File.ReadAllLines(overrideFile))
                {
                    var overSplit = over.Split(';');
                    if (overSplit?.Length == 2)
                    {
                        overrides.TryAdd(overSplit[0], overSplit[1]);
                    }
                }
            }

            message.Verbose($"Found {overrides.Count} for folder {folder.FullName}");
            return overrides;
        }

        /// <summary>
        /// Walk through sub-folders and add if they contain content.
        /// </summary>
        /// <param name="folder">Folder to get sub-folders from.</param>
        /// <param name="order">Order list.</param>
        /// <param name="yamlNode">yamlNode to add entries to.</param>
        /// <param name="overrides">The overrides.</param>
        private static void GetDirectories(DirectoryInfo folder, List<string> order, TocItem yamlNode, Dictionary<string, string> overrides)
        {
            message.Verbose($"Process {folder.FullName} for sub-directories.");

            // Now find all the subdirectories under this directory.
            DirectoryInfo[] subDirs = folder.GetDirectories();
            foreach (DirectoryInfo dirInfo in subDirs)
            {
                // skip hidden folders (starting with .)
                if (dirInfo.Name.StartsWith(".", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Get all the md files only
                FileInfo[] subFiles = dirInfo.GetFiles("*.md");
                if (subFiles.Any() == false)
                {
                    message.Warning($"WARNING: Folder {dirInfo.FullName} skipped as it doesn't contain MD files. This might skip further sub-folders. Solve this by adding a README.md or INDEX.md in the folder.");
                    continue;
                }

                TocItem newTocItem = new TocItem();

                // if the directory is in the .order file, take the index as sequence nr
                if (order.Contains(Path.GetFileName(dirInfo.Name)))
                {
                    newTocItem.Sequence = order.IndexOf(Path.GetFileName(dirInfo.Name));
                }

                string title = string.Empty;
                if (options.UseOverride)
                {
                    // if in the .override file, override the title with it
                    if (overrides.ContainsKey(dirInfo.Name))
                    {
                        title = overrides[dirInfo.Name];
                    }
                }

                // Cleanup the title to be readable
                title = title.Length == 0 ? ToTitleCase(dirInfo.Name) : title;
                newTocItem.Filename = dirInfo.FullName;
                newTocItem.Title = title;
                string entryFile = WalkDirectoryTree(dirInfo, newTocItem);
                if (subFiles.Length == 1 && dirInfo.GetDirectories().Length == 0)
                {
                    newTocItem.Href = GetRelativePath(subFiles[0].FullName, options.DocFolder);
                }
                else
                {
                    newTocItem.Href = GetRelativePath(entryFile, options.DocFolder);
                }

                message.Verbose($"Add directory seq={newTocItem.Sequence} title={newTocItem.Title} href={newTocItem.Href}");

                yamlNode.AddItem(newTocItem);
            }
        }

        /// <summary>
        /// Get an order-list for ordering items in the given folder.
        /// We'll try to read the '.order' file. If that one exists, it's read.
        /// We'll always add readme to the order-list if they weren't added yet.
        /// This make sure that even when the .order is not set, the readme gets a prominent position.
        /// </summary>
        /// <param name="folder">Folder to check for .order file.</param>
        /// <returns>Ordered list.</returns>
        private static List<string> GetOrderList(DirectoryInfo folder)
        {
            // see if we have an .order file
            List<string> order = new List<string>();
            if (options.UseOrder)
            {
                string orderFile = Path.Combine(folder.FullName, ".order");
                if (File.Exists(orderFile))
                {
                    message.Verbose($"Read existing order file {orderFile}");
                    order = File.ReadAllLines(orderFile).ToList();
                }
            }

            // we always want to order README.md. So add it if not in list yet
            string readmeEntry = order.FirstOrDefault(x => string.Equals("README", x, StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(readmeEntry))
            {
                order.Add("README");
                message.Verbose($"'README' added to order-list");
            }

            // we always want to order INDEX.md as well. So add it if not in list yet
            string indexEntry = order.FirstOrDefault(x => string.Equals("index", x, StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(indexEntry))
            {
                order.Add("index");
                message.Verbose($"'index' added to order-list");
            }

            return order;
        }

        /// <summary>
        /// See if there is a 1) README.md or 2) index.md.
        /// If those don't exist, we add a standard index.md.
        /// </summary>
        /// <param name="folder">Folder to work with.</param>
        /// <param name="yamlNode">Toc item for the folder.</param>
        /// <param name="overrides">The overrides.</param>
        /// <returns>Name of the file where the index was added.</returns>
        private static string AddIndex(DirectoryInfo folder, TocItem yamlNode, Dictionary<string, string> overrides)
        {
            // don't add index if there is nothing to index
            if (yamlNode.Items == null || !yamlNode.Items.Any())
            {
                return string.Empty;
            }

            // determine output file. Standard is index.md.
            string readmeFile = Path.Combine(folder.FullName, "README.md");
            string indexFile = Path.Combine(folder.FullName, "index.md");

            // if one of these files exists, we don't add an index.
            if (File.Exists(readmeFile) || File.Exists(indexFile))
            {
                return string.Empty;
            }

            if (WriteIndex(indexFile, yamlNode))
            {
                // if a new index has been created, add that to the TOC (top of list)
                FileInfo fi = folder.GetFiles().FirstOrDefault(x => string.Equals(x.Name, Path.GetFileName(indexFile), StringComparison.OrdinalIgnoreCase));
                string title = string.Empty;
                if (options.UseOverride && (overrides.Count > 0))
                {
                    string key = folder.Name;
                    if (overrides.ContainsKey(key))
                    {
                        title = overrides[key];
                    }
                }

                TocItem newItem = new TocItem
                {
                    Sequence = -1,
                    Filename = indexFile,
                    Title = title.Length == 0 ? GetCleanedFileName(fi) : title,
                    Href = GetRelativePath(indexFile, options.DocFolder),
                };

                // insert index item at the top
                yamlNode.AddItem(newItem, true);
                message.Verbose($"Added index.md to top of list of files.");
            }

            return indexFile;
        }

        /// <summary>
        /// Write the index in the given outputFile.
        /// </summary>
        /// <param name="outputFile">File to write to.</param>
        /// <param name="yamlNode">TOC Item to get files from.</param>
        /// <returns>Was a NEW index file created TRUE/FALSE.</returns>
        private static bool WriteIndex(string outputFile, TocItem yamlNode)
        {
            if (File.Exists(outputFile))
            {
                return false;
            }

            message.Verbose($"Index will be written to {outputFile}");

            // read lines if existing file.
            List<string> lines = new List<string>();

            lines.Add($"# {yamlNode.Title}");
            lines.Add(string.Empty);
            foreach (TocItem item in yamlNode.Items)
            {
                lines.Add($"* [{item.Title}](./{Path.GetFileName(item.Filename)})");
            }

            File.WriteAllLines(outputFile, lines);
            message.Verbose($"Written {lines.Count} lines to {outputFile} (index).");
            return true;
        }

        /// <summary>
        /// Serialize a toc item.
        /// </summary>
        /// <param name="writer">Writer to use for output.</param>
        /// <param name="tocItem">the toc item to serialize.</param>
        /// <param name="isRoot">Is this the root, then we don't indent extra.</param>
        /// <remarks>The representation is like this:
        /// items:
        /// - name: Document One
        ///   href: document-one.md
        /// - name: Document Two
        ///   href: document-two.md
        /// - name: Sub Folder
        ///   href: sub-folder/index.md
        ///   items:
        ///   - name: Index
        ///     href: sub-folder/index.md
        ///   - name: Sub Document One
        ///     href: sub-folder/sub-document-one.md.
        /// </remarks>
        private static void Serialize(IndentedTextWriter writer, TocItem tocItem, bool isRoot = false)
        {
            if (!string.IsNullOrEmpty(tocItem.Title))
            {
                writer.WriteLine($"- name: {tocItem.Title}");
            }

            if (!string.IsNullOrEmpty(tocItem.Href))
            {
                writer.WriteLine($"  href: {tocItem.Href}");
            }

            if (tocItem.Items != null)
            {
                if (!isRoot)
                {
                    writer.Indent++;
                }

                writer.WriteLine("items:");
                foreach (TocItem toc in tocItem.Items)
                {
                    Serialize(writer, toc);
                }

                if (!isRoot)
                {
                    writer.Indent--;
                }
            }
        }

        /// <summary>
        /// Clean the file names.
        /// </summary>
        /// <param name="fi">A file name.</param>
        /// <returns>A cleaned string replacing - and _ and removing md extension as well as non authorized characters.</returns>
        private static string GetCleanedFileName(FileInfo fi)
        {
            string cleanedName = fi.Name;

            // Open the file, read the line up to the first #, extract the tile
            using (StreamReader toRead = File.OpenText(fi.FullName))
            {
                while (!toRead.EndOfStream)
                {
                    string strTitle = toRead.ReadLine();
                    if (strTitle.TrimStart(' ').StartsWith("# ", StringComparison.OrdinalIgnoreCase))
                    {
                        cleanedName = strTitle.Substring(2);
                        break;
                    }
                }
            }

            return ToTitleCase(cleanedName);
        }

        /// <summary>
        /// Uppercase first character and remove unwanted characters.
        /// </summary>
        /// <param name="title">The name to clean.</param>
        /// <returns>A clean name.</returns>
        private static string ToTitleCase(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return string.Empty;
            }

            string cleantitle = title.First().ToString().ToUpperInvariant() + title.Substring(1);
            cleantitle = Regex.Replace(cleantitle, @"[-_+]", " ");
            return Regex.Replace(cleantitle, @"([\[\]\:`\\{}()#\*]|\.md)", string.Empty);
        }

        /// <summary>
        /// Get the relative path.
        /// </summary>
        /// <param name="filePath">The file to get the relative path.</param>
        /// <param name="sourcePath">The source path, by default the current directory.</param>
        private static string GetRelativePath(string filePath, string sourcePath = null)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return string.Empty;
            }

            string currentDir = sourcePath ?? Environment.CurrentDirectory;
            return Path.GetRelativePath(Path.GetFullPath(currentDir), filePath)
                .Replace("\\", "/", StringComparison.OrdinalIgnoreCase);
        }
    }
}
