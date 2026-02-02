using Unity.Mathematics;
using UnityEngine;

namespace BritoWorks
{
	/// <summary>
	/// BritoWorks Core Extensions.
	///
	/// A collection of allocation-free vector swizzles, distance helpers,
	/// range checks, and direction utilities designed for performance-critical
	/// Unity gameplay and simulation code.
	/// Mainly used for terrible lazy programming.
	/// </summary>
	/// <remarks>
	/// Author: Min Jun Kim
	/// Project: BritoWorks
	/// Unity Version: 6000.3
	///
	/// This library favors explicit math over operator-heavy implementations
	/// to reduce temporary allocations and improve predictability in hot paths.
	/// </remarks>
	public static class BritoExtension
	{
		#region Swizzles: Vector2 from Vector3

		/// <summary>Returns (x, y) from a Vector3.</summary>
		public static Vector2 xy(this Vector3 xyz) => new(xyz.x, xyz.y);

		/// <summary>Returns (y, z) from a Vector3.</summary>
		public static Vector2 yz(this Vector3 xyz) => new(xyz.y, xyz.z);

		/// <summary>Returns (x, z) from a Vector3.</summary>
		public static Vector2 xz(this Vector3 xyz) => new(xyz.x, xyz.z);

		#endregion

		#region Swizzles: Vector2 repeats (xx, yy, zz, ww)

		/// <summary>Returns (x, x) from a Vector2.</summary>
		public static Vector2 xx(this Vector2 xy)
		{
			float x = xy.x;
			return new Vector2(x, x);
		}

		/// <summary>Returns (x, x) from a Vector3.</summary>
		public static Vector2 xx(this Vector3 xyz)
		{
			float x = xyz.x;
			return new Vector2(x, x);
		}

		/// <summary>Returns (x, x) from a Vector4.</summary>
		public static Vector2 xx(this Vector4 xyzw)
		{
			float x = xyzw.x;
			return new Vector2(x, x);
		}

		/// <summary>Returns (y, y) from a Vector2.</summary>
		public static Vector2 yy(this Vector2 xy)
		{
			float y = xy.y;
			return new Vector2(y, y);
		}

		/// <summary>Returns (y, y) from a Vector3.</summary>
		public static Vector2 yy(this Vector3 xyz)
		{
			float y = xyz.y;
			return new Vector2(y, y);
		}

		/// <summary>Returns (y, y) from a Vector4.</summary>
		public static Vector2 yy(this Vector4 xyzw)
		{
			float y = xyzw.y;
			return new Vector2(y, y);
		}

		/// <summary>Returns (z, z) from a Vector3.</summary>
		public static Vector2 zz(this Vector3 xyz)
		{
			float z = xyz.z;
			return new Vector2(z, z);
		}

		/// <summary>Returns (z, z) from a Vector4.</summary>
		public static Vector2 zz(this Vector4 xyzw)
		{
			float z = xyzw.z;
			return new Vector2(z, z);
		}

		/// <summary>Returns (w, w) from a Vector4.</summary>
		public static Vector2 ww(this Vector4 xyzw)
		{
			float w = xyzw.w;
			return new Vector2(w, w);
		}

		#endregion

		#region Swizzles: Vector3 repeats (xxx, yyy, zzz, www)

		/// <summary>Returns (x, x, x) from a Vector2.</summary>
		public static Vector3 xxx(this Vector2 xy)
		{
			float x = xy.x;
			return new Vector3(x, x, x);
		}

		/// <summary>Returns (x, x, x) from a Vector3.</summary>
		public static Vector3 xxx(this Vector3 xyz)
		{
			float x = xyz.x;
			return new Vector3(x, x, x);
		}

		/// <summary>Returns (x, x, x) from a Vector4.</summary>
		public static Vector3 xxx(this Vector4 xyzw)
		{
			float x = xyzw.x;
			return new Vector3(x, x, x);
		}

		/// <summary>Returns (y, y, y) from a Vector2.</summary>
		public static Vector3 yyy(this Vector2 xy)
		{
			float y = xy.y;
			return new Vector3(y, y, y);
		}

		/// <summary>Returns (y, y, y) from a Vector3.</summary>
		public static Vector3 yyy(this Vector3 xyz)
		{
			float y = xyz.y;
			return new Vector3(y, y, y);
		}

		/// <summary>Returns (y, y, y) from a Vector4.</summary>
		public static Vector3 yyy(this Vector4 xyzw)
		{
			float y = xyzw.y;
			return new Vector3(y, y, y);
		}

		/// <summary>Returns (z, z, z) from a Vector3.</summary>
		public static Vector3 zzz(this Vector3 xyz)
		{
			float z = xyz.z;
			return new Vector3(z, z, z);
		}

		/// <summary>Returns (z, z, z) from a Vector4.</summary>
		public static Vector3 zzz(this Vector4 xyzw)
		{
			float z = xyzw.z;
			return new Vector3(z, z, z);
		}

