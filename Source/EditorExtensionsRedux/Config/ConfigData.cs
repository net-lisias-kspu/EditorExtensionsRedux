/*
	This file is part of Editor Extensions Redux /L Unleashed
		© 2018-2021 LisiasT : http://lisias.net <support@lisias.net>
		© 2016-2018 LinuxGyruGamer
		© 2013-2016 MachXXV

	Editor Extensions Redux /L is double licensed, as follows:
		* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	Editor Extensions Redux /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with Editor Extensions Redux /L Unleashed.
	If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with Editor Extensions Redux /L Unleashed.
	If not, see <https://www.gnu.org/licenses/>.

*/
using System.Xml.Serialization;
using UnityEngine;
using System.Collections.Generic;

namespace EditorExtensionsRedux
{
	[XmlRoot ("ConfigData")]
	public class ConfigData
	{
		[XmlElement ("FileVersion")]
		public string FileVersion { get; set; }

		[XmlElement ("KeyMap")]
		public KeyMaps KeyMap { get; set; }

		[XmlArray ("AngleSnapValues")]
		public List<float> AngleSnapValues { get; set; }

		[XmlElement ("MaxSymmetry")]
		public int MaxSymmetry { get; set; }

		// Fwiffo start
		[XmlElement ("RapidZoom")]
		public bool RapidZoom { get; set; }

        //[XmlElement("ZoomCycling")]
        //public bool ZoomCycling { get; set; }

        //[XmlArray("ZoomCycleDistances")]
        //public List<float> ZoomCycleDistances { get; set; }

        // Fwiffo end

        [XmlElement("ReRootEnabled")]
        public bool ReRootEnabled { get; set; }

        [XmlElement("NoOffsetLimitEnabled")]
        public bool NoOffsetLimitEnabled { get; set; }

        [XmlElement("FineAdjustEnabled")]
        public bool FineAdjustEnabled { get; set; }

        [XmlElement ("ShowDebugInfo")]
		public bool ShowDebugInfo { get; set; }

		/// <summary>
		/// Time, in seconds, that the on screen messages will display
		/// </summary>
		[XmlElement ("OnScreenMessageTime")]
		public float OnScreenMessageTime { get; set; }

        [XmlElement("AnglesnapModIsToggle")]
        public bool AnglesnapModIsToggle = false;

        [XmlElement("CycleSymmetryModeModIsToggle")]
        public bool CycleSymmetryModeModIsToggle = false;

        public ConfigData ()
		{
			this.KeyMap = new KeyMaps ();
		}
	}

	public class KeyMaps
	{
		[XmlElement ("ResetCamera")]
		public KeyCode ResetCamera { get; set; }

		[XmlElement ("ZoomSelected")]
		public KeyCode ZoomSelected { get; set; }

		[XmlElement ("AttachmentMode")]
		public KeyCode AttachmentMode { get; set; }

		[XmlElement ("PartClipping")]
		public KeyCode PartClipping { get; set; }

		[XmlElement ("VerticalSnap")]
		public KeyCode VerticalSnap { get; set; }

        [XmlElement("HorizontalSnap")]
        public KeyCode HorizontalSnap { get; set; }

        [XmlElement("ToggleReRoot")]
        public KeyCode ToggleReRoot { get; set; }

        [XmlElement("ToggleNoOffsetLimit")]
        public KeyCode ToggleNoOffsetLimit { get; set; }

        [XmlElement("StartMasterSnap")]
        public KeyCode StartMasterSnap { get; set; }


        [XmlElement ("CompoundPartAlign")]
		public KeyCode CompoundPartAlign { get; set; }


		[XmlElement ("Up")]
		public KeyCode Up { get; set; }
		[XmlElement ("Down")]
		public KeyCode Down { get; set; }
		[XmlElement ("Left")]
		public KeyCode Left { get; set; }
		[XmlElement ("Right")]
		public KeyCode Right { get; set; }
		[XmlElement ("Forward")]
		public KeyCode Forward { get; set; }
		[XmlElement ("Back")]
		public KeyCode Back { get; set; }


	}
}

