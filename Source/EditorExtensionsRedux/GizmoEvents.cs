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

namespace EditorExtensionsRedux
{
	[KSPAddon(KSPAddon.Startup.EditorAny, true)]
	class GizmoEvents : MonoBehaviour
	{
		public static readonly EventData<EditorGizmos.GizmoRotate> onRotateGizmoSpawned = new EventData<EditorGizmos.GizmoRotate>("onRotateGizmoSpawned");
		public static readonly EventData<EditorGizmos.GizmoOffset> onOffsetGizmoSpawned = new EventData<EditorGizmos.GizmoOffset>("onOffsetGizmoSpawned");
		public static bool rotateGizmoActive = false;
		public static bool offsetGizmoActive = false;
		public static EditorGizmos.GizmoOffset[] gizmosOffset = null;
		public static EditorGizmos.GizmoOffsetHandle gizmoOffsetHandle = null;
		public static EditorGizmos.GizmoRotate[] gizmosRotate = null;
		public static EditorGizmos.GizmoRotateHandle gizmoRotateHandle = null;

		class GizmoCreationListener : MonoBehaviour
		{
			private void Start()
			// I use Start instead of Awake because whatever setup the editor does to the gizmo won't be done yet
			{
				EditorGizmos.GizmoRotate rotate = null;
				EditorGizmos.GizmoOffset offset = null;

				if (gameObject.GetComponentCached(ref rotate) != null)
				{
					onRotateGizmoSpawned.Fire(rotate);
				}
				else if (gameObject.GetComponentCached(ref offset) != null)
				{
					onOffsetGizmoSpawned.Fire(offset);
				}
				else Log.warn("Didn't find a gizmo on this GameObject -- something has broken");

				// could destroy this MB now, unless you wanted to use OnDestroy to sent an event
			}

			private void OnDestroy()
			{
				// could also send an event on despawn here
			}
		}


		private void Awake()
		{
			AddListenerToGizmo("RotateGizmo");
			AddListenerToGizmo("OffsetGizmo");

			Destroy(gameObject);
		}


		private static void AddListenerToGizmo(string prefabName)
		{
			var prefab = AssetBase.GetPrefab(prefabName);

			if (prefab == null)
			{
				Log.error("Couldn't find gizmo '{0}'", prefabName);
				return;
			}

			prefab.AddOrGetComponent<GizmoCreationListener>();

			#if DEBUG
			Log.trace("Added listener to {0}", prefabName);
			#endif
		}



		private void RotateGizmoSpawned(EditorGizmos.GizmoRotate data)
		{
			Log.trace("Rotate gizmo was spawned 1");
		}


		private void OffsetGizmoSpawned(EditorGizmos.GizmoOffset data)
		{
			Log.trace("Offset gizmo was spawned 1");
		}



	}

	#if true
	[KSPAddon(KSPAddon.Startup.EditorAny, false)]
	class TestGizmoEvents : MonoBehaviour
	{
		private void Start()
		{
			GizmoEvents.onRotateGizmoSpawned.Add(RotateGizmoSpawned);
			GizmoEvents.onOffsetGizmoSpawned.Add(OffsetGizmoSpawned);
		}


		private void OnDestroy()
		{
			GizmoEvents.onRotateGizmoSpawned.Remove(RotateGizmoSpawned);
			GizmoEvents.onOffsetGizmoSpawned.Remove(OffsetGizmoSpawned);
		}


		private void RotateGizmoSpawned(EditorGizmos.GizmoRotate data)
		{
			GizmoEvents.rotateGizmoActive = true;
			GizmoEvents.offsetGizmoActive = false;
			GizmoEvents.gizmosRotate = HighLogic.FindObjectsOfType<EditorGizmos.GizmoRotate> ();
			GizmoEvents.gizmoRotateHandle = HighLogic.FindObjectOfType<EditorGizmos.GizmoRotateHandle> ();
			Log.dbg("Rotate gizmo was spawned 2");
		}


		private void OffsetGizmoSpawned(EditorGizmos.GizmoOffset data)
		{
			GizmoEvents.rotateGizmoActive = false;
			GizmoEvents.offsetGizmoActive = true;
			GizmoEvents.gizmosOffset = HighLogic.FindObjectsOfType<EditorGizmos.GizmoOffset> ();
			GizmoEvents.gizmoOffsetHandle = HighLogic.FindObjectOfType<EditorGizmos.GizmoOffsetHandle> ();

            if (EditorLogic.SelectedPart != null)
            {
                
                Space sp = GizmoEvents.gizmosOffset[0].CoordSpace;
                Log.dbg("gizmoOffset == null, EditorLogic.SelectedPart: {0}", EditorLogic.SelectedPart.partInfo.title);
                Log.dbg("coordSpace: {0}", sp);

                if (GizmoEvents.gizmosOffset[0].CoordSpace == Space.Self)
                {
                    GizmoEvents.gizmosOffset[0].transform.rotation = EditorLogic.SelectedPart.transform.rotation;
                }
                else
                {
                    GizmoEvents.gizmosOffset[0].transform.rotation = Quaternion.identity;
                }

            }

            Log.dbg("Offset gizmo was spawned 2");
		}
	}
	#endif
}

