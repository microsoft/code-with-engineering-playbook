@echo off

rem **** Build the tools
echo Building the tools
dotnet build src\TocDocFxCreation
if errorlevel == 1 goto error
dotnet build src\DocLinkChecker
if errorlevel == 1 goto error

rem **** Check for markdown erros
echo Checking markdown syntax
call markdownlint **/*.md
if errorlevel == 1 goto error

rem **** Check the docs folder. On errors, quit processing
echo Checking references and attachments
src\DocLinkChecker\DocLinkChecker\bin\Debug\netcoreapp3.1\DocLinkChecker.exe -d .\docs -a
if errorlevel == 1 goto error

rem **** Generate the table of contents of the docs folder. On errors, quit processing
echo Generating table of contents
src\TocDocFxCreation\bin\Debug\net5.0\TocDocFxCreation.exe -d .\docs -sri
if errorlevel == 1 goto error

rem **** Clean up old generated files
echo Clean up previous generated contents
if exist _site rd _site /s /q
if exist obj rd obj /s /q
if exist reference rd reference /s /q

rem **** Generated the website
echo Generating website in _site
docfx %1

goto end

:error
echo *** ERROR *** 
echo An error occurred. Website was not generated.

:end