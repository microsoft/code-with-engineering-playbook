@echo off

set ORG=%1
set PACKAGE=%2
set ENV=%3
set LOCATION=%4

for /f "tokens=2 delims=," %%A in ('findstr /r "^%LOCATION%," "location-suffix-map.csv"') do set LOCATION_SUFFIX=%%A

set RESOURCE_GROUP_NAME=rg-trfrm-%ENV%-%LOCATION_SUFFIX%-%ORG%
set STORAGE_ACCOUNT_NAME=sttrfrm%ENV%%LOCATION_SUFFIX%%ORG%
set CONTAINER_NAME=%PACKAGE%

echo Ensuring backend storage account '%STORAGE_ACCOUNT_NAME%' configured for package '%2'

REM create resource group
call az group create --name %RESOURCE_GROUP_NAME% --location %LOCATION%

REM create storage account
call az storage account create --resource-group %RESOURCE_GROUP_NAME% --name %STORAGE_ACCOUNT_NAME% --sku Standard_LRS --encryption-services blob

REM get storage account key
call az storage account keys list --resource-group %RESOURCE_GROUP_NAME% --account-name %STORAGE_ACCOUNT_NAME% --query [0].value -o tsv >storageKey.txt
set /p ACCOUNT_KEY=<storageKey.txt
del storageKey.txt

REM create blob container for tf state files
call az storage container create --name %CONTAINER_NAME% --account-name %STORAGE_ACCOUNT_NAME% --account-key %ACCOUNT_KEY%

REM set azure devops pipeline vars for use in subsequent tasks
echo ##vso[task.setvariable variable=TfBackend.ResourceGroupName]%RESOURCE_GROUP_NAME%
echo ##vso[task.setvariable variable=TfBackend.StorageAccountName]%STORAGE_ACCOUNT_NAME%
echo ##vso[task.setvariable variable=TfBackend.ContainerName]%CONTAINER_NAME%