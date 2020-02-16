$app1ProjectFolder = $PSScriptRoot + '\WebServer'
$app2ProjectFolder = './src/App2'


Write-Host "STARTING WebServer" -foreground Green

Push-Location $app1ProjectFolder

$dotnetRunCommandApp1 = 'watch run'
$app1Process = Start-Process dotnet -ArgumentList $dotnetRunCommandApp1 -PassThru

Pop-Location
Write-Host "Opening Browser" -forground Green
Start 'https://localhost:5001'

#Write-Host "STARTING APP2" -foreground Green

#Push-Location $app2ProjectFolder 

#$dotnetRunCommandApp2 = 'run'
#$app2Process = Start-Process dotnet -ArgumentList $dotnetRunCommandApp2 -PassThru

#Pop-Location

#Read-Host -Prompt “Press Enter to exit”