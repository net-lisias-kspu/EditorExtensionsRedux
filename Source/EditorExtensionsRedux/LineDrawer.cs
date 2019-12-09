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
using UnityEngine;
#if false
namespace EditorExtensionsRedux
{
	public class LineDrawer : MonoBehaviour
	{
		public LineDrawer ()
		{}

		const string shaderName = "Particles/Alpha Blended";
		Material material;

		protected virtual void Awake ()
		{
			material = new Material (Shader.Find (shaderName));
		}

		protected virtual void Start ()
		{

		}

		protected virtual void LateUpdate ()
		{
		}

		protected LineRenderer newLine ()
		{
			var obj = new GameObject("EditorExtensions.LineDrawer");
			var lr = obj.AddComponent<LineRenderer>();
			obj.transform.parent = gameObject.transform;
			obj.transform.localPosition = Vector3.zero;
			lr.material = material;
			return lr;
		}

		void DrawLine(Vector3 start, Vector3 end)
		{
			LineRenderer line = gameObject.AddComponent<LineRenderer>();
			//line.SetColors (Color.blue, Color.blue);
            line.startColor = Color.blue;
            line.endColor = Color.blue;
			//line.useWorldSpace = false;
			//line.SetVertexCount (2);
            line.positionCount = 2;
			line.SetPosition(0, start);
			line.SetPosition(1, end);
			//line.SetWidth (0.5f, 0.1f);
            line.startWidth = 0.5f;
            line.endWidth = 0.1f;
			line.material = material;

		}
	}
}

#endif