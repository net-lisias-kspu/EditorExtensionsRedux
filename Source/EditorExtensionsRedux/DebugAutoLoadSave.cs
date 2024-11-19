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
using System;
using UnityEngine;

namespace EditorExtensionsRedux
{
	#if DEBUG
//	[KSPAddon(KSPAddon.Startup.MainMenu, false)]
//	public class Debug_AutoLoadQuicksaveOnStartup: UnityEngine.MonoBehaviour
//	{
//		public static bool first = true;
//		public void Start()
//		{
//			if (first)
//			{
//				first = false;
//				HighLogic.SaveFolder = "dev";
//				var game = GamePersistence.LoadGame("persistent", HighLogic.SaveFolder, true, false);
//
//				if (game != null && game.flightState != null && game.compatible)
//				{
//					HighLogic.LoadScene(GameScenes.SPACECENTER);
//				}
//			}
//		}
//	}
	#endif
}

