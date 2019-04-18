
#Set-Location -Path $Currentlocation.path += 'Client'
$path = Get-Location;
$fullpath = join-path -path $path -childpath 'Client'
Set-Location -Path $fullpath
echo $fullpath

#cmd.exe --% /c ng build 

#$command = cmd.exe /C ng build
#Invoke-Expression $command

#cmd.exe /c "ng build"



$fullpath = join-path -path $path -childpath 'WebServer'
#Set-Location -Path $Currentlocation.path += 'WebServer'
Set-Location -Path $fullpath
echo $fullpath


Read-Host -Prompt “Press Enter to exit”