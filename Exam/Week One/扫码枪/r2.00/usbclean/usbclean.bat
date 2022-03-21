@echo off
@rem.
@rem =====================================================================
@rem Name: usbclean.bat 
@rem Version: %USBCLEAN_VER%
@rem Description: This is the clean up utility for completely removing all
@rem USB installed components
@rem Usage:
@rem usbclean /y  ==> This format is intended to be used by an unattended
@rem                     application during the uninstallation process of the 
@rem usbclean     ==> This format would be used when run as a standalone 
@rem                     process
@rem Revision History:
@rem  Version       Author      Description
@rem   1.0          KL          Initial Release
@rem   1.1          KL          Modified script for using custom findString.exe
@rem   1.2          KL          Delete the USB Serial Driver Package Version
@rem   1.3          KL          caller will cd to usbclean.
@rem   1.4          KL          For MSI, WoW64 is used, we need to use the 
@rem                            PROCESSOR_ARCHITEW6432 environment variable to figure
@rem                            out the system architecture type.
@rem   1.5          KL          Work from parent directory of usbclean
@rem   1.6          KL          For WOW64, use %windir%\sysnative for %windir%\system32
@rem   1.7          KL          Add support for Windows XP 64 and Windows Vista
@rem   1.8          KL          Manually delete files in driver store for xp 32 64, and POSReady 2009
@rem   1.9          KL          Fix a couple of issues reported by Jean-Luc of Intermec
@rem                            a/ %USERPROFILE% string may have special charaters in there
@rem   1.10         KL          Introduce a second parameter, /rem, remove device only
@rem   1.11         KL          Make sure that this script can be used as standalone.
@rem                            If %PROCESSOR_ARCHITEW6432% is not set. Then this means either this is
@rem                            either 64 bit but outside WOW, or 32 bit OS
@rem   1.12         KL          Get rid off null file
@rem   1.13         KL          Take of cleaning up for really old driver, driver that use honeywell_enum_0xx.inf
@rem   1.14	        KL          Add support for Windows 8.1
@rem   1.15         KL          Remove YOUJIE devices, and not touching other device.
@rem =====================================================================
@rem.
if "%1" EQU "/y" (goto START)
rem  ========== CONFIRMATION PROMPT ======================================
@echo Executing this batch file will completely clean up your 
@echo USB Serial Driver installation and MAY render your scanner UNusable 
@echo This should only be done when directed by Honeywell Scanning ^& 
@echo Mobility technical support.
@echo ====================================================================      
@rem.
set /p answer=Reply Y to continue or N to exit^:
if /I "%answer%" EQU "Y" (goto START) else (goto END)
:START
@rem.
@rem Figure out "system type" and "os type"
@rem Zero out the environment variable here ....
@echo starting to completely clean the current USB Serial Driver Install ...
@set TARGETOS="Windows POSReady 2009"
@set DEVCON=.\usbclean\x86\devcon_86.exe
@set DRIVERSTOREPATH="%SystemRoot%\System32\DRVSTORE"
@set REINSTALL="%SystemRoot%\System32\ReinstallBackups"
@set USBCLEAN_VER=1.15
@set POSREADY2009=yes
@set YJENUMFILESIZE=0
@set YJCDCFILESIZE=0
@set YJENUMCONTROLFILESIZE=0

echo usbclean version: %USBCLEAN_VER%
@rem figure out if findstr.exe exist ....
if exist %SystemRoot%\System32\findstr.exe (
set FINDSTR="%SystemRoot%\System32\findstr.exe"
set POSREADY2009=no
) else (
echo POSREADY2009=%POSREADY2009%
set FINDSTR="%cd%\usbclean\x86\findString.exe"
)
@rem.
if exist %SystemRoot%\System32\reg.exe (
set REG="%SystemRoot%\System32\reg.exe"
) else (
echo ...reg.exe does not exist... bail ...
goto END
)
@rem.
if "%POSREADY2009%"=="yes" ( goto DONEOS )
ver | %FINDSTR% /C:"5.0" > nul 2>&1
if %ERRORLEVEL%==0 goto WIN2K
ver | %FINDSTR% /C:"5.1" > nul 2>&1
if %ERRORLEVEL%==0 goto WINXP
ver | %FINDSTR% /C:"5.2" > nul 2>&1
if %ERRORLEVEL%==0 goto WINXP_64
ver | %FINDSTR% /C:"6.0" > nul 2>&1
if %ERRORLEVEL%==0 goto WINVISTA
ver | %FINDSTR% /C:"6.1" > nul 2>&1
if %ERRORLEVEL%==0 goto WIN7
ver | %FINDSTR% /C:"6.2" > nul 2>&1
if %ERRORLEVEL%==0 goto WIN8
ver | %FINDSTR% /C:"6.3" > nul 2>&1
if %ERRORLEVEL%==0 goto WIN81
goto DONEOS

