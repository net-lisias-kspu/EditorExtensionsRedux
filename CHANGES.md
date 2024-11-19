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
