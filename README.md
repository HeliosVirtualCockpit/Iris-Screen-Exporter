# Iris Screen Exporter
[![Build and Create Installation Files for Iris](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/actions/workflows/Build.yml/badge.svg)](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/actions/workflows/Build.yml)
## Downloading
If you just want to install this program, go to [Releases](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/releases/latest) and select the windows installer package of your choice from the **Assets** section.
## Overview
<details markdown="1">
<summary markdown="span">
Learn more about how Iris allows you to define “viewports” on your screen that will be captured and exported over the network via UDP to be displayed on another machine.   All of the settings are stored in the iris.xml configuration file.  Both the Iris server and Iris client can share the same configuration file.  This makes it possible to install Iris on a shared drive and run the executable files on different computers.
</summary>
  
Iris was Originally written by Will Hartsell and was inspired by [Gremlin77’s Visual Basic based Screen Exporter](http://forums.eagle.ru/showpost.php?p=1696987&postcount=183).  Iris Screen Exporter is now enhanced and supported by Contributors to the Helios Virtual Cockpit project.

## What is Iris Screen Exporter?
Iris captures sections of screen on one Windows computer and displays them on another.
Iris allows you to define “viewports” on your screen that will be captured and exported over the
network via UDP to be displayed on another machine. All of the settings are stored in the iris.xml
configuration file. Both the Iris server and Iris client can share the same configuration file. This makes it
possible to install Iris on a shared drive and run the executable files on different computers.
Iris also allows some image adjustments to be made on the captured screen before it is sent.  These
adjustments are limited to brightness, contrast and gamma.

**12 September 2023**

|**Contents**|
|------------|
|[Iris Screen Exporter](#_gjdgxs)|
|[Overview](#)|
|[The Iris-Server](#)|
|[Config Tab](#_wse0cx1uvg16)|
|[Viewport Tabs](#)|
|[Command Line](#_fknvkmmfsaz1)|
|[Network Considerations](#_2et92p0)|
|[The Iris–Client](#_3dy6vkm)|
|[Viewport Windows](#)|
|[Viewport Context Menu](#)|
|[Usage Notes](#_j65h8os39wub)|
|[The iris.xml configuration file](#_srjwu38amjpm)|
|[Example Configurations](#_m3rgds1ga4k2)|
|[Copying a Rectangular Area on a Single Computer](#_dyecn0ou6x3l)|
|[Copying Two Rectangular Areas to a Second Computer](#_9h4hw7pezu62)|
|[Copying Three Rectangular Areas to a Second & Third Computer and Adjusting the Image Brightness](#_yoiy79z0oc4p)|
|[Creating a Background for the Viewports](#_rp5ff08whafl)|
|[Alternative Clients](#)|
|[Known Issues](#_q78gvp37ng2j)|
|[Change Log](#_3rh39437j399)|
|[1.6.1](#_9e9w0qp85coe)|
|[1.0.2022.0507](#)|
|[1.0.2020.0531](#)|
|[1.0.2019.0316](#)|

## Overview

Iris allows you to define "viewports" on your screen that will be captured and exported over the network via UDP to be displayed on another machine. All of the settings are stored in the iris.xml configuration file. Both the Iris server and Iris client can share the same configuration file. This makes it possible to install Iris on a shared drive and run the executable files on different computers.

## The Iris-Server

Iris-Server is the program responsible for capturing and sending the viewports over the network. For every viewport defined in the "iris.xml" file it will capture that viewport and send it via UDP to the corresponding host/port defined. Since host/port is defined for each viewport it is possible for a single server to send viewports to many clients running on multiple machines. Each viewport must have a unique port number which needs to be unused by another program or service.

![image](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/assets/18526232/fbedcd14-af6d-4af4-aef6-b18dbf7f9b1f)


The Iris-Server Window contains a Configuration Tab, and a Tab named for each viewport defined in iris.xml configuration file.

### Config Tab

The Config tab in the Server main window contains options for starting and stopping the viewport capturing process (1). Additionally there are controls to alter the frequency of capturing images (2), and also parameters to control any adjustments which are to be made to the image (3) before it is sent to the client.

![image](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/assets/18526232/ebbd0a46-fdc9-429f-ac9f-8ca96ee3243d)

### Viewport Tabs

For every defined viewport in the iris configuration xml document, a tab is created that displays what is being captured in the current viewport. When you turn on capture, this display will be updated each time a capture takes place. This allows you to verify the server is "seeing" what you want it to see in each viewport.
In the example to the left you can see that the viewport named "Left MFCD" is displayed. It is currently showing the TAD view in the A-10's left MFCD. ![](RackMultipart20230912-1-44qmnv_html_9103d219e9735b9e.png)

![image](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/assets/18526232/66d4c94b-18ff-4f59-8308-9503d042a29a)

### Command Line

Both the Iris-Client and the Iris-Server can be (and probably should be) started from the command line, and in this mode, they can take a single argument which is the name of the configuration xml file. If the filename of the configuration file contains spaces, then the configuration filename should be enclosed in double quotes.
It is recommended that the configuration file always resides in a folder which the Iris-Client and/or Iris-Server program has read/write access to, otherwise the Save Configuration button is likely to give an error.
A typical way to run Iris programs from the command line is as follows:
`"%programfiles%\Helios Virtual Cockpit\Iris Screen exporter\iris-server.exe" "%userprofile%\documents\Iris_Screen_Exporter\iris.xml"`
and
`"%programfiles%\Helios Virtual Cockpit\Iris Screen exporter\iris-client.exe" "%userprofile%\documents\Iris_Screen_Exporter\iris.xml"`
Note:  All sets of double quotes are required since there are portions of the command which contains space characters.

### Network Considerations

By default, the viewports are sent at a rate of 10 per second. Depending on the size of your viewports this can result in a large amount of data being sent out on your network. For best results do not use a wireless network unless it has high bandwidth and low latency. If you are worried about network congestion, you might consider using a dedicated network for just Iris traffic or an ethernet crossover cable.

Iris uses multiple UDP ports to transfer the viewport data, however the maximum UDP payload on each network port is 67Kb (assuming optimum network configuration). It is quite possible that you might want to capture and send viewports which would result in greater than 67Kb needing to be sent. If this is the case, then it is recommended that the source image is sent as several viewports to avoid this limitation. It is not possible to calculate the image size of a captured image because it is compressed using JPEG image compression and the size will be dependent on the exact contents of the image.

Firewalls on the computers running the Iris-Server and Iris-Clients will probably need to be configured to allow communication to/from the ports and IP Addresses involved in the communications.

## The Iris–Client

![image](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/assets/18526232/0378d8ae-9098-4c64-ac32-fcaad7a7e11a)


The Iris-Client program is run on the machine you want to send the viewports to. It receives the viewports sent by the Iris-Server via UDP. If you are running a firewall ensure that it is configured to allow the ports you defined in your iris.xml file. The Iris-Client has two main components. The main window and a viewport window for each viewport defined.

The Main Iris-Client window has only one button. It allows you to save the viewport's window locations to iris.xml so you don't have to reposition them each time you start the Iris-Client program.

### Viewport Windows

Each defined viewport will have its own window. The window has two modes. With borders and without borders. When borders are on the window can be dragged just like any other window. This allows for coarse window positioning. When borders are off the window cannot be dragged to be moved. In the example above the window on the left has no borders, while the window on the right does.

#### Viewport Context Menu

![image](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/assets/18526232/bf6b1f0f-313d-4443-a94b-75609573f4dd)

Each viewport window has a context menu that is accessed by right clicking on the window. The menu lists all actions you can take on the window.

**Toggle Border** – toggles between showing and hiding the border of the window.

**Set Window Position** - This sets the current windows position in the running configuration. This does _NOT_save the position to iris.xml. That is performed by the "Save Config" button on the main window.

**Enable Movement** - Selecting this will allow the cursor keys and the movement key shortcuts to alter the position of the viewport window.

The last four window actions allow you to fine tune the window position. This works regardless of if the border is on or off. Each click moves the window 1 pixel in the selected direction. A More efficient way to position the window is to use the traditional WASD keys while holding either Control key.

### Usage Notes
<details>
<summary markdown="span">
Usage Notes 
</summary>

Typically when Iris is being used, the screen areas being captured by the Iris-Server are redundant however the images still need to be rendered to a screen. There are various options available to avoid using physical screen real estate. One is a software display device driver such as [AmyUni's USB driver](https://www.amyuni.com/downloads/usbmmidd_v2.zip). The second is a hardware device which can be plugged into a spare port on your graphics card - just search on "Headless Ghost Display Emulator", and you should come up with some cheap options for both HDMI and Displayport connections. If you have problems configuring with these options because you cannot see the data which the Iris-Server needs to capture, then the Windows **Print Screen** function can be used to see the image which is being displayed on the display emulator.
</details>

## The iris.xml configuration file

Before starting Iris you need to create an "iris.xml" configuration file. An example is included in the install directory. All coordinates are in pixels with (0,0) being the top left corner of the Windows primary display. This is a different coordinate system to the one used by DCS.
<details markdown="1">
<summary markdown="span">List of the XML Elements used in the Iris Configuration</summary>
  
| Element | Description |
|-----------------------------|---------------------------------------------------------------------------------------------------------|
|`<ViewPorts>`| Defines a list of viewports. |
|`  <ViewPort>`| Defines an individual viewport |
|`    <Name>`| Defines a name for this viewport to be known by.  This is shown on the tabs for the viewport in the Iris-Server and the viewport window (if border is enabled)in the Iris-Client.  Do not use special characters unless you are familiar with  escaping these characters for XML |
|`    <Description>`| A description about this viewport.  Do not use special characters unless you are familiar with escaping these characters for XML. |
|`    <Host>`| Defines the hostname of the client that will be rendering the viewports.  Localhost, Hostname, or IP are all valid. |
|`    <Port>`|Defines the port that the individual viewport will listen to.  Make sure you pick an unused port and it is allowed through your firewall. |
|`    <ScreenCaptureX/Y>`| Define the (X,Y) coordinate of the top left corner of the viewport to be captured. |
|`    <SizeX/Y>`| Define the horizontal, vertical size of the viewport to be captured. |
|`    <ScreenPositionX/Y>`| Define the (X,Y) coordinate of the top left corner of the position of the viewport to be rendered on the client.  This can be manually set in the configuration file or be saved at runtime by the client. See the client section for details.  |
|`    <ImageAdjustment>`| (optional) Defines the characteristics of the adjustment to be made to the image	captured for this viewport. |
|`      <Brightness>`| This is a multiplier value applied to all of the brightness of all of the colors (but not the alpha channel). |
|`      <RedBrightness>`| This is a multiplier value applied to the brightness of red. |
|`      <GreenBrightness>`| This is a multiplier value applied to the brightness of green. |
|`      <BlueBrightness>`| This is a multiplier value applied to the brightness of blue. |
|`      <AlphaBrightness>`| This is always 1 |
|`      <Contrast>`| This is a multiplier value applied to the contrast of all colors.. |
|`      <Gamma>`| This is a multiplier value applied to the gamma of the image. |
|`<PollingInterval>`| Defines the frequency that the viewports are captured and sent to the client |
|`<GlobalImageAdjustment>`| (optional) Defines the characteristics of the adjust to be made to viewports which do not have their own adjustments specified |
|`      <Brightness>`| This is a multiplier value applied to all of the brightness of all of the colors (but not the alpha channel). |
|`      <RedBrightness>`| This is a multiplier value applied to the brightness of red. |
|`      <GreenBrightness>`| This is a multiplier value applied to the brightness of green. |
|`      <BlueBrightness>`| This is a multiplier value applied to the brightness of blue. |
|`      <AlphaBrightness>`| This is always 1 |
|`      <Contrast>`| This is a multiplier value applied to the contrast of all colors.. |
|`      <Gamma>`| This is a multiplier value applied to the gamma of the image. |
</details>

### Example Configurations

<details>
<summary>Example 1: Copying a Rectangular Area on a Single Computer</summary>

In this example, both the Iris-Server and the Iris-Client run on the same computer, at the same time, and they run using the same configuration file. A 200x400 rectangle is captured at screen offset 0,0, and displayed at location 200,50 ie beside the captured area, but 50 pixels lower. We do this by defining a single viewport.
This configuration can be found in your program files folder under _"\Helios Virtual Cockpit\Iris Screen Exporter\Example Configurations\iris-Example1.xml"_

``` xml
<?xml version="1.0"?>
<IrisConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ViewPorts>
    <ViewPort>
      <Name>Example 1 Viewport</Name>
      <Host>localhost</Host>
      <Port>12001</Port>
      <ScreenCaptureX>0</ScreenCaptureX>
      <ScreenCaptureY>0</ScreenCaptureY>
      <SizeX>200</SizeX>
      <SizeY>400</SizeY>
      <ScreenPositionX>200</ScreenPositionX>
      <ScreenPositionY>50</ScreenPositionY>
    </ViewPort>
  </ViewPorts>
  <PollingInterval>100</PollingInterval>
</IrisConfig>
```
_**Example 1:** Complete XML for an iris configuration file_

``` xml
      <Name>Example 1 Viewport</Name>
```
_**Example 1a:** The name of the viewport to appear in the Server tab or the Client window title_


``` xml
      <Host>localhost</Host>
      <Port>12001</Port>
```
_**Example 1b:** The network details for where the captured image is to be sent. In this example, we want to send this to the same computer so we use the hostname "localhost" or 127.0.0.1. the host is an IPV4 ip address or hostname. The port must be unique to this viewport and not be in use by anything else on the computer._


``` xml
      <ScreenCaptureX>0</ScreenCaptureX>
      <ScreenCaptureY>0</ScreenCaptureY>
      <SizeX>200</SizeX>
      <SizeY>400</SizeY>
```
_**Example 1c:** These are the number of pixels from the Left (ScreenCaptureX)and Top (ScreenCaptureY) of the Windows display which defines the top left corner of the screen area to be captured. The rectangle is 200 pixels wide and 400 pixels deep._

``` xml
      <SizeX>200</SizeX>
      <SizeY>400</SizeY>
      <ScreenPositionX>200</ScreenPositionX>
      <ScreenPositionY>50</ScreenPositionY>
```
_**Example 1d:** This is where the Iris-Client will display the viewport received from the Iris-Server. The 200x400 rectangular image is displayed with the Top Left hand corner being at 200,50 on the Windows display._

</details>

<details>
<summary>Example 2: Copying Two Rectangular Areas to a Second Computer</summary>

In this example, the Iris-Server runs on computer 1 and the Iris-Client runs on a second computer which is connected to the same IP network. The hostname of the second computer is wibble.local which has the IPV4 address of 192.168.0.100. The configuration XML needs to be on both computers. One 200x400 rectangle is captured by the Iris-Server at screen offset 0,0, and a second rectangular image of the same size is captured at location 200,0. The two images are sent to the second computer which is running the Iris-Client (and the same configuration file) and the images are displayed in reverse order. This is achieved by defining two viewports.

This configuration can be found in your program files folder under _"\Helios Virtual Cockpit\Iris Screen Exporter\Example Configurations\iris-Example2.xml"_

``` xml
<?xml version="1.0"?>
<IrisConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ViewPorts>
    <ViewPort>
      <Name>Viewport 1</Name>
      <Description>
        Example 2 configuration for ViewPort 1
      </Description>      
      <Host>wibble.local</Host>
      <Port>12001</Port>
      <ScreenCaptureX>0</ScreenCaptureX>
      <ScreenCaptureY>0</ScreenCaptureY>
      <SizeX>200</SizeX>
      <SizeY>400</SizeY>
      <ScreenPositionX>200</ScreenPositionX>
      <ScreenPositionY>0</ScreenPositionY>
    </ViewPort>
    <ViewPort>
      <Name>Viewport 2</Name>
      <Description>
        Example 2 configuration for ViewPort 2
      </Description>
      <Host>192.168.0.100</Host>
      <Port>12002</Port>
      <ScreenCaptureX>200</ScreenCaptureX>
      <ScreenCaptureY>0</ScreenCaptureY>
      <SizeX>200</SizeX>
      <SizeY>400</SizeY>
      <ScreenPositionX>0</ScreenPositionX>
      <ScreenPositionY>0</ScreenPositionY>
    </ViewPort>
  </ViewPorts>
  <PollingInterval>100</PollingInterval>
</IrisConfig>
```
_**Example 2:** Complete XML for iris.xml configuration file showing two rectangles being captured on one computer, and being displayed in swapped positions on a second computer._

##### Things to note about Example 2

``` xml
  <ViewPorts>
    <ViewPort>
      <Name>Viewport 1</Name>
…
      <Host>wibble.local</Host>
      <Port>12001</Port>
…
    </ViewPort>
    <ViewPort>
      <Name>Viewport 2</Name>
…
      <Host>192.168.0.100</Host>
      <Port>12002</Port>
…
    </ViewPort>
  </ViewPorts>
…
```
_**Example 2a:** The two viewports have different names, but more importantly, they use different port numbers._


``` xml
  <ViewPorts>
    <ViewPort>
…
      <Host>wibble.local</Host>
      <Port>12001</Port>
…
    </ViewPort>
    <ViewPort>
…
      <Host>192.168.0.100</Host>
      <Port>12002</Port>
…
    </ViewPort>
  </ViewPorts>
…
```
_**Example 2b:** Viewport 1 is sent to the hostname of the second computer and Viewport 2 is sent using the IPV4 address of the same computer. Both are valid._

</details>

<details>
<summary>Example 3: Copying Three Rectangular Areas to a Second & Third Computer and Adjusting the Image Brightness</summary>

In this example, the Iris-Server runs on computer 1 and two other computers are running an Iris-Client instance. All three computers are running the same configuration XML file. Computer 2's hostname is wibble.local, and computer 3's hostname is wobble.local.
The user's intent was originally to send one large viewport (600x600) to computer 2, however the size of the captured data exceeded the maximum size for a UDP network send, so the viewport was subdivided into two portions (each 600x300) to circumvent the restriction.

This configuration can be found in your program files folder under _"\Helios Virtual Cockpit\Iris Screen Exporter\Example Configurations\iris-Example3.xml"_

``` xml
<?xml version="1.0"?>
<IrisConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ViewPorts>
    <ViewPort>
      <Name>Viewport 1a</Name>
      <Description>
        Example 3 configuration.  Viewport 1 Upper portion to circumvent the network size restriction 
      </Description>      
      <Host>wibble.local</Host>
      <Port>12001</Port>
      <ScreenCaptureX>0</ScreenCaptureX>
      <ScreenCaptureY>0</ScreenCaptureY>
      <SizeX>600</SizeX>
      <SizeY>300</SizeY>
      <ScreenPositionX>200</ScreenPositionX>
      <ScreenPositionY>0</ScreenPositionY>
    </ViewPort>
    <ViewPort>
      <Name>Viewport 1b</Name>
      <Description>
        Example 3 configuration.  Viewport 1 Lower portion to circumvent the network size restriction
      </Description>      
      <Host>wibble.local</Host>
      <Port>12002</Port>
      <ScreenCaptureX>0</ScreenCaptureX>
      <ScreenCaptureY>300</ScreenCaptureY>
      <SizeX>600</SizeX>
      <SizeY>300</SizeY>
      <ScreenPositionX>200</ScreenPositionX>
      <ScreenPositionY>300</ScreenPositionY>
    </ViewPort>
    <ViewPort>
      <Name>Viewport 2</Name>
      <Description>
        Example 3 configuration for ViewPort 2
      </Description>
      <Host>wobble.local</Host>
      <Port>12003</Port>
      <ScreenCaptureX>200</ScreenCaptureX>
      <ScreenCaptureY>0</ScreenCaptureY>
      <SizeX>200</SizeX>
      <SizeY>400</SizeY>
      <ScreenPositionX>0</ScreenPositionX>
      <ScreenPositionY>0</ScreenPositionY>
      <ImageAdjustment>
        <Brightness>1.2</Brightness>
        <RedBrightness>1.2</RedBrightness>
        <GreenBrightness>1.2</GreenBrightness>
        <BlueBrightness>1.2</BlueBrightness>
        <AlphaBrightness>1</AlphaBrightness>
        <Gamma>1</Gamma>
        <Contrast>1.1</Contrast>
      </ImageAdjustment>
    </ViewPort>
  </ViewPorts>
  <PollingInterval>100</PollingInterval>
  <GlobalImageAdjustment>
    <Brightness>1</Brightness>
    <RedBrightness>1</RedBrightness>
    <GreenBrightness>1</GreenBrightness>
    <BlueBrightness>1</BlueBrightness>
    <AlphaBrightness>1</AlphaBrightness>
    <Gamma>2.0</Gamma>
    <Contrast>2.0</Contrast>
  </GlobalImageAdjustment>
</IrisConfig>
```
_**Example 3:** Complete XML for iris.xml configuration file showing three rectangles captured on one computer, and displaying two on a second computer and one on a third._

##### Things to note about Example 3

1. Viewport 1a and Viewport 1b do not have individual ImageAdjustments, but there is a GlobalImageAdjustment specified so these captures will be adjusted with a gamma of 2.0 and contrast of 2.0.
2. Viewport 2 does have its own ImageAdjustment, so this image will have Brightness set to 1.2, and contrast set to 1.1.
3. Viewport 1a and Viewport 1b need different port numbers.
4. While all three computers can run the same configuration file, it would be beneficial (and recommended) for computer 2 to only have Viewport 1a and Viewport 1b in the configuration file, and computer 3 to only have the Viewport 2 configurations.

</details>

<details>
<summary>Example 4: Creating a Background for the Viewports</summary>

In this example, there is a single viewport which the Iris-Server captures and an Iris-Client displays, however there are two ViewPorts defined in the XML. The ViewPort named "Background" is only processed by the Iris-Client, and it creates a background single color rectangle of the size and location specified. The background is ordered behind the viewports which are displaying data from the Iris-Server.

This configuration can be found in your program files folder under _"\Helios Virtual Cockpit\Iris Screen Exporter\Example Configurations\iris-Example4.xml"_

``` xml
<?xml version="1.0"?>
<IrisConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ViewPorts>
    <ViewPort>
      <Name>Left MFCD</Name>
…
    </ViewPort>
    <ViewPort>
      <Name>Background</Name>
      <Description>This is the full screen background for the back of the screen</Description>
      <Host>localhost</Host>
      <Port>12016</Port>
      <ScreenCaptureX>0</ScreenCaptureX>
      <ScreenCaptureY>0</ScreenCaptureY>
      <SizeX>1920</SizeX>
      <SizeY>1080</SizeY>
      <ScreenPositionX>0</ScreenPositionX>
      <ScreenPositionY>0</ScreenPositionY>
    </ViewPort>
  </ViewPorts>
  <PollingInterval>100</PollingInterval>
</IrisConfig>
```
_**Example 4:** The Iris-Client will create a single-color background for a 1920x1080 display_
</details>

## Alternative Clients

There has been a number of requests for clients to run on other platforms with a view to having external screens running on devices such as Raspberry Pi.  The only
definite solution this project is aware of is Björn Andersson's [WxPython Client on Github](https://github.com/bjanders/wxpython-iris-client).

Iris is not the only software capable of capturing screens and sending them somewhere else for display.  The commonly used FFMpeg / FFPlay is capable of performing the same task.


## Known Issues

The issues for Iris Screen Exporters can be viewed at [https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/issues?q=is%3Aissue](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/issues?q=is%3Aissue)

1. Flickering on client displays can happen due to Screen Capture failing intermittently because Vsync is not enabled on the Server side machine. [https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/issues/1](https://github.com/HeliosVirtualCockpit/Iris-Screen-Exporter/issues/1)


<details>
<summary>Change Log</summary>

#### 1.6.1

1. Global Image Adjustment option to allow all viewports without specific image adjustments to have their brightness, contrast, and gamma adjusted before it is sent to the Iris-Client
2. ViewPort image Adjustment allows the brightness, contrast, and gamma for a particular viewport to be adjusted before it is sent to the Iris-Client
3. New versioning structure
4. CI workflow action to allow more build consistency
5. Both a 32bit and 64bit installer is available
6. Restored missing Client Viewport movement controls
7. Major rewrite of the documentation
8. New configuration examples added
9. Solution tidy up which was long overdue.

#### 1.0.2022.0507

1. Moved into HeliosVirtualCockpit parent directory
2. Added forms icons
3. Installation back to all users
4. Forms Title text for Server and Client changed to Iris Screen Exporter –
5. Updated PDF instructions with known issues section

#### 1.0.2020.0531

1. Changed build to Any CPU to allow it to be installed on 32 bit systems which might be running clients for a single screen. This means that on 64 bit systems, it could be installed in Program Files(x86) now.
2. Moved the installation out of the "IRIS" sub directory
3. Improved and corrected the error messages for network errors and "Message Too Large" in particular.
4. Installation default is now just for the current user rather than all users.

#### 1.0.2019.0316

1. Background capability added so that a single color window will be opened if the name of the viewport is "Background" (case sensitive).
2. Command line argument can be used to specify the configuration xml file (default remains iris.xml)
3. Several bug fixes.
</details>

[1](#sdfootnote1anc) The name of the xml configuration file can be specified as a command line option when starting the server and client

[2](#sdfootnote2anc) If the Viewport name is "Background" this is actioned only by the client and creates a window which is a single color and then sends it to the back of the viewport stack to act as a background. This can be useful to block out the desktop.

</details>