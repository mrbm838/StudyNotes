YJ USB Serial Driver r2.00 - 01/13/16
===========================================

This Youjie USB Driver package - Non-Microsoft WHQL Certified, supports the following device:

1/ YJ4600 = VID_23D0/PID_0B94 (REM off)
            VID_23D0/PID_0B8A (REM on)

2/ GS550  = VID_23D0&PID_0BB4 (REM off)
            VID_23D0&PID_0BAA (REM on)

3/ YJHF600 = VID_23D0&PID_0BF4 (REM off)
             VID_23D0&PID_0BEA (REM on)
            
4/ YJHH360 = VID_23D0&PID_0C34 (REM off)
            VID_23D0&PID_0C2A (REM on)
            
5/ YJHF500 = VID_23D0&PID_0C54 (REM off)
            VID_23D0&PID_0C4A (REM on)  
            
6/ YJHH660 = VID_23D0&PID_0C74 (REM off)
            VID_23D0&PID_0C6A (REM on)

 This driver package can coexist with the Honeywell HSM USB driver package.

WINDOWS OS SUPPORTED:
======================
1/ Windows XP 32 and 64 bit
2/ Windows Vista 32 and 64 bit
3/ Windows 7 32 and 64 bit
4/ Windows 10 32 and 64 bit
5/ Windows Embedded WEPOS
6/ Windows Embedded POSReady 2009
7/ Windows Embedded POSReady 7
8/ Windows Embedded 8 Industry
9/ Windows Embedded 8.1 Industry
10/ Windows 10 IoT Enterprise LTSB 2015


Driver Installation/Uninstallation Instructions
===============================================

1/ Installation:
  A/ Windows 32 bits OS:
    * For Windows Embedded variants, xp: Browse and double click the install file "Install_x86.bat" in the install media folder.
    * For Windows Vista, 7, 8.x, 10: Browse, right click, and select "Run as administrator" the install file "Install_x86.bat" in the install media folder.

  B/ Windows 64 bits OS:
    * For Windows xp: Browse and double click the install file "Install_x64.bat" in the install media folder.
    * For Windows Vista, 7, 8.x, 10: Browse, right click, and select "Run as administrator" the install file "Install_x64.bat" in the install media folder.

2/ Uninstallation:
  A/ Windows 32 bits OS:
    * For Windows Embedded variants, xp: Browse and double click the install file "Uninstall_x86.bat" in the install media folder.
    * For Windows Vista, 7, 8.x, 10: Browse, right click, and select "Run as administrator" the install file "Uninstall_x86.bat" in the install media folder.

  B/ Windows 64 bits OS:
    * For Windows xp: Browse and double click the install file "Uninstall_x64.bat" in the install media folder.
    * For Windows Vista, 7, 8.x, 10: Browse, right click, and select "Run as administrator" the install file "Uninstall_x64.bat" in the install media folder.

KNOWN ISSUES
=============

1/ When Force COM port feature is enabled, the friendly name found in device manager->ports does not have the 
(COM#) suffix immediately after installation. However, it does get added on next driver start.

2/ Blue Screen Of Death (BSOD) may occur on some devices using Windows XP SP2 when coming out of suspend mode.
This is a bug in Windows. Please download Windows XP SP3 or Windows Hot Fix 949483 to resolve.

http://support.microsoft.com/hotfix/KBHotfix.aspx?kbnum=949483&kbln=en-us
   
3/ Installation of a Non-Microsoft WHQL certified driver on Windows XP sometimes may fail with an error of 
"TRUST_E_NOSIGNATURE". This installation error is caused by target machine does not have the latest Microsoft
root certificate installed.
Here are the steps to correct this issue:
   a/ Follow the below link to install the correct MS root certificate on target machine:
   http://www.microsoft.com/en-us/download/details.aspx?id=38918
   
   b/ Reboot target machine.
   
   c/ Install the USB Serial beta driver.

4/ Installation of the unsigned driver on Windows 7, 64 bit may fail due to SHA2 is not natively supported in the OS.
When this happens, the "Honeywell Control Device" component of the driver under Windows Device Manager, USB device class,
may have a yellow exclaimation mark indicating that this driver component fails to start.
To resolve this issue, please manually install the below security update.
https://www.microsoft.com/en-us/download/details.aspx?id=46148

   
NOTES:
======
1/ The Microsoft Visual C++ 2010 Redistributable Package may be required to be installed on target computer.

* 32 bit OS: 
http://www.microsoft.com/en-us/download/details.aspx?id=5555

* 64 bit OS:
http://www.microsoft.com/en-us/download/details.aspx?id=14632