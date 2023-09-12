Option Explicit
On Error Resume Next
Dim argNum, argCount:argCount = Wscript.Arguments.Count
if argCount = 0  then
   Wscript.Echo "Installer Post Build changes requires an argument which is the" &_
   vbLf & " msi file to have the releases changed, and also set certain flags." &_
   vbLf & " No argument was passed into the HeliosInstallAdjustments.vbs file." &_
   vbLf & " SELECT queries will display the rows of the result list specified in the query"
    Wscript.Quit 1
else
   Dim msiPackage:msiPackage = Wscript.Arguments(0)
   Dim oShell 
   Dim TypeLib
   Dim version:version = Wscript.Arguments(1)
   Dim infinity:infinity = "65535" & MID(version, 2)
   Wscript.Echo "Starting Post Build Script to set up " & msiPackage & " for version " & version
   Wscript.Echo "Setting file versions to " & infinity

   ' https://docs.microsoft.com/en-us/windows/win32/msi/database-object
   ' https://docs.microsoft.com/en-us/windows/win32/msi/session-object

   Dim irisUpgrade:irisUpgrade = "{BB0CC9B8-5D95-4308-B06E-1D6CE5297700}"
   Dim iris32Upgrade:iris32Upgrade = "{58B0C1EC-2E6E-4545-BDB9-08A9EA984801}"
   Dim upgradeCode:upgradeCode = irisUpgrade
   
   ' open MSI as database session ourselves, instead of using WiRunSQL wrapper
   Dim installer : Set installer = Wscript.CreateObject("WindowsInstaller.Installer") : CheckError "connect to installer"
   Dim database : Set database = installer.OpenDatabase(msiPackage, 1) : CheckError "open database"
   Dim session : Set session = installer.OpenPackage(database,1) : If Err <> 0 Then Fail "Installer: '" & msiPackage & "' has invalid installer package format"

   ' check product (this script is shared)
   if session.Property("Title") = "Iris Screen Exporter Setup 32bit" then
        Wscript.Echo "configuring Iris 32bit Installer"
        upgradeCode = iris32Upgrade
   end if

   ' change product version and file versions
   Execute database, "UPDATE Property SET `Value` = '" & version & "' WHERE `Property` = 'ProductVersion'"
   Execute database, "UPDATE File SET `Version` = '" & infinity & "' WHERE `Version` <> ''"

   ' make all upgrades major upgrades
   Set TypeLib = CreateObject("Scriptlet.TypeLib")
   Dim newGuid:newGuid = TypeLib.Guid
   newGuid = Left(newGuid, Len(newGuid)-2)
   Execute database, "UPDATE Property SET `Value` = '" & newGuid & "' WHERE `Property` = 'ProductCode'"

   ' run custom actions as user instead of system
   Execute database, "UPDATE CustomAction SET `Type` = 1025 WHERE `Type` = 3073"


   ' allow any version to upgrade
   Execute database, "DELETE FROM Upgrade"
   Execute database, "INSERT INTO Upgrade(UpgradeCode, VersionMin, Attributes, ActionProperty) VALUES ('" & upgradeCode & "', '" & version & "', '258', 'NEWERPRODUCTFOUND')"
   Execute database, "INSERT INTO Upgrade(UpgradeCode, VersionMax, Attributes, ActionProperty) VALUES ('" & upgradeCode & "', '" & version & "', '0', 'PREVIOUSVERSIONINSTALLED')"

   ' set disable advertise shortcuts if not already done
   if session.Property("DISABLEADVTSHORTCUTS") < "1" then
      Wscript.Echo "Setting DISABLEADVTSHORTCUTS = 1"
      Execute database, "INSERT INTO Property(Property, Value) VALUES ('DISABLEADVTSHORTCUTS', '1')"
   else
      Wscript.Echo "DISABLEADVTSHORTCUTS " & session.Property("DISABLEADVTSHORTCUTS")
   end if

   ' commit database
   database.Commit() : CheckError "commit"

end if

Wscript.Quit 0

Sub Execute(database, sql)
   Dim view: Set view = database.OpenView(sql) : CheckError sql
   view.Execute : CheckError sql
   ' this appears to be async, so it breaks if we release view, and there is no way
   ' to wait for result because Fetch is not allowed
   ' Dim record: Set record = view.Fetch
   ' view.Close
   ' view = nothing

end Sub

Sub CheckError(context)
    Dim message, errRec
    If Err = 0 Then Exit Sub
    message = context & ": " & Err.Source & " " & Hex(Err) & ": " & Err.Description
    If Not installer Is Nothing Then
        Set errRec = installer.LastErrorRecord
        If Not errRec Is Nothing Then message = message & vbNewLine & errRec.FormatText
    End If
    Fail message
End Sub

Sub Fail(message)
    Wscript.Echo message
    Wscript.Quit 2
End Sub

 