		/// <summary>Returns (w, w, w) from a Vector4.</summary>
		public static Vector3 www(this Vector4 xyzw)
		{
			float w = xyzw.w;
			return new Vector3(w, w, w);
		}

		#endregion

		#region Distance: Unity Distance wrappers

		/// <summary>Returns Euclidean distance between two Vector2 values.</summary>
		public static float distance(this Vector2 from, Vector2 to) => Vector2.Distance(from, to);

		/// <summary>Returns Euclidean distance between two Vector3 values.</summary>
		public static float distance(this Vector3 from, Vector3 to) => Vector3.Distance(from, to);

		/// <summary>Returns Euclidean distance between two Vector4 values.</summary>
		public static float distance(this Vector4 from, Vector4 to) => Vector4.Distance(from, to);

		/// <summary>Returns Euclidean distance between two Transform positions.</summary>
		public static float distance(this Transform from, Transform to) => Vector3.Distance(from.position, to.position);

		/// <summary>Returns Euclidean distance between Transform position and Vector3.</summary>
		public static float distance(this Transform from, Vector3 to) => Vector3.Distance(from.position, to);

		/// <summary>Returns Euclidean distance between Transform position (xy) and Vector2.</summary>
		public static float distance(this Transform from, Vector2 to) => Vector2.Distance(from.position, to);

		#endregion

		#region DistanceSquared: Manual math

		/// <summary>Returns squared distance between two Vector2 values.</summary>
		public static float distanceSquared(this Vector2 from, Vector2 to)
		{
			float dx = from.x - to.x;
			float dy = from.y - to.y;
			return dx * dx + dy * dy;
		}

		/// <summary>Returns squared distance between two Vector3 values.</summary>
		public static float distanceSquared(this Vector3 from, Vector3 to)
		{
			float dx = from.x - to.x;
			float dy = from.y - to.y;
			float dz = from.z - to.z;
			return dx * dx + dy * dy + dz * dz;
		}

		/// <summary>Returns squared distance between two Vector4 values.</summary>
		public static float distanceSquared(this Vector4 from, Vector4 to)
		{
			float dx = from.x - to.x;
			float dy = from.y - to.y;
			float dz = from.z - to.z;
			float dw = from.w - to.w;
			return dx * dx + dy * dy + dz * dz + dw * dw;
		}

		/// <summary>Returns squared distance between two Transform positions.</summary>
		public static float distanceSquared(this Transform from, Transform to)
		{
			Vector3 a = from.position;
			Vector3 b = to.position;

			float dx = a.x - b.x;
			float dy = a.y - b.y;
			float dz = a.z - b.z;
			return dx * dx + dy * dy + dz * dz;
		}

		/// <summary>Returns squared distance between Transform position and Vector3.</summary>
		public static float distanceSquared(this Transform from, Vector3 to)
		{
			Vector3 a = from.position;

			float dx = a.x - to.x;
			float dy = a.y - to.y;
			float dz = a.z - to.z;
			return dx * dx + dy * dy + dz * dz;
		}

		/// <summary>Returns squared distance between Transform position (xy) and Vector2.</summary>
		public static float distanceSquared(this Transform from, Vector2 to)
		{
			Vector3 a = from.position;

			float dx = a.x - to.x;
			float dy = a.y - to.y;
			return dx * dx + dy * dy;
		}

		/// <summary>Returns squared distance between Vector3 and Transform position.</summary>
		public static float distanceSquared(this Vector3 from, Transform to)
		{
			Vector3 b = to.position;

			float dx = from.x - b.x;
			float dy = from.y - b.y;
			float dz = from.z - b.z;
			return dx * dx + dy * dy + dz * dz;
		}

		/// <summary>Returns squared distance between Vector2 and Transform position (xy).</summary>
		public static float distanceSquared(this Vector2 from, Transform to)
		{
			Vector3 b = to.position;

			float dx = from.x - b.x;
			float dy = from.y - b.y;
			return dx * dx + dy * dy;
		}

		#endregion

		#region Range checks (inRange)

		/// <summary>Returns true if squared distance is less than or equal to distance^2.</summary>
		public static bool inRange(this Vector2 from, Vector2 to, float distance)
			=> from.distanceSquared(to) <= distance * distance;

		/// <summary>Returns true if squared distance is less than or equal to distance^2.</summary>
		public static bool inRange(this Vector3 from, Vector3 to, float distance)
			=> from.distanceSquared(to) <= distance * distance;

		/// <summary>Returns true if squared distance is less than or equal to distance^2.</summary>
		public static bool inRange(this Vector4 from, Vector4 to, float distance)
			=> from.distanceSquared(to) <= distance * distance;

		/// <summary>Returns true if Transform position (xy) is within distance of Vector2.</summary>
		public static bool inRange(this Transform from, Vector2 to, float distance)
		{
			Vector3 a = from.position;

			float dx = a.x - to.x;
			float dy = a.y - to.y;

			float distSq = dx * dx + dy * dy;
			float rangeSq = distance * distance;
			return distSq <= rangeSq;
		}

