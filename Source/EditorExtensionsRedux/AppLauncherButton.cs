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
using UnityEngine;
using KSP.UI.Screens;
using KSPe.IO;

namespace EditorExtensionsRedux
{
	[KSPAddon (KSPAddon.Startup.EditorAny, false)]
	public class AppLauncherButton : MonoBehaviour
	{
		private ApplicationLauncherButton button = null;

		public static AppLauncherButton Instance;

		private const string texPathDefault = "Textures/AppLauncherIcon";
		private const string texPathOn = "Textures/AppLauncherIcon-On";
		private const string texPathOff = "Textures/AppLauncherIcon-Off";

		private void Start ()
		{
			if (button == null) {
				OnGuiAppLauncherReady ();
			}
		}

		private void Awake ()
		{
			if (AppLauncherButton.Instance == null) {
				GameEvents.onGUIApplicationLauncherReady.Add (this.OnGuiAppLauncherReady);
				Instance = this;
			}
		}

		private void OnDestroy ()
		{
			GameEvents.onGUIApplicationLauncherReady.Remove (this.OnGuiAppLauncherReady);
			if (this.button != null) {
				ApplicationLauncher.Instance.RemoveModApplication (this.button);
			}
		}

		private void ButtonState (bool state)
		{
			Log.Debug ("ApplicationLauncher on" + state.ToString ());
			EditorExtensions.Instance.Visible = state;
		}
		
        /// <summary>
        /// Copied from ToolbarController
        /// </summary>
        /// 
        //
        // The following function was initially copied from @JPLRepo's AmpYear mod, which is covered by the GPL, as is this mod
        //
        // This function will attempt to load either a PNG or a JPG from the specified path.  
        // It first checks to see if the actual file is there, if not, it then looks for either a PNG or a JPG
        //
        // easier to specify different cases than to change case to lower.  This will fail on MacOS and Linux
        // if a suffix has mixed case

        static string[] imgSuffixes = new string[] { ".png", ".jpg", ".gif", ".PNG", ".JPG", ".GIF" };

        public static Boolean LoadImageFromFile(ref Texture2D tex, String fileNamePath)
        {
            Boolean blnReturn = false;
            try
            {
                string path = fileNamePath;
                if (!File<EditorExtensions>.Asset.Exists(fileNamePath))
                {
                    // Look for the file with an appended suffix.
                    for (int i = 0; i < imgSuffixes.Length; i++)
                        if (File<EditorExtensions>.Asset.Exists(fileNamePath + imgSuffixes[i]))
                        {
                            path = fileNamePath + imgSuffixes[i];
                            break;
                        }
                }

                //File Exists check
                if (File<EditorExtensions>.Asset.Exists(path))
                {
                    try
                    {
                        tex.LoadImage(File<EditorExtensions>.Asset.ReadAllBytes(path));
                        blnReturn = true;
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Failed to load the texture:" + path);
                        Log.Error(ex.Message);
                    }
                }
                else
                {
                    Log.Error("Cannot find texture to load:" + fileNamePath);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Failed to load (are you missing a file):" + fileNamePath);
                Log.Error(ex.Message);
            }
            return blnReturn;
        }

        Texture2D GetTexture(string path, bool b)
        {
            Texture2D tex = new Texture2D(16, 16, TextureFormat.ARGB32, false);
			if (!LoadImageFromFile(ref tex, path))
				Log.Error("Failed to load tex " + path);
            return tex;
        }
        
/// <summary>
/// End of copy
/// </summary>

        private void OnGuiAppLauncherReady ()
		{
			if (this.button == null) {
				try {
					this.button = ApplicationLauncher.Instance.AddModApplication (
						() => {
							EditorExtensions.Instance.Show ();
						}, 	//RUIToggleButton.onTrue
						() => {
							EditorExtensions.Instance.Hide ();
						},	//RUIToggleButton.onFalse
						() => {
							EditorExtensions.Instance.ShowMenu ();
						}, //RUIToggleButton.OnHover
						() => {
							EditorExtensions.Instance.HideMenu ();
						}, //RUIToggleButton.onHoverOut
						null, //RUIToggleButton.onEnable
						null, //RUIToggleButton.onDisable
						ApplicationLauncher.AppScenes.VAB | ApplicationLauncher.AppScenes.SPH, //visibleInScenes
						GetTexture (texPathDefault, false) //texture
					);
					Log.Debug ("Added ApplicationLauncher button");
				} catch (Exception ex) {
					Log.Error ("Error adding ApplicationLauncher button: " + ex.Message);
				}
			}

		}

		private void Update ()
		{
			if (this.button == null) {
				return;
			}

//			if(this.button.State != RUIToggleButton.ButtonState.TRUE)
//				this.button.SetTexture(GameDatabase.Instance.GetTexture (texPathOn, false));
//			else
//				this.button.SetTexture(GameDatabase.Instance.GetTexture (texPathOff, false));

			try {
				if (EditorLogic.fetch != null) {
//					if (EditorExtensions.Instance.Visible && this.button.State != RUIToggleButton.ButtonState.TRUE) {
					if (EditorExtensions.Instance.Visible && !this.button.enabled) {
						this.button.SetTrue ();
						//this.button.SetTexture(GameDatabase.Instance.GetTexture (texPathOn, false));
//					} else if (!EditorExtensions.Instance.Visible && this.button.State != RUIToggleButton.ButtonState.FALSE) {
					} else if (!EditorExtensions.Instance.Visible && this.button.enabled) {
						this.button.SetFalse ();
						//this.button.SetTexture(GameDatabase.Instance.GetTexture (texPathOff, false));
					}
//				} else if (this.button.State != RUIToggleButton.ButtonState.DISABLED) {
				} else if (this.button.enabled) {
					this.button.Disable ();
				}
			} catch (Exception ex) {
				Log.Error ("Error updating ApplicationLauncher button: " + ex.Message);
			}
		}
	}
}