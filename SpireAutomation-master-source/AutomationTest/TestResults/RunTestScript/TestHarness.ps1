#Get the current working directory
$currentDir = (Get-Item -Path ".\" -Verbose).FullName
#NUnit Dir
$NUnitDir = $currentDir + "\NUnit\nunit3-console.exe"
#Pickles Dir
$PickleDir = $currentDir + "\Pickles\pickles.exe"
#Test DLL Dir
$TestDLL = "path to dll"

Write-Host "Starting NUnit Test"
&$NUnitDir $TestDLL
Write-Host "Test Completed!!!"

Write-Host "Starting Pickles report generation"
#&PickleDir --feature-directory
