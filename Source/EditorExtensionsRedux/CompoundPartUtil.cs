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

namespace EditorExtensionsRedux
{
	public static class CompoundPartUtil
	{
		const string strutPartName = "strutConnector";
		const string fuelLinePartName = "fuelLine";
		const float CompoundPartMaxLength = 10f;

		static CompoundPartUtil()
		{
		}

		//get distance: Vector3.Distance(object1.transform.position, object2.transform.position);
		//Physics.Raycast(part.transform.position, part.transform.TransformDirection(dir), out HIT, this.maxLength, EditorLogic.LayerMask)

		/// <summary>
		/// Align compount part, leave in starting position but center and level to target
		/// </summary>
		/// <param name="part">Part</param>
		public static void AlignCompoundPart (CompoundPart part, bool snapHeights)
		{
			if (part.parent == null || part.target == null) {
				Log.warn("Part is not fully connected");
				return;
			}

			if (snapHeights)
				AlignCompoundPartSnapped(part);
			else
				AlignCompoundPartLevel(part);
		}

		static void AlignCompoundPartSnapped(CompoundPart part)
		{
			Part startPart = part.parent;
			Part targetPart = part.target;

			Log.dbg("Getting parentLocalHeight");
			float parentLocalHeight = GetCompoundPartPositionHeight(part, part.parent);
			//float parentLocalHeight = SnapCompoundPartHeight(part, part.parent);
			Log.dbg("Getting targetLocalHeight");
			float targetLocalHeight = GetCompoundPartPositionHeight(part, part.target);
			//float targetLocalHeight = SnapCompoundPartHeight(part, part.target);

			Vector3 startPosition = startPart.transform.position;
			Vector3 destPosition = targetPart.transform.position;

			Log.dbg(string.Format("startPosition: {0} destPosition: {1}", startPosition, destPosition));

			GetCollisionPointOnAxis(startPart, destPosition, parentLocalHeight, out startPosition);
			GetCollisionPointOnAxis(targetPart, startPosition, targetLocalHeight, out destPosition);
			Log.dbg(string.Format("new collider startPosition: {0} destPosition: {1}", startPosition, destPosition));

			RepositionPart(part, startPart, startPosition, destPosition);
		}

		static void AlignCompoundPartLevel(CompoundPart part)
		{
			Part startPart = part.parent;
			Part targetPart = part.target;

			Vector3 startPosition = startPart.transform.position;
			Vector3 destPosition = targetPart.transform.position;

			GetCollisionPointOnAxis(startPart, destPosition, part.transform.localPosition.y, out startPosition);

			destPosition = startPart.transform.InverseTransformPoint(destPosition); //get local pos
			destPosition.y = part.transform.localPosition.y; //level out
			destPosition = startPart.transform.TransformPoint(destPosition); //back to global pos

			Log.dbg(string.Format("new level startPosition: {0} destPosition: {1}", startPosition, destPosition));

			RepositionPart(part, startPart, startPosition, destPosition);
		}

		static void RepositionPart(CompoundPart part, Part startPart, Vector3 startPosition, Vector3 destPosition)
		{
			part.transform.position = startPosition;
			part.transform.up = startPart.transform.up;
			part.transform.forward = startPart.transform.forward;
			part.transform.LookAt(destPosition); //this rotates the strut base towards the target, need to keep it flush with the parent
			part.transform.Rotate(0, 90, 0);

			Vector3 localDirToTarget = part.transform.InverseTransformDirection((destPosition - startPosition).normalized);
			Log.dbg("final direction: {0}", localDirToTarget);

			part.raycastTarget(localDirToTarget);
		}

