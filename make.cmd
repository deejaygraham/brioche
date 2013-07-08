@echo off

SET MsBuildPath="%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"

rem Is this a 64 bit machine?
IF EXIST "%Programfiles(x86)%" SET MsBuildPath="%windir%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"

IF "%1" == "" GOTO DefaultTarget
GOTO SpecificTarget

:DefaultTarget
%MsBuildPath% /nologo brioche.proj 
goto End

:SpecificTarget
%MsBuildPath% /nologo brioche.proj /t:%* 

:End
@echo on
