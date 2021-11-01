/*
Copyright (C) 2015 FW Industries

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software witho
ut restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PUR
POSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHE
RWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using UnityEngine;
using EditorGizmos;

#if true
namespace EditorExtensionsRedux.NoOffsetBehaviour
{
    /**
	 * Removes limits from offset gizmo. Limits are enforced in EditorLogic::onOffsetGizmoUpdate. This recreates the gizmo after the 
	 * st_offset_tweak state is entered and reimplements the offset logic without limits.
	 */
    //[KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class FreeOffsetBehaviour : MonoBehaviour
    {
        //private Log log;

        public static FreeOffsetBehaviour Instance = null;

        private delegate void CleanupFn();
        private CleanupFn OnCleanup;

        private GizmoOffset gizmoOffset;

        public void Start()
        {
            Instance = this;
            if (!EditorExtensions.validVersion)
                return;

            //log = new Log(this.GetType().Name);
            Log.trace("FreeOffsetBehaviour.Start");

            //			var st_offset_tweak = (KFSMState)Refl.GetValue(EditorLogic.fetch, "st_offset_tweak");
            var st_offset_tweak = (KFSMState)Refl.GetValue(EditorLogic.fetch, EditorExtensions.c.ST_OFFSET_TWEAK);

            KFSMStateChange hookOffsetUpdateFn = (from) =>
            {

                var p = EditorLogic.SelectedPart;

                if (p != null && p.GetType() == typeof(CompoundPart))
                {
                    return;
                }

                p.onEditorStartTweak();
                var parent = p.parent;
                var symCount = p.symmetryCounterparts.Count;
                //var attachNode = Refl.GetValue(EditorLogic.fetch, "\u001B\u0002");
                //var attachNode = Refl.GetValue(EditorLogic.fetch, "symUpdateAttachNode");
                var symUpdateAttachNode = Refl.GetValue(EditorLogic.fetch, EditorExtensions.c.SYMUPDATEATTACHNODE);

                //public static GizmoOffset Attach(Transform host, Quaternion rotOffset, Callback<Vector3> onMove, Callback<Vector3> onMoved, Camera refCamera = null);



                Quaternion rotOffset = p.attRotation;

                //                this.gizmoOffset = GizmoOffset.Attach(this.selectedPart.transform,
                //                    new Callback<Vector3>(this.onOffsetGizmoUpdate), 
                //                    new Callback<Vector3>(this.onOffsetGizmoUpdated), 
                //                    this.editorCamera);

                // this.audioSource.PlayOneShot(this.tweakGrabClip);

                // gizmoRotate = (GizmoRotate)Refl.GetValue(EditorLogic.fetch, EditorExtensions.c.GIZMOROTATE);

                gizmoOffset = GizmoOffset.Attach(EditorLogic.SelectedPart.transform,
                    rotOffset,

                    new Callback<Vector3>((offset) =>
                    {
                        if (gizmoOffset.CoordSpace == Space.Self)
                        {
                            gizmoOffset.transform.rotation = p.transform.rotation;
                        }
                        else
                        {
                            gizmoOffset.transform.rotation = Quaternion.identity;
                        }

                        p.transform.position = gizmoOffset.transform.position;
                        p.attPos = p.transform.localPosition - p.attPos0;

                        Log.detail("symCount: {0}", symCount);
                        if (symCount != 0)
                        {
                            //	Refl.Invoke(EditorLogic.fetch, "UpdateSymmetry", p, symCount, parent, symUpdateAttachNode);
                            Refl.Invoke(EditorLogic.fetch, EditorExtensions.c.UPDATESYMMETRY, p, symCount, parent, symUpdateAttachNode);
                        }

                        GameEvents.onEditorPartEvent.Fire(ConstructionEventType.PartOffsetting, EditorLogic.SelectedPart);
                    }),

                    new Callback<Vector3>((offset) =>
                    {
                        //Refl.Invoke(EditorLogic.fetch, "onOffsetGizmoUpdated", offset);
                        Refl.Invoke(EditorLogic.fetch, EditorExtensions.c.ONOFFSETGIZMOUPDATED, offset);
                    }), EditorLogic.fetch.editorCamera);


                //((GizmoOffset)Refl.GetValue(EditorLogic.fetch, "gizmoOffset")).Detach();
                ((GizmoOffset)Refl.GetValue(EditorLogic.fetch, EditorExtensions.c.GIZMOOFFSET)).Detach();
                //Refl.SetValue(EditorLogic.fetch, "gizmoOffset", gizmo);
                Refl.SetValue(EditorLogic.fetch, EditorExtensions.c.GIZMOOFFSET, gizmoOffset);
            };
            st_offset_tweak.OnEnter += hookOffsetUpdateFn;
            OnCleanup += () =>
            {
                st_offset_tweak.OnEnter -= hookOffsetUpdateFn;
            };
            Log.dbg("Installed.");
        }

        void Update()
        {
            if (gizmoOffset == null || EditorLogic.SelectedPart == null)
                return;
            {
#if false
                if (EditorLogic.SelectedPart != null)
                {
                    GizmoOffset go = new GizmoOffset();
                    Space sp = go.CoordSpace;
                    Log.Info("gizmoOffset == null, EditorLogic.SelectedPart: " + EditorLogic.SelectedPart.partInfo.title);
                    Log.Info("coordSpace: " + sp.ToString());
                }
#endif
                //return;
            }

            Part p = EditorLogic.SelectedPart;
            if (p != null && p.GetType() == typeof(CompoundPart))
            {
                return;
            }

            if (GameSettings.Editor_coordSystem.GetKeyUp(false) && !gizmoOffset.IsDragging)
            {
                if (gizmoOffset.CoordSpace == Space.Self)
                {
                    gizmoOffset.transform.rotation = EditorLogic.SelectedPart.transform.rotation;
                   // ScreenMessages.PostScreenMessage(EditorLogic.cacheAutoLOC_6001221, this.modeMsg);
                }
                else
                {
                    gizmoOffset.transform.rotation = Quaternion.identity;
                   // ScreenMessages.PostScreenMessage(EditorLogic.cacheAutoLOC_6001222, this.modeMsg);
                }

            }
        }


        public void OnDestroy()
        {
            Log.trace("FreeOffsetBehaviour.OnDestroy");
            if (OnCleanup != null) OnCleanup();
            Log.dbg("Cleanup complete.");
        }
    }
}
#endif