		static float GetCompoundPartPositionHeight (CompoundPart part, Part target)
		{
			Log.dbg(string.Format("Getting new position height for {0} on {1}", part.name, target.name));

			//lengthwise position on parent (extents, +/- from center)
			float localHeight = 0f;
			float parentHeight = 0f;
			if (part.parent == target) {
				localHeight = part.transform.localPosition.y;
				parentHeight = part.parent.GetPartRendererBound ().extents.y;
			} else if (part.target == target) {
				Vector3 targetPos = part.transform.TransformPoint (part.targetPosition);
				targetPos = target.transform.InverseTransformPoint (targetPos);
				localHeight = targetPos.y;
				parentHeight = target.GetPartRendererBound().extents.y;
			} else {
				Log.warn("Unable to identify part");
			}

			Log.dbg(string.Format("localHeight: {0:F3} parentHeight: {1:f3}", localHeight, parentHeight));

			//offset strut when attaching to top/bottom of parent
			const float strutOffset = 0.15f;
			//threshold for small parent parts
			const float parentSizeCutoff = 0.5f;

			float heightPct = localHeight / parentHeight;
			Log.dbg("Attachment height% {0:F0}: ", (heightPct * 100f));
			Log.dbg("Original localHeight: {0}", localHeight);

			//+1 up, -1 down
			float upOrDown = 1f;
			if (localHeight < 0f)
				upOrDown = -1f;

			if (parentHeight < parentSizeCutoff) {
				//for small parts, just center on them
				Log.dbg("Parent is small, defaulting to center");
				localHeight = 0f;
			} else if (parentHeight >= 1.5f) {
				//only do quarter snapping for parts >= 3.0 total height
				if (Math.Abs(localHeight) < parentHeight * 0.125f) {
					//middle 25% of parent, snap to center (12.5% of extent)
					Log.dbg("Centering on parent");
					localHeight = 0f;
				} else if (Math.Abs(localHeight) < parentHeight * 0.7f) {
					//top/bottom quarter (70% of extent)
					Log.dbg("Centering quarter on parent");
					localHeight = parentHeight / 2 * upOrDown;
				} else {
					//top/bottom edge
					Log.dbg("Aligning to edge of parent");
					localHeight = (parentHeight - strutOffset) * upOrDown;
				}
			
			} else if (Math.Abs(localHeight) < parentHeight * 0.5f) {
				//middle 50% of parent, snap to center
				Log.dbg("Centering on parent");
				localHeight = 0f;
			} else {
				//top/bottom edge
				Log.dbg("Aligning to edge of parent");
				localHeight = (parentHeight - strutOffset) * upOrDown;
			}


			Log.dbg("new localHeight: {0}", localHeight);
			return localHeight;
		}

		/// <summary>
		/// get coll point
		/// </summary>
		/// <returns><c>true</c>, if collision point on axis2 was gotten, <c>false</c> otherwise.</returns>
		/// <param name="part">Part to get surface attachment point</param>
		/// <param name="externalPoint">Other part for direction</param>
		/// <param name="partHeight">Height to attach on part</param>
		/// <param name="collisionPoint">Collision point on part</param>
		private static bool GetCollisionPointOnAxis (Part part, Vector3 externalPoint, float partHeight, out Vector3 collisionPoint)
		{
			//(to - from).normalized;
			Log.dbg("partHeight {0:F3}", partHeight);
			Vector3 internalTarget = part.transform.TransformPoint (new Vector3 (0f, partHeight, 0f));
			Log.dbg("internalTarget {0:F3}", internalTarget);
			//localize external point
			externalPoint = part.transform.InverseTransformPoint (externalPoint);
			Log.dbg("local externalPoint {0:F3}", externalPoint);
			//level to same height
			externalPoint.y = partHeight;
			Log.dbg("levelled local externalPoint {0:F3}", externalPoint);
			//back to global
			externalPoint = part.transform.TransformPoint (externalPoint);
			Log.dbg ("global externalPoint {0:F3}", externalPoint);

			Vector3 direction = (internalTarget - externalPoint).normalized;
			Log.dbg("direction {0:F2}", direction);

			return GetPartCollisionPointByDirection (part, externalPoint, direction, out collisionPoint);
		}

		/// <summary>
		/// get collision point starting from inside the part's collider
		/// </summary>
		private static bool GetPartCollisionPointByDirection (Part part, Vector3 origin, Vector3 targetDirection, out Vector3 collisionPoint)
		{
			Log.dbg(string.Format("GetPartCollisionPointByDirection: collider raycast from {0:F3} in direction {1:F3}", origin, targetDirection));
			//using this method becuase Physics.RayCast ignores hits originating from inside the collider
			Ray r = new Ray (origin, targetDirection);

			//collider property is deprecated, removed in 5.0 - use GetComponent<Collider>, but need to identify collider type, eg BoxCollider

			RaycastHit hit = new RaycastHit ();
			if (part.collider.Raycast(r, out hit, CompoundPartMaxLength)) {
				collisionPoint = hit.point;
				Log.dbg("Collider hit: {0}", collisionPoint);
				return true;
			} else {
				collisionPoint = origin;
				Log.dbg("Collider miss");
				return false;
			}
		}
	}
}