:WIN2K
@set TARGETOS="Windows 2000"
echo Unsupported OS: %TARGETOS% ...
goto END

:WINXP
@set TARGETOS="Windows XP"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DRVSTORE"
@set REINSTALL="%SystemRoot%\System32\ReinstallBackups"
goto DONEOS

:WINXP_64
@set TARGETOS="Windows XP 64"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DRVSTORE"
@set REINSTALL="%SystemRoot%\System32\ReinstallBackups"
goto DONEOS

:WINVISTA
@set TARGETOS="Windows Vista"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DriverStore\FileRepository"
goto DONEOS

:WIN7
@set TARGETOS="Windows 7"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DriverStore\FileRepository"
goto DONEOS

:WIN8
@set TARGETOS="Windows 8"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DriverStore\FileRepository"
goto DONEOS

:WIN81
@set TARGETOS="Windows 8.1"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DriverStore\FileRepository"
goto DONEOS

:DONEOS
@rem Now we need to figure out if the environment variable PROCESSOR_ARCHITEW6432 is defined as AMD64
@rem if not, then this is a 32 bit install and we can use PROCESSOR_ARCHITECTURE 
@rem if it is defined, then this is 64 bit system
if "%PROCESSOR_ARCHITEW6432%"=="AMD64" (
@set DEVCON=.\usbclean\x64\devcon_64.exe
@set SYSTEMTYPE=x64
) else (
if "%PROCESSOR_ARCHITECTURE%"=="AMD64" (
@echo executing as standalone in 64 bit OS ...
@set DEVCON=.\usbclean\x64\devcon_64.exe
@set SYSTEMTYPE=x64
) else (
@set SYSTEMTYPE=x86
@set DEVCON=.\usbclean\x86\devcon_86.exe
)
)
@echo TARGETOS [%TARGETOS%]
@echo SYSTEMTYPE [%SYSTEMTYPE%]
@echo DEVCON=%DEVCON%
@rem, note, at this point, if target is Windows 2000, TARGETOS will not be set ....
@rem Now, set the path for the Driver Store location depending on the OS

@rem remove all devnode *usbcdcacm\vid_23d0*
%DEVCON% -r remove *usbcdcacm\vid_23d0*
@rem remove all devnode *usb\vid_23d0*
%DEVCON% -r remove *usb\vid_23d0&pid_*a&MI_00 *usb\vid_23d0&pid_*4
@rem, skip the rest of the steps if this script is run to only remove the devices
@rem, we need to do this before uninstall, so that the COM port can be released from COMDb
if "%2" EQU "/rem" (
@echo ...REMOVE DEVICE ONLY...
goto END
)

