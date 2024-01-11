# IRIS Screen Exporter Change Log
## 1.6.3
1. Mulitple changes to the server and client to allow loading of configuration files from the user interface.
1. Fix for exception thrown in the server when the server is started by double clicking without a configuration file being specified. #13
1. Default configuration folder changed to "My Documents" `\Helios\IRIS` and this will be created if it does not already exist.
1. `iris.xml` is loaded when no configuration file is specified on startup. 
## 1.6.2
This corrects the following problems with 1.6.1
1. If a send fails because the viewport data was too large for the network, Iris-Server will not close. Instead future large sends will not be attempted with the result that the viewport will appear to freeze, or in some situations the image will become sporadic if the image size is typically very close to the maximum value.
1. The Global Image Adjustment values were not properly restored to the Iris-Server panel when the configuration was loaded.
## 1.6.1
1. Global Image Adjustment option to allow all viewports without specific image adjustments to have their brightness, contrast, and gamma adjusted before it is sent to the Iris-Client
2. ViewPort image Adjustment allows the brightness, contrast, and gamma for a particular viewport to be adjusted before it is sent to the Iris-Client
3. New versioning structure
4. CI workflow action to allow more build consistency
5. Both a 32bit and 64bit installer is available
6. Restored missing Client Viewport movement controls
7. Major rewrite of the documentation
8. New configuration examples added
9. Solution tidy up which was long overdue.
10. Added error checking to the file operations
11. Created a folder in the %userprofile% of the user installing the software to contain the example configurations files
12. Changed the default icons.
13. Made the shortcuts for the server and client load the configurations from the new folder in the user's documents file to avoid not authorized exceptions when saving to the Program Files location
## 1.0.2022.0507
1. Moved into HeliosVirtualCockpit parent directory
2. Added forms icons
3. Installation back to all users
4. Forms Title text for Server and Client changed to Iris Screen Exporter - 
## 1.0.2020.0531
1. Changed build to Any CPU to allow to be installed on 32 bit systems which might be running clients for a single screen.  This means that on 64 bit systems, it could be installed in Program Files(x86) now.
2. Moved the installation out of the "IRIS" sub directory
3. Improved and corrected the error messages for network errors and "Message Too Large" in particular.
4. Installation default is now just for the current user rather than all users.