set SEInstallDir="D:\games\steamapps\common\SpaceEngineers"
for %%I in (.) do set ParentDirName=%%~nxI
%SEInstallDir%\Bin64\SEWorkshopTool.exe --mods "%ParentDirName%" --thumb "%~dp0\thumb.jpg"
pause