# Editor Extensions Redux Unofficial

Extensions for the KSP Editor. Unofficial fork by Lisias.


## In a Hurry

* [Releases](https://github.com/net-lisias-kspu/EditorExtensionsRedux/tree/Archive)
* [Source](https://github.com/net-lisias-kspu/EditorExtensionsRedux)
* [Latest Release](https://github.com/net-lisias-kspu/EditorExtensionsRedux/releases)
* [Change Log](./CHANGE_LOG.md)
 

## Description

* Features
	+ Allows custom levels of radial symmetry beyond the stock limitations.
	+ Horizontally and vertically center parts.
	+ Adds radial/angle snapping at 1,5,15,22.5,30,45,60, and 90 degrees. Angles are customizable.
	+ Toggle part clipping (From the cheat options)
	+ Re-Align placed struts and fuel lines between parts 
	+ Toggle radial and node attachment of parts
	+ Reset hangar camera view
	+ Customize hotkeys
	+ KSP-AVC versioning support
* Vertical/Horizontal snap
	+ Place the part, then once the part is placed, hover over the 	+ part with your mouse and press the Vertical or Horizontal snap hotkey.
	+ For vertical snap, part will center itself on the part lengthwise in the SPH
* Strut & Fuel line alignment
	+ Place the strut, then hover over the base/start of the strut (the first end placed) with the mouse, and press the hotkey.
	+ Strut/FL start and end with be snapped to the closest of either the middle, quarter, or end of the part, aligned directly between the two parts.
	+ **Mod/Alt-U** will reposition the strut/FL directly between the parts, but only level out the strut from the start/parent part.
* Default Keybindings
	+ **V** - Vertically center a part. Place the part, hover over it with the mouse, and press the hotkey.
	+ **H** - Horizontally center the part. Place the part, hover over it with the mouse, and press the hotkey.
	+ **U** - Place the strut, then hover over the base/start of the strut (the first end placed) with the mouse, and press the hotkey.
	+ **X, Shift+X** - Increase/Decrease symmetry level (Based on KSP's key map)
	+ **Alt+X** - Reset symmetry level (Based on KSP's key map)
	+ **C, Shift+C** - Increase/Decrease angle snap (Based on KSP's key map)
	+ **Alt+C** - Reset angle snap (Based on KSP's key map)
	+ **T** - Attachment mode: Toggle between surface and node attachment modes for all parts, and when a part is selected, will toggle surface attachment even when that part's config usually does not allow it.
	+ **Alt+Z** - Toggle part clipping (CAUTION: This is a cheat option)
Space- When no part is selected, resets camera pitch and heading (straight ahead and level)

### Instalation

In your KSP GameData folder, delete any existing EditorExtensions folder. Download the zip file to your KSP GameData folder and unzip.﻿

### Dependencies

* [Click Through Blocker](https://forum.kerbalspaceprogram.com/index.php?/topic/170747-141-click-through-blocker/)

### License:

Released under MIT license.


## UPSTREAM

* [linuxgurugamer](https://forum.kerbalspaceprogram.com/index.php?/profile/129964-linuxgurugamer/) CURRENT MAINTAINER
	+ [Forum](https://forum.kerbalspaceprogram.com/index.php?/topic/162790-141-hangar-extender-extended/)
	+ [SpaceDock](https://spacedock.info/mod/1428/HangerExtender)
	+ [GitHub](https://github.com/linuxgurugamer/FShangarExtender)
* [Alewx](https://forum.kerbalspaceprogram.com/index.php?/profile/102791-alewx/) M.I.A.
	+ [GitHub](https://github.com/Omegano/FMRS)
* [Snjo](https://github.com/Alewx/FShangarExtender) ROOT
	+ [Forum](https://forum.kerbalspaceprogram.com/index.php?/topic/59703-10-hangar-extender-v33/&)
	+ [GitHub](https://github.com/snjo/FShangarExtender/releases/latest)
