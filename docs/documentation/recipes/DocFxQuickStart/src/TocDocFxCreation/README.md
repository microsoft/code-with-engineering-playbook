# Table of Contents (TOC) generator for DocFX

This tool allow to generate a yaml compatible `toc.yml` file for DocFX.

## Usage

```text
TocGenerator -d <docs folder> [-o <output folder>] [-vsi]

-d, --docfolder       Required. Folder containing the documents.
-o, --outputfolder    Folder to write the resulting toc.yml in.
-v, --verbose         Show verbose messages.
-s, --sequence        Use the .order files for TOC sequence. Format are raws of: filename-without-extension
-r, --override        Use the .override files for TOC file name override. Format are raws of: filename-without-extension;Title you want
-i, --index           Auto-generate a file index in each folder.
--help                Display this help screen.
--version             Display version information.
```

If the `-o or --outputfolder` is not provided, the output folder is set to the docfolder.

If normal return code of the tool is 0, but on error it returns 1.

## Warnings, errors and verbose

If the tool encounters situations that might need some action, a warning is written to the output. The table of contents is still created.

If the tool encounters an error, an error message is written to the output. The table of contents will not be created. The tool will return errorcode 1.

If you want to trace what the tool is doing, use the `-v or verbose` flag to output all details of processing the files and folders and creating the table of contents.

## Ordering TOC entries

If the `-s or --sequence` parameter is provided, the tool will inspect every folder with content if a .order file exists and use that to determine the order of files and directories. The .order file is just a list of file- and/or directory-names, case-sensitive without file extensions. Also see the [Azure DevOps WIKI documentation on this file](https://docs.microsoft.com/en-us/azure/devops/project/wiki/wiki-file-structure?view=azure-devops#order-file).

A sample .order file could look like this:

```text
README
getting-started
working-agreements
developer
```

## Overriding names

If the `-r or --override` parameter is provided, the tool will inspect every folder with content if a .override file exists. It will use it to override the name displayed in the TOC for a specific file or directory.
For example, if the folder name is `introduction`, the default behavior will be to create the name `Introduction`. If you want to call it `To start with`, you can use overrides, like in the following example:

```text
introduction;To start with
working-agreements;All working agreements of all teams
```

Just use the folder name or Markdown file name without extension, a semicolon `;` as a separator and the wanted name to be used. For files, the default behavior without this override is to use the description in the main title of the file.

If there are files or directories which are not in the .order file, they will be alphabetically ordered on the title and added after the ordered entries. The title for an MD-file is taken from the H1-header in the file. The title for a directory is the directory-name, but cleanup from special characters and the first character in capitals.

## Automatic adding index of files and directories

If the `-i or --index` parameter is provided, for every folder that doesn't have a README.md or INDEX.md, an INDEX.md is generated with the contents of that folder. That file is also added to the top of the list of files and directories in that folder.

The generated INDEX.md contains of an H1-header with the name of the folder, followed by a list of files and directories using their title and a link to the item.
