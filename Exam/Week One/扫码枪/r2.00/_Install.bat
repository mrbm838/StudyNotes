@echo off
@rem **********************************************************************************
@rem 
@rem YJ USB Serial Driver Installation Batch File
@rem 
@rem Version:
@rem 	1.2
@rem
@rem Usage:
@rem 	_install.bat [/Arg] [YJUSD_DRIVERPATH]
@rem 
@rem Arg:
@rem	/i to install control, enum and cdc drivers 
@rem	/p to preinstall control, enum and cdc and rescan USB
@rem 	/u to uninstall control enum and cdc drivers
@rem	/si to install control, enum and cdc drivers, silent mode
@rem	/sp to preinstall control, enum and cdc and rescan USB, silent mode
@rem 	/su to uninstall control enum and cdc drivers, silent mode
@rem
@rem Examples:
@rem    _install /i .\x86   	'install control 
@rem    _install /p .\x86	'install control and pre-install enum and cdc 
@rem    _install /u 		'uninstall all 
@rem
@rem Defaults (override defaults by seting the following environmental vars or using command line args):
@rem    YJUSD_ACTION- 'install' to install (control only), 'preinstall' to install control and pre-install enum and cdc, 
@rem 			'uninstall' to uninstall
@rem    YJUSD_DRIVERPATH - Path to the driver
@rem 	YJUSD_WDREGEXE - Name of wdreg util, wreg.exe or wdreg_gui.exe 
@rem 	YJUSD_SILENT - Set to 'silent' to specify silent install
@rem
@rem **********************************************************************************


@rem **********************************************************************************
@rem If environmental vars are not set, set them to defaults
@rem **********************************************************************************
set YJUSD_VER=2.00
if ""%YJUSD_WDREGEXE%""=="""" set YJUSD_WDREGEXE=wdreg.exe
if ""%YJUSD_DRIVERPATH%""=="""" set YJUSD_DRIVERPATH=.\x86
if ""%YJUSD_ACTION%""=="""" set YJUSD_ACTION=preinstall
if ""%YJUSD_SILENT%""=="""" set YJUSD_SILENT=
if ""%YJUSD_CAPTURESETUPAPILOG%""=="""" set YJUSD_CAPTURESETUPAPILOG=1
if ""%YJUSD_RESCAN%""=="""" set YJUSD_RESCAN=1

@rem **********************************************************************************
@rem Process command line args
@rem **********************************************************************************

@rem Check command line args
if ""%1""=="""" goto COMMANDLINEOK
if ""%1""==""/i"" goto COMMANDLINEOK
if ""%1""==""/u"" goto COMMANDLINEOK
if ""%1""==""/p"" goto COMMANDLINEOK
if ""%1""==""/si"" goto COMMANDLINEOK
if ""%1""==""/su"" goto COMMANDLINEOK
if ""%1""==""/sp"" goto COMMANDLINEOK
@echo Command line (%1) incorrect, validate the options are correct and re-run the install.
goto END
:COMMANDLINEOK

@rem Make sure to reset environmental vars when command line changes incase user runs command multible time from the same 
@rem command prompt

if ""%1""=="""" goto DONESETARGS
if ""%1""==""/i"" set YJUSD_ACTION=install
if ""%1""==""/u"" set YJUSD_ACTION=uninstall
if ""%1""==""/p"" set YJUSD_ACTION=preinstall
if ""%1""==""/i"" set YJUSD_RESCAN=0
if ""%1""==""/u"" set YJUSD_RESCAN=0
if ""%1""==""/p"" set YJUSD_RESCAN=1
if ""%1""==""/i"" set YJUSD_SILENT=
if ""%1""==""/u"" set YJUSD_SILENT=
if ""%1""==""/p"" set YJUSD_SILENT=
if ""%1""==""/i"" set YJUSD_WDREGEXE=wdreg.exe
if ""%1""==""/u"" set YJUSD_WDREGEXE=wdreg.exe
if ""%1""==""/p"" set YJUSD_WDREGEXE=wdreg.exe
if ""%1""==""/si"" set YJUSD_ACTION=install
if ""%1""==""/su"" set YJUSD_ACTION=uninstall
if ""%1""==""/sp"" set YJUSD_ACTION=preinstall
if ""%1""==""/si"" set YJUSD_RESCAN=0
if ""%1""==""/su"" set YJUSD_RESCAN=0
if ""%1""==""/sp"" set YJUSD_RESCAN=1
if ""%1""==""/si"" set YJUSD_SILENT=-silent
if ""%1""==""/su"" set YJUSD_SILENT=-silent
if ""%1""==""/sp"" set YJUSD_SILENT=-silent

