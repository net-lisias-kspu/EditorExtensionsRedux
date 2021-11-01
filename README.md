# Editor Extensions Redux /L Unleashed

Extensions for the KSP Editor.

[Unleashed](https://ksp.lisias.net/add-ons-unleashed/) fork by Lisias.


## In a Hurry

* [Latest Release](https://github.com/net-lisias-kspu/EditorExtensionsRedux/releases)
	+ [Binaries](https://github.com/net-lisias-kspu/EditorExtensionsRedux/tree/Archive)
* [Source](https://github.com/net-lisias-kspu/EditorExtensionsRedux)
* Documentation
	+ [Project's README](https://github.com/net-lisias-kspu/EditorExtensionsRedux/blob/master/README.md)
	+ [Install Instructions](https://github.com/net-lisias-kspu/EditorExtensionsRedux/blob/master/INSTALL.md)
	+ [Change Log](./CHANGE_LOG.md)
	+ [TODO](./TODO.md) list


## Description

* Features
	+ Allows custom levels of radial symmetry beyond the stock limitations.
	+ Horizontally and vertically center parts.
	+ Adds radial/angle snapping at 1, 5, 15, 22.5, 30, 45, 60, and 90 degrees. Angles are customizable.
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


## Installation

Detailed installation instructions are now on its own file (see the [In a Hurry](#in-a-hurry) section) and on the distribution fi

### License:

This work is DOUBLE LICENSED under the [Unlicense](http://unlicense.org) and [SKL-1.0](https://ksp.lisias.net/SKL-1_0.txt), at your choice when applicable. See [here](./LICENSE).

* Under [Unlicense](http://unlicense.org) (see [here](./LICENSE.UN)):
	+ You are free to:
		- Do whatever you want
	+ Under the following terms:
		- No conditions added. 
* Under [SKL 1.0](https://ksp.lisias.net/SKL-1_0.txt) (see [here](./LICENSE.SKL-1_0):
	+ You are free to:
		- Use : unpack and use the material in any computer or device
		- Redistribute: redistribute the original package in any medium
	+ Under the following terms:
		- You agree to use the material only on (or to) KSP
		- You don't alter the package in any form or way (but you can embedded it)
		- You don't change the material in any way, and retain any copyright notices
		- You must explicitly state the author's Copyright, as well an Official Site for downloading the original and new versions (see above) 

Releases previous to 3.4.4.0  are still available under the MIT license and are available [here](https://github.com/net-lisias-kspu/EditorExtensionsRedux/tree/Source/MIT) and on the in upstream's repositories. Please note this [statement](https://www.gnu.org/licenses/license-list.en.html#Expat) from FSF.

Please note the copyrights and trademarks in [NOTICE](./NOTICE)


## UPSTREAM

* [MachXXV](https://github.com/MachXXV/EditorExtensions) ROOT
	+ [Forum](https://forum.kerbalspaceprogram.com/index.php?/topic/35703-103-editor-extensions-v212-23-june/&tab=comments#comment-489514)
	+ [GitHub](https://github.com/MachXXV/EditorExtensions)
* [linuxgurugamer](https://forum.kerbalspaceprogram.com/index.php?/profile/129964-linuxgurugamer/) CURRENT MAINTAINER
	+ [Forum](https://forum.kerbalspaceprogram.com/index.php?/topic/127378-151-editor-extensions-redux-released-with-selectroot-merge-stripsymmetry-nooffsetlimits/)
	+ [SpaceDock](https://spacedock.info/mod/48/Editor%20Extensions%20Redux)
	+ [GitHub](https://github.com/linuxgurugamer/EditorExtensionsRedux)
