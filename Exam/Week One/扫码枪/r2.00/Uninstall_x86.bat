@rem Uninstall x86 Drivers
cd /d %~d0%~p0
call _install.bat /u .\x86
call usbclean\usbclean.bat /y