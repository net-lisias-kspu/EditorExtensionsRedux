/*
	This file is part of Editor Extensions Redux /L Unleashed
		© 2018-2024 LisiasT : https://lisias.net <support@lisias.net>
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
using UnityEngine;

using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;

namespace EditorExtensionsRedux
{
	public abstract class GUIWindow : MonoBehaviour
	{
		//public static SettingsWindow Instance { get; private set; }
		//public bool Visible { get; set; }

		public delegate void WindowDisabledEventHandler();
		public event WindowDisabledEventHandler WindowDisabled;
		protected virtual void OnWindowDisabled() 
		{
			if (WindowDisabled != null)
				WindowDisabled();
		}

		internal string _windowTitle = string.Empty;

		internal Rect _windowRect = new Rect () {
			xMin = Screen.width/2 - 100,
			xMax = Screen.width/2 + 100,
			yMin = Screen.height/2 - 50,
			yMax = Screen.height/2 + 50 //0 height, GUILayout resizes it
		};

		//ctor
		public GUIWindow ()
		{
		}

		internal virtual void Awake ()
		{
			//start disabled
			this.enabled = false;
		}

		internal virtual void Update ()
		{
		}

		internal virtual void OnEnable ()
		{
		}

		internal virtual void CloseWindow(){
			this.enabled = false;
			OnWindowDisabled ();
		}

		internal virtual void OnDisable(){
		}

		internal virtual void OnGUI ()
		{
			if (Event.current.type == EventType.Layout) {
				_windowRect.yMax = _windowRect.yMin;
				_windowRect = GUILayout.Window (this.GetInstanceID (), _windowRect, WindowContent, _windowTitle);
			}
		}

		void OnDestroy ()
		{
		}

		/// <summary>
		/// Initializes the window content and enables it
		/// </summary>
		public void Show ()
		{
			this.enabled = true;
		}

		internal abstract void WindowContent (int windowID);
	}
}

