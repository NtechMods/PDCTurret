set SEInstallDir="D:\games\steamapps\common\SpaceEngineers"
for %%I in (.) do set ParentDirName=%%~nxI
%SEInstallDir%\Bin64\SEWorkshopTool.exe --upload --mods "%ParentDirName%" --exclude .bat .psd .fbx .hkt .xml
pause