@set WINDOWS_INF_DIR=%SystemRoot%\inf
@rem create a file that has the list of all oemxx.inf that is for youjie_enum.inf, youjie_enum_control.inf, and youjie_cdc.inf
@set YJENUMFILELIST="%USERPROFILE%\yjenumfilelist.txt"
if exist %YJENUMFILELIST% del /F /Q %YJENUMFILELIST%
@set YJCDCFILELIST="%USERPROFILE%\yjcdcfilelist.txt"
if exist %YJCDCFILELIST% del /F /Q %YJCDCFILELIST%
@set YJENUMCONTROLFILELIST="%USERPROFILE%\yjenumcontrolfilelist.txt"
if exist %YJENUMCONTROLFILELIST% del /F /Q %YJENUMCONTROLFILELIST%
@pushd .
@cd /d %WINDOWS_INF_DIR%
if "%POSREADY2009%"=="yes" ( goto POSR2009-2 )
@%FINDSTR% "youjie_enum.cat" oem*.inf >> %YJENUMFILELIST%
@%FINDSTR% "youjie_cdc.cat" oem*.inf >> %YJCDCFILELIST%
@%FINDSTR% "youjie_enum_control.cat" oem*.inf >> %YJENUMCONTROLFILELIST%
goto POSR2009-3
:POSR2009-2
@%FINDSTR% youjie_enum.cat oem*.inf >> %YJENUMFILELIST%
@%FINDSTR% youjie_cdc.cat oem*.inf >> %YJCDCFILELIST%
@%FINDSTR% youjie_enum_control.cat oem*.inf >> %YJENUMCONTROLFILELIST%
:POSR2009-3
@popd
@rem
@rem for now, just go to the USERPROFILE directory and figure out the size
@rem
@pushd .
@cd /d "%USERPROFILE%"
@rem Now, that we are here. We need to find out if each of the above files
@rem is non-zero, and only perform devcon on non-zero file
@rem figure out the size for the files ...
for /f "usebackq" %%A in ('"yjenumfilelist.txt"') do @set YJENUMFILESIZE=%%~zA
for /f "usebackq" %%A in ('"yjcdcfilelist.txt"') do @set YJCDCFILESIZE=%%~zA
for /f "usebackq" %%A in ('"yjenumcontrolfilelist.txt"') do @set YJENUMCONTROLFILESIZE=%%~zA
@popd
@rem
@echo deleting enum, cdc ....
if %YJENUMFILESIZE% equ 0 ( goto SKIP-ENUM-YJ )
for /f "tokens=1 delims=:" %%A in ('@type %YJENUMFILELIST%') do ^
%DEVCON% -f dp_delete %WINDOWS_INF_DIR%\%%A
@rem
:SKIP-ENUM-YJ
@rem
if %YJCDCFILESIZE% equ 0 ( goto SKIP-CDC-YJ )
for /f "tokens=1 delims=:" %%A in ('@type %YJCDCFILELIST%') do ^
%DEVCON% -f dp_delete %WINDOWS_INF_DIR%\%%A
@rem
:SKIP-CDC-YJ
if %YJENUMCONTROLFILESIZE% equ 0 ( goto SKIP-ENUMC-YJ )
for /f "tokens=1 delims=:" %%A in ('@type %YJENUMCONTROLFILELIST%') do ^
%DEVCON% -f dp_delete %WINDOWS_INF_DIR%\%%A
@rem
:SKIP-ENUMC-YJ
@echo Finally, deleting driver files
if "%PROCESSOR_ARCHITEW6432%"=="AMD64" (
@del /F /Q %windir%\sysnative\drivers\youjie_enum*.sys
@del /F /Q %windir%\sysnative\drivers\youjie_cdc*.sys
@set DRIVERSTOREPATH="%windir%\sysnative\DRVSTORE"
@set REINSTALL="%windir%\sysnative\ReinstallBackups"
) else (
del /F /Q %SystemRoot%\system32\drivers\youjie_enum*.sys
@del /F /Q %SystemRoot%\system32\drivers\youjie_cdc*.sys
)
@rem.
@rem Now, manually delete stuff in driver store for POSReady 2009, XP 32, and XP 64
if %TARGETOS%=="Windows POSReady 2009" (goto STORE09XP)
if %TARGETOS%=="Windows XP" (goto STORE09XP)
if %TARGETOS%=="Windows XP 64" (goto STORE09XP)
goto DELVER
:STORE09XP
echo DRIVERSTOREPATH=%DRIVERSTOREPATH%
if not exist %DRIVERSTOREPATH% (goto CHKREINSTALL)
@pushd .
cd /d %DRIVERSTOREPATH%
for /d %%a in (youjie*) do rd /s /q %%a
@popd
:CHKREINSTALL
echo REINSTALL=%REINSTALL%
if not exist %REINSTALL% (goto DELVER)
@pushd .
cd /d %REINSTALL%
del /s /q /f *youjie*
del /s /q /f *acmfccoi*
@popd
:DELVER
@rem, delete driver version here if exist, for youjie, there is none
:END
@echo usbclean completes ...
