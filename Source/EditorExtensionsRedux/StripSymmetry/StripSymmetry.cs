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

namespace EditorExtensionsRedux.StripSymmetry
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class StripSymmetry : MonoBehaviour
    {
        private readonly OSD _osd = new OSD();
		bool stripIsActive = false;
 //       private readonly Hotkey _hotkey = new Hotkey("triggerWith", "LeftAlt+LeftShift+Mouse0");
	//	private KeyCode triggerWith = KeyCode.LeftShift | KeyCode.LeftAlt | KeyCode.LeftControl | KeyCode.Mouse0;

        public void Awake()
        {
            //b_hotkey.Load();
        }

        public void OnGUI()
        {
            var editor = EditorLogic.fetch;
            if (editor == null)
                return;
            if (editor.editorScreen != EditorScreen.Parts)
                return;

            _osd.Update();
        }

        public void Update()
        {
            var editor = EditorLogic.fetch;
            if (editor == null)
                return;
            if (editor.editorScreen != EditorScreen.Parts)
                return;
			
			if (!Input.GetKey (KeyCode.Mouse0) || !Input.GetKey(KeyCode.LeftShift) || !Input.GetKey(KeyCode.LeftAlt) ) {
				stripIsActive = false;
				return;
			}
			Log.trace("Trying to strip symmetry  stripIsActive: {0}", stripIsActive);
//            if (!_hotkey.IsTriggered)
  //              return;

            var p = GetPartUnderCursor(editor.ship);
            if (p == null)
                return;

            print(String.Format("({0}).symMethod = {1}", p.partInfo.title, p.symMethod));
            print(String.Format("({0}).symmetryCounterparts.Count = {1}", p.partInfo.title, p.symmetryCounterparts.Count));
            if (p.symmetryCounterparts.Count == 0 && !stripIsActive)
            {
                _osd.Error("Part has no symmetry: " + p.partInfo.title);
				stripIsActive = true;
                return;
            }
			if (!stripIsActive) {
				_osd.Info ("Removing symmetry...");
				stripIsActive = true;
				RemoveSymmetry (p);
			}
        }

        private static Part GetPartUnderCursor(IShipconstruct ship)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                return ship.Parts.Find(p => p.gameObject == hit.transform.gameObject);
            }
            return null;
        }

        private static void RemoveSymmetry(Part symmPart)
        {
            // remove the symmetry of parts that have counterparts outside this branch but leave symmetry for groups wholly within this branch.
            foreach (var child in symmPart.children)
            {
                foreach (var otherSymm in child.symmetryCounterparts)
                {
                    if (!symmPart.children.Contains(otherSymm))
                    {
                        RemoveSymmetry(child);
                        break;
                    }
                }
            }
            RemovePartSymmetry(symmPart);
        }

        private static void RemovePartSymmetry(Part p)
        {
            foreach (var c in p.symmetryCounterparts)
            {
                c.symmetryCounterparts.Clear();
                c.symMethod = 0;
                c.stackSymmetry = 0;
            }
            p.symmetryCounterparts.Clear();
            p.symMethod = 0;
            p.stackSymmetry = 0;
        }
    }
}