		/// <summary>Returns true if Transform position is within distance of Vector3.</summary>
		public static bool inRange(this Transform from, Vector3 to, float distance)
		{
			Vector3 a = from.position;

			float dx = a.x - to.x;
			float dy = a.y - to.y;
			float dz = a.z - to.z;

			float distSq = dx * dx + dy * dy + dz * dz;
			float rangeSq = distance * distance;
			return distSq <= rangeSq;
		}

		/// <summary>Returns true if Vector2 is within distance of Transform position (xy).</summary>
		public static bool inRange(this Vector2 from, Transform to, float distance)
		{
			Vector3 b = to.position;

			float dx = from.x - b.x;
			float dy = from.y - b.y;

			float distSq = dx * dx + dy * dy;
			float rangeSq = distance * distance;
			return distSq <= rangeSq;
		}

		/// <summary>Returns true if Vector3 is within distance of Transform position.</summary>
		public static bool inRange(this Vector3 from, Transform to, float distance)
		{
			Vector3 b = to.position;

			float dx = from.x - b.x;
			float dy = from.y - b.y;
			float dz = from.z - b.z;

			float distSq = dx * dx + dy * dy + dz * dz;
			float rangeSq = distance * distance;
			return distSq <= rangeSq;
		}

		#endregion

		#region Direction (dir)

		/// <summary>
		/// Returns normalized direction from Transform position (xy) to Vector2.
		/// Returns Vector2.zero when the direction has zero length.
		/// </summary>
		public static Vector2 dir(this Transform from, Vector2 to)
		{
			Vector3 a = from.position;

			float dx = to.x - a.x;
			float dy = to.y - a.y;

			float lenSq = dx * dx + dy * dy;
			if (lenSq <= 0f)
				return Vector2.zero;

			float invLen = 1f / math.sqrt(lenSq);
			return new Vector2(dx * invLen, dy * invLen);
		}

		/// <summary>
		/// Returns normalized direction from Vector2 to Transform position (xy).
		/// Returns Vector2.zero when the direction has zero length.
		/// </summary>
		public static Vector2 dir(this Vector2 from, Transform to)
		{
			Vector3 b = to.position;

			float dx = b.x - from.x;
			float dy = b.y - from.y;

			float lenSq = dx * dx + dy * dy;
			if (lenSq <= 0f)
				return Vector2.zero;

			float invLen = 1f / math.sqrt(lenSq);
			return new Vector2(dx * invLen, dy * invLen);
		}

		/// <summary>
		/// Returns normalized direction from Vector2 to Vector2.
		/// Returns Vector2.zero when the direction has zero length.
		/// </summary>
		public static Vector2 dir(this Vector2 from, Vector2 to)
		{
			float dx = to.x - from.x;
			float dy = to.y - from.y;

			float lenSq = dx * dx + dy * dy;
			if (lenSq <= 0f)
				return Vector2.zero;

			float invLen = 1f / math.sqrt(lenSq);
			return new Vector2(dx * invLen, dy * invLen);
		}

		/// <summary>
		/// Returns normalized direction from Transform position to Vector3.
		/// Returns Vector3.zero when the direction has zero length.
		/// </summary>
		public static Vector3 dir(this Transform from, Vector3 to)
		{
			Vector3 a = from.position;

			float dx = to.x - a.x;
			float dy = to.y - a.y;
			float dz = to.z - a.z;

			float lenSq = dx * dx + dy * dy + dz * dz;
			if (lenSq <= 0f)
				return Vector3.zero;

			float invLen = 1f / math.sqrt(lenSq);
			return new Vector3(dx * invLen, dy * invLen, dz * invLen);
		}

		/// <summary>
		/// Returns normalized direction from Vector3 to Transform position.
		/// Returns Vector3.zero when the direction has zero length.
		/// </summary>
		public static Vector3 dir(this Vector3 from, Transform to)
		{
			Vector3 b = to.position;

			float dx = b.x - from.x;
			float dy = b.y - from.y;
			float dz = b.z - from.z;

			float lenSq = dx * dx + dy * dy + dz * dz;
			if (lenSq <= 0f)
				return Vector3.zero;

			float invLen = 1f / math.sqrt(lenSq);
			return new Vector3(dx * invLen, dy * invLen, dz * invLen);
		}

		/// <summary>
		/// Returns normalized direction from Vector3 to Vector3.
		/// Returns Vector3.zero when the direction has zero length.
		/// </summary>
		public static Vector3 dir(this Vector3 from, Vector3 to)
		{
			float dx = to.x - from.x;
			float dy = to.y - from.y;
			float dz = to.z - from.z;

			float lenSq = dx * dx + dy * dy + dz * dz;
			if (lenSq <= 0f)
				return Vector3.zero;

			float invLen = 1f / math.sqrt(lenSq);
			return new Vector3(dx * invLen, dy * invLen, dz * invLen);
		}

		#endregion
	}
}
