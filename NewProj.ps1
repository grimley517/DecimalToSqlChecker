dotnet new classlib -o src/DecimalChecker -n DecimalChecker
dotnet new xunit -o src/DecimalChecker.Tests -n DecimalChecker.Tests

dotnet new sln -o src -n DecimalChecker

Write-host "Solutionfile Created"

$slnFile = Get-ChildItem -Path src/DecimalChecker.sln 
Write-Host $slnFile
$projFiles = Get-ChildItem -Path src/* -Filter *.csproj -Recurse
foreach ($file in $projFiles) {
    dotnet sln $slnFile add $file
}

#  remove-Item -Path src -Recurse -Force