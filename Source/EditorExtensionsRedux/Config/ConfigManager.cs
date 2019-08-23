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
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;
using SIO = System.IO;
using File = KSPe.IO.File<EditorExtensionsRedux.EditorExtensions>;
using Data = KSPe.IO.Data<EditorExtensionsRedux.EditorExtensions>;

namespace EditorExtensionsRedux
{
	public static class ConfigManager
	{
		public static bool FileExists (string filePath)
		{
			try {
				return File.Data.Exists(filePath);
			} catch (Exception ex) {
				Log.error("Failed to verify file {0} Error: {1}", filePath, ex.Message);
				return false;
			}
		}

		public static bool SaveConfig (ConfigData configData, string fn)
		{
			try {
				XmlSerializer serializer = new XmlSerializer (typeof(ConfigData));
				using (SIO.TextWriter writer = Data.StreamWriter.CreateFor(fn)) {
					serializer.Serialize (writer, configData); 
				}
				Log.trace("Saved config file");
				return true;
			} catch (Exception ex) {
				Log.error("Error saving config file: {0}", ex.Message);
				return false;
			}
		}

		public static ConfigData LoadConfig (string fn)
		{
			try
			{
				XmlSerializer deserializer = new XmlSerializer (typeof(ConfigData));

				ConfigData data;
				using (SIO.TextReader reader = Data.StreamReader.CreateFor(fn)) {
					object obj = deserializer.Deserialize (reader);
					data = (ConfigData)obj;
				}

				//need to verify that there are no missing fields

				return data;
			} catch (Exception ex) {
				Log.error("Error loading config file: {0}", ex.Message);
				return null;
			}
		}

		static List<float> LoadDefaults(string nodeName)
		{
			List<float> snapValues = new List<float>();
			if (!Data.ConfigNode.For(nodeName).IsLoadable)
				return new List<float> { 0.0f, 1.0f, 5.0f, 15.0f, 22.5f, 30.0f, 45.0f, 60.0f, 90.0f };
			ConfigNode fileNode = Data.ConfigNode.For(nodeName).Load().Node;
			ConfigNode dataNode = fileNode.GetNode("EEX");

			List<string> values = dataNode.GetValuesList("SnapValue");
			foreach (var v in values) try
			{
				float f = float.Parse(v);
				snapValues.Add(f);
			}
			catch (System.Exception e)
			{
				Log.error("LoadDefaults {0} E:{1}", nodeName, e.Message);
			}
			return snapValues;
		}

		/// <summary>
		/// Creates a new config file with defaults
		/// will replace any existing file
		/// </summary>
		/// <returns>New config object with default settings</returns>
		public static ConfigData CreateDefaultConfig (string fn, string snapConfig, string version)
		{
			try
			{
                ConfigData defaultConfig = new ConfigData() {
                    AngleSnapValues = LoadDefaults(snapConfig),
                    MaxSymmetry = 20,
                    // Rapidzoom by Fwiffo 
                    RapidZoom = true,
                    //ZoomCycling = true,
                    //ZoomCycleDistances = new List<float> { 0f, 1f, 5f, 30f, 100f, 500f, 10000f, 100000f, 150000f }, // RKTODO: Set good defaults
                    FileVersion = version,
                    OnScreenMessageTime = 1.5f,
                    ShowDebugInfo = true,
                    ReRootEnabled = true,
                    NoOffsetLimitEnabled = true,
                    FineAdjustEnabled = true,
                    AnglesnapModIsToggle = true,
                    CycleSymmetryModeModIsToggle = true
				};

                KeyMaps defaultKeys = new KeyMaps() {
                    AttachmentMode = KeyCode.T,
                    PartClipping = KeyCode.Z,
                    ResetCamera = KeyCode.Space,
                    ZoomSelected = KeyCode.KeypadPeriod,
                    VerticalSnap = KeyCode.V,
                    HorizontalSnap = KeyCode.H,
                    HorizontalCenter = KeyCode.B,
                    CompoundPartAlign = KeyCode.U,
                    ToggleReRoot = KeyCode.K,
                    ToggleNoOffsetLimit = KeyCode.L,
                    StartMasterSnap = KeyCode.LeftControl,

                    Up = KeyCode.UpArrow,
					Down = KeyCode.DownArrow,
					Left = KeyCode.LeftArrow,
					Right = KeyCode.RightArrow,
					Forward = KeyCode.RightShift,
					Back = KeyCode.RightControl
						
				};
				defaultConfig.KeyMap = defaultKeys;

				if (ConfigManager.SaveConfig (defaultConfig, fn))
					Log.detail("Created default config");
				else
					Log.error("Failed to save default config");

				return defaultConfig;
			} catch (Exception ex) {
				Log.error("Error defaulting config: {0}", ex.Message);
				return null;
			}
		}
	}
}