@rem Appears wdreg.exe may output a header even when silent is specified so use wdreg_gui.exe for silent operation
if ""%1""==""/si"" set YJUSD_WDREGEXE=wdreg_gui.exe
if ""%1""==""/su"" set YJUSD_WDREGEXE=wdreg_gui.exe
if ""%1""==""/sp"" set YJUSD_WDREGEXE=wdreg_gui.exe

if ""%2""=="""" goto DONESETARGS
set YJUSD_DRIVERPATH=%2
:DONESETARGS

@rem **********************************************************************************
@rem Check Driver Location
@rem **********************************************************************************
if exist "%YJUSD_DRIVERPATH%\%YJUSD_WDREGEXE%" goto DRIVERPATHOK
@echo Driver path (%YJUSD_DRIVERPATH%) incorrect, validate the path is correct and re-run the install.
goto END
:DRIVERPATHOK

@rem **********************************************************************************
@rem Run wdreg.exe based on the action specified
@rem **********************************************************************************
if ""%YJUSD_ACTION%""==""install"" goto INSTALL
if ""%YJUSD_ACTION%""==""preinstall"" goto PREINSTALL
if ""%YJUSD_ACTION%""==""uninstall"" goto UNINSTALL
@echo Action (%YJUSD_ACTION%) incorrect, validate the options are correct and re-run the install.
goto END

@rem **********************************************************************************
@rem Install/Preinstall driver
@rem **********************************************************************************
:PREINSTALL
:INSTALL
@set LOGFILE="%USERPROFILE%\Install-you.log"
if exist %LOGFILE% del %LOGFILE%
@echo. > %LOGFILE%

@set DRIVER_VER_FILE="%USERPROFILE%\YJ_USB_Serial_Driver_Version.txt"
if exist %DRIVER_VER_FILE% del %DRIVER_VER_FILE%
@echo. > %DRIVER_VER_FILE%
@echo **************************************************************************** >> %DRIVER_VER_FILE%
@echo YJ USB Serial Driver r%YJUSD_VER% installed - %date% %time% >> %DRIVER_VER_FILE%
@echo **************************************************************************** >> %DRIVER_VER_FILE%

@echo ************************************************************ >> %LOGFILE%
@echo WDREG LOG - %date% %time% >> %LOGFILE%
@echo ************************************************************ >> %LOGFILE%
@echo YJUSD_VER=%YJUSD_VER% >> %LOGFILE%
@echo ARG[1]=%1 >> %LOGFILE%
@echo ARG[2]=%2 >> %LOGFILE%
@echo YJUSD_WDREGEXE=%YJUSD_WDREGEXE% >> %LOGFILE%
@echo YJUSD_DRIVERPATH=%YJUSD_DRIVERPATH% >> %LOGFILE%
@echo YJUSD_ACTION=%YJUSD_ACTION% >> %LOGFILE%
@echo YJUSD_SILENT=%YJUSD_SILENT% >> %LOGFILE%
@echo YJUSD_INSTALLCONTROL=%YJUSD_INSTALLCONTROL% >> %LOGFILE%
@echo YJUSD_INSTALLENUM=%YJUSD_INSTALLENUM% >> %LOGFILE%
@echo YJUSD_INSTALLCDC=%YJUSD_INSTALLCDC% >> %LOGFILE%
@echo YJUSD_CAPTURESETUPAPILOG=%YJUSD_CAPTURESETUPAPILOG% >> %LOGFILE%
@echo YJUSD_RESCAN=%YJUSD_RESCAN% >> %LOGFILE%

@rem Force 'install' (not 'preinstall') on youjie_enum_control_???, it is not PNP so it will not be installed if
@rem 'preinstall' is used.

for /f "delims=|" %%f in ('dir /b "%YJUSD_DRIVERPATH%\youjie_enum_control.inf"') do ^
"%YJUSD_DRIVERPATH%\%YJUSD_WDREGEXE%" -inf "%YJUSD_DRIVERPATH%\%%f" %YJUSD_SILENT% -log %LOGFILE% install
 
for /f "delims=|" %%f in ('dir /b "%YJUSD_DRIVERPATH%\youjie_enum.inf"') do ^
"%YJUSD_DRIVERPATH%\%YJUSD_WDREGEXE%" -inf "%YJUSD_DRIVERPATH%\%%f" %YJUSD_SILENT% -log %LOGFILE% %YJUSD_ACTION%

for /f "delims=|" %%f in ('dir /b "%YJUSD_DRIVERPATH%\youjie_cdc.inf"') do ^
"%YJUSD_DRIVERPATH%\%YJUSD_WDREGEXE%" -inf "%YJUSD_DRIVERPATH%\%%f" %YJUSD_SILENT% -log %LOGFILE% %YJUSD_ACTION%

goto SKIPUNINSTALL

@rem **********************************************************************************
@rem Uninstall driver
@rem **********************************************************************************
:UNINSTALL
@set LOGFILE="%USERPROFILE%\Uninstall-you.log"
if exist %LOGFILE% del %LOGFILE%
@set DRIVER_VER_FILE="%USERPROFILE%\YJ_USB_Serial_Driver_Version.txt"
if exist %DRIVER_VER_FILE% del %DRIVER_VER_FILE%
@echo. > %LOGFILE%

@echo ************************************************************ >> %LOGFILE%
@echo WDREG LOG - %date% %time% >> %LOGFILE%
@echo ************************************************************ >> %LOGFILE%
@echo YJUSD_VER=%YJUSD_VER% >> %LOGFILE%
@echo ARG[1]=%1 >> %LOGFILE%
@echo ARG[2]=%2 >> %LOGFILE%
@echo YJUSD_WDREGEXE=%YJUSD_WDREGEXE% >> %LOGFILE%
@echo YJUSD_DRIVERPATH=%YJUSD_DRIVERPATH% >> %LOGFILE%
@echo YJUSD_ACTION=%YJUSD_ACTION% >> %LOGFILE%
@echo YJUSD_SILENT=%YJUSD_SILENT% >> %LOGFILE%
@echo YJUSD_INSTALLCONTROL=%YJUSD_INSTALLCONTROL% >> %LOGFILE%
@echo YJUSD_INSTALLENUM=%YJUSD_INSTALLENUM% >> %LOGFILE%
@echo YJUSD_INSTALLCDC=%YJUSD_INSTALLCDC% >> %LOGFILE%
@echo YJUSD_CAPTURESETUPAPILOG=%YJUSD_CAPTURESETUPAPILOG% >> %LOGFILE%
@echo YJUSD_RESCAN=%YJUSD_RESCAN% >> %LOGFILE%

for /f "delims=|" %%f in ('dir /b %YJUSD_DRIVERPATH%\youjie_cdc.inf') do ^
"%YJUSD_DRIVERPATH%\%YJUSD_WDREGEXE%" -inf "%YJUSD_DRIVERPATH%\%%f" %YJUSD_SILENT% -log %LOGFILE% %YJUSD_ACTION%

for /f "delims=|" %%f in ('dir /b %YJUSD_DRIVERPATH%\youjie_enum.inf') do ^
"%YJUSD_DRIVERPATH%\%YJUSD_WDREGEXE%" -inf "%YJUSD_DRIVERPATH%\%%f" %YJUSD_SILENT% -log %LOGFILE% %YJUSD_ACTION%

for /f "delims=|" %%f in ('dir /b %YJUSD_DRIVERPATH%\youjie_enum_control.inf') do ^
"%YJUSD_DRIVERPATH%\%YJUSD_WDREGEXE%" -inf "%YJUSD_DRIVERPATH%\%%f" %YJUSD_SILENT% -log %LOGFILE% %YJUSD_ACTION%

:SKIPUNINSTALL

@rem **********************************************************************************
@rem Rescan, needed if driver is preinstall and device is already connected.   Much faster to preinstall and rescan 
@rem than to install, install searches for every device in inf.
@rem **********************************************************************************
if ""%YJUSD_RESCAN%""==""0"" GOTO SKIPYJUSDRESCAN
"%YJUSD_DRIVERPATH%\%YJUSD_WDREGEXE%" -rescan USB %YJUSD_SILENT% -log %LOGFILE% %YJUSD_ACTION%
:SKIPYJUSDRESCAN

@rem **********************************************************************************
@rem Copy SetupAPI log to install/uninstall log
@rem **********************************************************************************
if ""%YJUSD_CAPTURESETUPAPILOG%""==""0"" GOTO END
@echo. >> %LOGFILE% 
if exist "%SystemRoot%\setupapi.log" @echo ************************************************************ >> %LOGFILE%
if exist "%SystemRoot%\setupapi.log" @echo SETUPAPI LOG >> %LOGFILE%
if exist "%SystemRoot%\setupapi.log" @echo ************************************************************ >> %LOGFILE%
if exist "%SystemRoot%\inf\setupapi.dev.log" @echo ************************************************************ >> %LOGFILE%
if exist "%SystemRoot%\inf\setupapi.dev.log" @echo SETUPAPI LOG >> %LOGFILE%
if exist "%SystemRoot%\inf\setupapi.dev.log" @echo ************************************************************ >> %LOGFILE%
if exist "%SystemRoot%\setupapi.log" @type %SystemRoot%\setupapi.log >> %LOGFILE%
if exist "%SystemRoot%\inf\setupapi.dev.log" @type %SystemRoot%\inf\setupapi.dev.log >> %LOGFILE%


:END