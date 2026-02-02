using Unity.Mathematics;
using UnityEngine;
using static Unity.Mathematics.math;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace BritoWorks
{
	/// <summary>
	/// Base MonoBehaviour utilities and convenience wrappers for Unity + Unity.Mathematics.
	/// Provides common transform accessors, vector constructors, and math helpers.
	/// </summary>
	public class BritoBehavior : MonoBehaviour
	{
		#region Constants

		/// <summary>Pi constant in single-precision.</summary>
		public const float PI = 3.14159265358979323846f;

		#endregion

		#region Transform accessors

		/// <summary>World position.</summary>
		public Vector3 position => transform.position;

		/// <summary>World rotation.</summary>
		public Quaternion rotation => transform.rotation;

		/// <summary>Local scale.</summary>
		public Vector3 scale => transform.localScale;

		/// <summary>World euler angles.</summary>
		public Vector3 eulerAngles => transform.eulerAngles;

		/// <summary>World forward direction.</summary>
		public Vector3 forward => transform.forward;

		/// <summary>World up direction.</summary>
		public Vector3 up => transform.up;

		/// <summary>World right direction.</summary>
		public Vector3 right => transform.right;

		#endregion

		#region Vector constructors

		/// <summary>Creates a Vector2.</summary>
		public static Vector2 vec(float x, float y) => new(x, y);

		/// <summary>Creates a Vector3.</summary>
		public static Vector3 vec(float x, float y, float z) => new(x, y, z);

		/// <summary>Creates a Vector4.</summary>
		public static Vector4 vec(float x, float y, float z, float w) => new(x, y, z, w);

		/// <summary>Creates a Vector4 from components.</summary>
		public static Vector4 vec4(float x, float y, float z, float w) => new(x, y, z, w);

		/// <summary>Creates a Vector4 from a Vector3 (xyz) and w.</summary>
		public static Vector4 vec4(Vector3 xyz, float w) => new(xyz.x, xyz.y, xyz.z, w);

		/// <summary>Creates a Vector4 from x and a Vector3 (yzw).</summary>
		public static Vector4 vec4(float x, Vector3 yzw) => new(x, yzw.x, yzw.y, yzw.z);

		/// <summary>Creates a Vector4 from a Vector2 (xy), z, and w.</summary>
		public static Vector4 vec4(Vector2 xy, float z, float w) => new(xy.x, xy.y, z, w);

		/// <summary>Creates a Vector4 from x, a Vector2 (yz), and w.</summary>
		public static Vector4 vec4(float x, Vector2 yz, float w) => new(x, yz.x, yz.y, w);

		/// <summary>Creates a Vector4 from x, y, and a Vector2 (zw).</summary>
		public static Vector4 vec4(float x, float y, Vector2 zw) => new(x, y, zw.x, zw.y);

		/// <summary>Creates a Vector4 where all components are value.</summary>
		public static Vector4 vec4(float value) => new(value, value, value, value);

		/// <summary>Creates a Vector3 from components.</summary>
		public static Vector3 vec3(float x, float y, float z) => new(x, y, z);

		/// <summary>Creates a Vector3 from a Vector2 (xy) and z.</summary>
		public static Vector3 vec3(Vector2 xy, float z) => new(xy.x, xy.y, z);

		/// <summary>Creates a Vector3 from x and a Vector2 (yz).</summary>
		public static Vector3 vec3(float x, Vector2 yz) => new(x, yz.x, yz.y);

		/// <summary>Creates a Vector3 where all components are value.</summary>
		public static Vector3 vec3(float value) => new(value, value, value);

		/// <summary>Creates a Vector2 from components.</summary>
		public static Vector2 vec2(float x, float y) => new(x, y);

		/// <summary>Creates a Vector2 where both components are value.</summary>
		public static Vector2 vec2(float value) => new(value, value);

		#endregion

		#region Math helpers

		/// <summary>Absolute value.</summary>
		public static float abs(float value) => math.abs(value);

		/// <summary>
		/// Returns true if two values are within threshold of each other.
		/// Default threshold is float.Epsilon (very strict).
		/// </summary>
		public static bool approx(float valueA, float valueB, float threshold = float.Epsilon)
			=> abs(valueA - valueB) <= threshold;

		/// <summary>Sine.</summary>
		public static float sin(float value) => math.sin(value);

		/// <summary>Cosine.</summary>
		public static float cos(float value) => math.cos(value);

		/// <summary>Tangent.</summary>
		public static float tan(float value) => math.tan(value);

		/// <summary>Hyperbolic tangent.</summary>
		public static float tanh(float value) => math.tanh(value);

		/// <summary>Arc tangent.</summary>
		public static float atan(float value) => math.atan(value);

		/// <summary>Arc tangent (two-argument).</summary>
		public static float atan2(float x, float y) => math.atan2(x, y);

		/// <summary>Power.</summary>
		public static float pow(float value, float power) => math.pow(value, power);

		/// <summary>Square root.</summary>
		public static float sqrt(float value) => math.sqrt(value);

		/// <summary>Degrees to radians.</summary>
		public static float deg2rad(float deg) => deg * TORADIANS;

		/// <summary>Radians to degrees.</summary>
		public static float rad2deg(float rad) => rad * TODEGREES;

		#endregion
	}
}
