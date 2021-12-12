# Editor Extensions Redux /L Unleashed :: Change Log

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
* 2018-1023: 3.3.19.10 (lisias) for KSP 1.4
	+ Merging fixes from upstream
		- fix flickering
	+ Adding KSPe hard dependency
		- Using logging facilities
		- Using sandboxed File.IO facilities
* 2018-0808: 3.3.19.6 (lisias) for KSP 1.4.x
	+ Moving configurations/settings files to <KSP_ROOT>/PluginData
