# Editor Extensions Redux /L Unleashed :: Change Log

* 2024-1119: 3.4.5.1 (lisias) for KSP >= 1.4
	+ Using KSPe UI facilities
	+ Fixes a MM handling mistake
	+ Merging fixes from upstream:
		- 3.4.5
			- Finally found the real problem for the Symmetry and AngleSnap keys get set to null, thanks to @NathenKell for pointing
			- out what was happening.  See full description in EditorExtensionsRedux.cs, line 513
			- Moved the code to set and reset the key values into methods to eliminate duplicated code and avoid errors
		- 3.4.4.1
			- Added code to check for key values for toggleSymMode and toggleAngleSnap being null upon entry, if they are, then it resets to the default (X & C) and saves the settings
		- 3.4.4
			- Moved initiation of cached values for the toggles from being initted at class instantiation to in the Start
		- 3.4.3.6
			- Thanks to forum user @ozraven for this:
				- Fixed a null ref which occurred when clicking in a debug window
* 2021-1211: 3.4.4.1 (lisias) for KSP >= 1.4
	+ Fixing a mishap on the settings persistence.
* 2021-1101: 3.4.4.0 (lisias) for KSP >= 1.4
	+ Updates KSPe to v2.4 (including toolbar!)
	+ Small adjustments on the UI.
	+ Merging fixes from upstream
		- Added code from Rememberer mod at mod author @Krazy1 request, remembers the last sort setting for the Editor part list.
		- Fixed fine adjust to dynamically get gizmo offsets. This fixes the broken FineAdjust in 1.11 and is compatible with 1.10.
		- Added default config files for the angle snaps.
		- Added new button to select the stock angle snap defaults
		- Added entry to pop-up menu to reset the mode & snap keys
		- Added new feature activated by default letter B: Centers the vessel horizontally in the editor, and lowers it to 5m high
