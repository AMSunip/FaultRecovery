Name
      FaultRecovery          2018/06/01
     
Purpose

  FaultRecovery is a tool to restore fault displacement, and you can 
easily obtain the horizontal displacement of fault with this tool.

Environment requirements

  FaultRecovery should run on all 64-bit computers.  
  Use an Microsoft Visual Studio 2015 to compile the program. 
  FaultRecovery's C# interface may change without notice.  
  Eventually, it will move into the FaultRecovery shared library.
  
  FaultRecovery is copyrighted software.  

-----------------
Installing FaultRecovery on Windows 10, 8, 7 (64-bit)

  The zip file contains FaultRecovery.exe, and to use FaultRecovery:
  - Unzip the files into a directory (e.g., named 'FaultRecovery')
  - Click on FaultRecovery
  - Than you can use it
    
  To uninstall FaultRecovery
  - Delete the FaultRecovery directory

------------------
Compiling FaultRecovery with Microsoft Visual Studio 2015

  To compile 64-bit FaultRecovery with Microsoft Visual Studio 2015 and later
  - Download and extract FaultRecovery (.zip file)
  - Load solution FaultRecovery/FaultRecovery.sln 
  - Build target 'x64'
  - Project FaultRecoverytest do not need any other environment

-----------------
Distributed files
  README.txt                          // Instructions for installing FaultRecovery 

  FaultRecovery.sln                   // Solution File
  FaultRecovery.csproj                // C# Project File
  
  FaultRecovery/Const.cs              // Source code
  FaultRecovery/Core.cs               // Source code
  FaultRecovery/FaultKeyLine.cs       // Source code
  FaultRecovery/FileManager.cs        // Source code
  FaultRecovery/FormatManager.cs      // Source code
  FaultRecovery/KeyLine.cs            // Source code
  FaultRecovery/KeyRectangle.cs       // Source code
  FaultRecovery/Parameter.cs          // Source code
  FaultRecovery/PointXYZ.cs           // Source code
  
  FaultRecovery/Program.cs            // Application
  FaultRecovery/Form1.cs              // Frame GUI
  FaultRecovery/Form1.Designer.cs     // Designer
  FaultRecovery/Form1.resx            // Resource
  
-----------------
Authors:
  Ai Ming
  
Contract us: 
  aiming_cea@163.com
  
  If you find FaultRecovery useful, please let us know.
