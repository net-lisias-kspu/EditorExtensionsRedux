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
using System.Collections.Generic;

using UnityEngine;
using KSP.UI.Screens;

using KSPe.Annotations;
using Toolbar = KSPe.UI.Toolbar;
using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;
using Asset = KSPe.IO.Asset<EditorExtensionsRedux.ToolbarButton>;

namespace EditorExtensionsRedux
{
	[KSPAddon(KSPAddon.Startup.MainMenu, true)]
	public class ToolbarController : MonoBehaviour
	{
		internal static KSPe.UI.Toolbar.Toolbar Instance => KSPe.UI.Toolbar.Controller.Instance.Get<ToolbarController>();

		[UsedImplicitly]
		private void Start()
		{
			KSPe.UI.Toolbar.Controller.Instance.Register<ToolbarController>(Version.FriendlyName);
		}
	}

	[KSPAddon (KSPAddon.Startup.EditorAny, false)]
	public class ToolbarButton : MonoBehaviour
    {
		internal static ToolbarButton Instance = null;
		internal Toolbar.Button button = null;

		[UsedImplicitly]
		private void Awake ()
		{
			Instance = this;
		}


		private static Texture2D AppLauncherIcon;
		private static Texture2D AppLauncherIconOn;
		private static Texture2D AppLauncherIconOff;
		private static Texture2D AppLauncherIconBright;

		[UsedImplicitly]
		private void Start ()
		{
			if (null == button) try {
				if (null == AppLauncherIcon)		AppLauncherIcon		 = Asset.Texture2D.LoadFromFile("Textures", "AppLauncherIcon");
				if (null == AppLauncherIconOn)		AppLauncherIconOn	 = Asset.Texture2D.LoadFromFile("Textures", "AppLauncherIcon-On");
				if (null == AppLauncherIconOff)		AppLauncherIconOff	 = Asset.Texture2D.LoadFromFile("Textures", "AppLauncherIcon-Off");
				if (null == AppLauncherIconBright)	AppLauncherIconBright= Asset.Texture2D.LoadFromFile("Textures", "AppLauncherIcon-Bright");

				this.button = Toolbar.Button.Create(this
						, ApplicationLauncher.AppScenes.VAB | ApplicationLauncher.AppScenes.SPH
						, AppLauncherIcon, AppLauncherIcon
						, Version.FriendlyName
					);
				this.button.Add(
						Toolbar.Button.ToolbarEvents.Kind.Active
						, Toolbar.State.Data.Create(AppLauncherIconOn, AppLauncherIconOn)
						, Toolbar.State.Data.Create(AppLauncherIcon, AppLauncherIcon)
					);
				this.button.Add(
						Toolbar.Button.ToolbarEvents.Kind.Enabled
						, Toolbar.State.Data.Create(AppLauncherIcon, AppLauncherIcon)
						, Toolbar.State.Data.Create(AppLauncherIconOff, AppLauncherIconOff)
					);
				this.button.Add( // Okey, I'm showing off now. :)
						Toolbar.Button.ToolbarEvents.Kind.Hover
						, Toolbar.State.Data.Create(AppLauncherIconBright, AppLauncherIconBright)
						, Toolbar.State.Data.Create(AppLauncherIcon, AppLauncherIcon)
					);

			// ATTENTION! Probable race condition: what happens if this MonoBehaviour is intantiated prior to EditorExtensions?
				this.button.Toolbar.Add(
						Toolbar.Button.ToolbarEvents.Kind.Active
						, new Toolbar.Button.Event(EditorExtensions.Instance.ShowMenu, EditorExtensions.Instance.HideMenu)
					);
				// I have activating the menu on hovering!!!
				//this.button.Toolbar.Add(
				//		Toolbar.Button.ToolbarEvents.Kind.Hover
				//		, new Toolbar.Button.Event(EditorExtensions.Instance.ShowMenu, EditorExtensions.Instance.HideMenu)
				//	);
			// /ATTENTION

				ToolbarController.Instance.Add(this.button);
				Log.dbg("Added Toolbar.Button");
			} catch (System.Exception ex) {
				Log.error("Error adding Toolbar.Button: {0}", ex.Message);
			}
		}

		[UsedImplicitly]
		private void OnDestroy ()
		{
			ToolbarController.Instance.Destroy();
			this.button = null;
		}

    }

}