* 2019-0126: 3.3.19.12 (lisias) for KSP >= 1.4
	+ Merging fixes from upstream
		- Fixed issue when detaching a moving part in the editor (while it's snapping)
* 2019-0126: 3.3.19.11 (lisias) for KSP 1.4
	+ **ditched**
* 2018-1023: 3.3.19.10 (lisias) for KSP 1.4
	+ Merging fixes from upstream
		- fix flickering
	+ Adding KSPe hard dependency
		- Using logging facilities
		- Using sandboxed File.IO facilities
* 2018-0808: 3.3.19.6 (lisias) for KSP 1.4.x
	+ Moving configurations/settings files to <KSP_ROOT>/PluginData 
* 2018-0807: 3.3.19.5 (linuxgurugamer) for KSP 1.4.4
	+ Added button to Settings page 2 to "Reset Symmetry Mode & Angle Snap keys"
* 2018-0329: 3.3.19.3 (linuxgurugamer) for KSP 1.4.1
	+ Added code to dynamically assign Reflection offsets.  Hopefully this will eliminate the need to do manual changes in the future
* 2018-0320: 3.3.19.2 (linuxgurugamer) for KSP 1.4.1
	+ Fixed fuzzy buttons
* 2018-0318: 3.3.19.1 (linuxgurugamer) for KSP 1.4.1
	+ Fixed issue when displaying autostruts, most got reset to Heaviest
* 2018-0316: 3.3.19 (linuxgurugamer) for KSP 1.4.1
	+ Updated obsolete Linerenderer calls
* 2018-0316: 3.3.18 (linuxgurugamer) for KSP 1.4.1
	+ Changed resize of settings window from just before ClickThroughBlocker.GUILayoutWindow to after to toolbar, to avoid confusing the ClickThroughBlocker
* 2018-0315: 3.3.17 (linuxgurugamer) for KSP 1.4.1
	+ Updated for 1.4.1
* 2017-1024: 3.3.16 (linuxgurugamer) for KSP 1.3.1
	+ Removed compound part check, was not working
* 2017-1021: 3.3.15 (linuxgurugamer) for KSP 1.3.1
	+ Added check for compound part in NoOffsetLimits, will not work on compound parts
* 2017-1008: 3.3.14 (linuxgurugamer) for KSP 1.3.1
	+ Updated for KSP 1.3.1
* 2017-0603: 3.3.13.1 (linuxgurugamer) for KSP 1.3.0
	+ Updated .version file
* 2017-0526: 3.3.13 (linuxgurugamer) for KSP 1.2.2
	+ Updated for 1.3
* 2017-0402: 3.3.12 (linuxgurugamer) for KSP 1.2.2
	+ Fixed issue where changing the Reroot setting in the settings window wasn't toggling the internal reroot flag
* 2016-1218: 3.3.11.1 (linuxgurugamer) for KSP 1.2.2
	+ Just a rebuild for 1.2.2
* 2016-1211: 3.3.11 (linuxgurugamer) for KSP 1.2.2
	+ Fixed positioning of menu in editor
* 2016-1207: 3.3.10.1 (linuxgurugamer) for KSP 1.2.2
	+ Updated for 1.2.2
* 2016-1116: 3.3.10 (linuxgurugamer) for KSP 1.2.1
	+ Fixed null ref when F is pressed and no part is selected
* 2016-1109: 3.3.9 (linuxgurugamer) for KSP 1.2.1
	+ Fixed (the right way) the no offset limit local/absolute
* 2016-1107: 3.3.8 (linuxgurugamer) for KSP 1.2.1
	+ Fixed issue where NoOffsetLimits was not working upon entry into editor
* 2016-1106: 3.3.7 (linuxgurugamer) for KSP 1.2.1
	+ Added code to toggle no offset limit to settings window
* 2016-1102: 3.3.6 (linuxgurugamer) for KSP 1.2.1
	+ Fixed  menu Show Tweakables, for when Advanced tweakables is enabled, to show at the right height
* 2016-1102: 3.3.5.1 (linuxgurugamer) for KSP 1.2
	+ Fixed version file
* 2016-1102: 3.3.5 (linuxgurugamer) for KSP 1.2
	+ Added AnglesnapModIsToggle, if enabled, hitting the Mod-C (for Windows,ALT-C) will switch between 1 and the last setting
* 2016-1101: 3.3.4 (linuxgurugamer) for KSP 1.2
	+ Changed "No Show Autostruts" to "Hide Autostruts" text on buttons
* 2016-1015: 3.3.3 (linuxgurugamer) for KSP 1.2
	+ Added Autostrut and Rigidity buttons, thanks @Boop:
* 2016-1014: 3.3.2 (linuxgurugamer) for KSP 1.2
	+ 1.2 Boop release
* 2016-1010: 3.3.1 (linuxgurugamer) for KSP 1.1.3 PRE-RELEASE
	+ Fixed bug with no offset limit preventing swap between local and absolute coordinates
* 2016-1009: 3.3.0 (linuxgurugamer) for KSP 1.1.3 PRE-RELEASE
	+ Added ability to disable internal reroot, so that you can use the stock reroot to reroot shadow part assemblies
* 2016-1009: 3.2.19 (linuxgurugamer) for KSP 1.1.3 PRE-RELEASE
	+ No changelog provided
* 2016-1004: 3.2.18 (linuxgurugamer) for KSP 1.1.3 PRE-RELEASE
	+ No changelog provided
* 2016-1001: 3.2.17 (linuxgurugamer) for KSP 1.1.3 PRE-RELEASE
	+ No changelog provided
* 2016-0927: 3.2.16 (linuxgurugamer) for KSP 1.1.3 PRE-RELEASE
	+ updated for build 1540
* 2016-0919: 3.2.15.1 (linuxgurugamer) for KSP 1.1.3 PRE-RELEASE
	+ No changelog provided
* 2016-0915: 3.2.15 (linuxgurugamer) for KSP 1.1.3 PRE-RELEASE
	+ No changelog provided
* 2016-0622: 3.2.14 (linuxgurugamer) for KSP 1.1.3
	+ Updated values for KSP 1.1.3
* 2016-0519: 3.2.13 (linuxgurugamer) for KSP 1.1.2
	+ Fixed Fine Adjustments window (inability to close it or change the values)
* 2016-0519: 3.2.12 (linuxgurugamer) for KSP 1.1.2
	+ Fixed rotation gizmo to not angle snap when anglesnap is off
* 2016-0518: 3.2.11 (linuxgurugamer) for KSP 1.1.2
	+ Added 1/4 second delay in closing menu
* 2016-0515: 3.2.10 (linuxgurugamer) for KSP 1.1.2
	+ Added UI scaling code to position of EEX menu
* 2016-0515: 3.2.9 (linuxgurugamer) for KSP 1.1.2
	+ Removed old code from the FineAdjust Update function which was causing an exception
* 2016-0513: 3.2.8 (linuxgurugamer) for KSP 1.1.2
	+ Added code from Fwiffo to fix bug where changing the angle snap while in rotate mode would not affect the rotate gizmo
* 2016-0504: 3.2.7 (linuxgurugamer) for KSP 1.1.2
	+ Added code so that typing in text fields will be ignored
* 2016-0501: 3.2.6 (linuxgurugamer) for KSP 1.1.2
	+ Added 1.1.2 compatability
* 2016-0430: 3.2.5 (linuxgurugamer) for KSP 1.1.2
	+ Changes in 3.2.5
* 2016-0430: 3.2.4 (linuxgurugamer) for KSP 1.1.1
	+ Fixed null refs and excepts in 1.1.1
* 0000-0000: 3.2.3 (linuxgurugamer) for KSP 1.1
	+ Updated for 1.1.1
* 2016-0426: 3.2.2 (linuxgurugamer) for KSP 1.1
	+ Code changes to allow to work on Linux and OSX
* 2016-0420: 3.2.1.9 (linuxgurugamer) for KSP 1.1
	+ rebuild
* 0000-0000: 3.2.1.8 (linuxgurugamer) for KSP 1.1
	+ Updated for 1.1
* 0000-0000: 3.0.2 (linuxgurugamer) for KSP 1.0.5
	+ No changelog provided
* 2015-0624: 2.12 (MachXXV) for KSP 1.0.3
	+ Changes in v2.12 - 23 June 2015
* 2015-0623: 2.11 (MachXXV) for KSP 1.0.3
	+ 22 Jun 2015
* 2015-0623: 2.9 (MachXXV) for KSP 1.0.3
	+ Changes in v2.9 - 22 Jun 2015
* 2015-0522: 2.8 (MachXXV) for KSP 1.0.2
	+ 21 May 2015
* 2015-0503: 2.7 (MachXXV) for KSP 1.0.2
	+ Editor Extensions v2.7
* 2015-0428: 2.6 (MachXXV) for KSP 1.0
	+ Editor Extensions v2.6
* 2014-1227: 2.5 (MachXXV) for KSP 0.90 Beta
	+ Editor Extensions v2.5
* 2014-1225: 2.4 (MachXXV) for KSP 0.90 Beta
	+ Editor Extensions v2.4
* 2014-1225: 2.3 (MachXXV) for KSP 0.90 Beta
	+ Editor Extensions v2.3
* 2014-1223: 2.2 (MachXXV) for KSP 0.90 Beta
	+ Changes in v2.2
* 2014-1221: 2.0 (MachXXV) for KSP 0.90 Beta
	+ Editor Extensions v2.0
* 2014-1221: 1.4 (MachXXV) for KSP 0.25
	+ No changelog provided
