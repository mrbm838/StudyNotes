@rem Uninstall x64 Drivers
cd /d %~d0%~p0
call _install.bat /u .\x64
call usbclean\usbclean.bat /y
