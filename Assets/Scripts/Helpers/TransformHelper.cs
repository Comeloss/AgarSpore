using UnityEngine;

static class TransformHelper
{
	/// <summary>
	/// Sets new x.
	/// </summary>
	/// <returns>The x.</returns>
	/// <param name="angle">Angle.</param>
	/// <param name="newX">New x.</param>
	public static Quaternion SetX(this Quaternion angle, float newX)
	{
		angle.eulerAngles = angle.eulerAngles.SetX(newX);
		return angle;
	}

	/// <summary>
	/// Sets new y.
	/// </summary>
	/// <returns>The .</returns>
	/// <param name="angle">Angle.</param>
	/// <param name="newY">New y.</param>
	public static Quaternion SetY(this Quaternion angle, float newY)
	{
		angle.eulerAngles = angle.eulerAngles.SetY(newY);
		return angle;
	}

	/// <summary>
	/// Sets new z.
	/// </summary>
	/// <returns>The z.</returns>
	/// <param name="angle">Angle.</param>
	/// <param name="newZ">New z.</param>
	public static Quaternion SetZ(this Quaternion angle, float newZ)
	{
		angle.eulerAngles = angle.eulerAngles.SetZ(newZ);
		return angle;
	}

	/// <summary>
	/// Sets new x.
	/// </summary>
	/// <returns>The x.</returns>
	/// <param name="vec">Vec.</param>
	/// <param name="newX">New x.</param>
	public static Vector3 SetX(this Vector3 vec, float newX)
	{
		vec.x = newX;
		return vec;
	}

	/// <summary>
	/// Sets new y.
	/// </summary>
	/// <returns>The y.</returns>
	/// <param name="vec">Vec.</param>
	/// <param name="newY">New y.</param>
	public static Vector3 SetY(this Vector3 vec, float newY)
	{
		vec.y = newY;
		return vec;
	}

	/// <summary>
	/// Sets new z.
	/// </summary>
	/// <returns>The z.</returns>
	/// <param name="vec">Vec.</param>
	/// <param name="newZ">New z.</param>
	public static Vector3 SetZ(this Vector3 vec, float newZ)
	{
		vec.z = newZ;
		return vec;
	}

	/// <summary>
	/// Sets new local x.
	/// </summary>
	/// <returns>The local x.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newLocalPositionX">New local position x.</param>
	public static Transform SetLocalX(this Transform transform, float newLocalPositionX)
	{
		transform.localPosition = transform.localPosition.SetX(newLocalPositionX);
		return transform;
	}

	/// <summary>
	/// Sets new local y.
	/// </summary>
	/// <returns>The local y.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newLocalPositionY">New local position y.</param>
	public static Transform SetLocalY(this Transform transform, float newLocalPositionY)
	{
		transform.localPosition = transform.localPosition.SetY(newLocalPositionY);
		return transform;
	}

	/// <summary>
	/// Sets new local z.
	/// </summary>
	/// <returns>The local z.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newLocalPositionZ">New local position z.</param>
	public static Transform SetLocalZ(this Transform transform, float newLocalPositionZ)
	{
		transform.localPosition = transform.localPosition.SetZ(newLocalPositionZ);
		return transform;
	}

	/// <summary>
	/// Sets new x.
	/// </summary>
	/// <returns>The x.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newPositionX">New position x.</param>
	public static Transform SetX(this Transform transform, float newPositionX)
	{
		transform.position = transform.position.SetX(newPositionX);
		return transform;
	}

	/// <summary>
	/// Sets new y.
	/// </summary>
	/// <returns>The y.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newY">New y.</param>
	public static Transform SetY(this Transform transform, float newY)
	{
		transform.position = transform.position.SetY(newY);
		return transform;
	}

	/// <summary>
	/// Sets new z.
	/// </summary>
	/// <returns>The z.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newPositionZ">New position z.</param>
	public static Transform SetZ(this Transform transform, float newPositionZ)
	{
		transform.position = transform.position.SetZ(newPositionZ);
		return transform;
	}

	/// <summary>
	/// Rotates local x.
	/// </summary>
	/// <returns>The local x.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newRotationX">New rotation x.</param>
	public static Transform RotateLocalX(this Transform transform, float newRotationX)
	{
		transform.localRotation = transform.localRotation.SetX(newRotationX);
		return transform;
	}

	/// <summary>
	/// Rotates local y.
	/// </summary>
	/// <returns>The local y.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newRotationY">New rotation y.</param>
	public static Transform RotateLocalY(this Transform transform, float newRotationY)
	{
		transform.localRotation = transform.localRotation.SetY(newRotationY);
		return transform;
	}

	/// <summary>
	/// Rotates local z.
	/// </summary>
	/// <returns>The local z.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newRotationZ">New rotation z.</param>
	public static Transform RotateLocalZ(this Transform transform, float newRotationZ)
	{
		transform.localRotation = transform.localRotation.SetZ(newRotationZ);
		return transform;
	}

	/// <summary>
	/// Rotates the x.
	/// </summary>
	/// <returns>The x.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newRotationX">New rotation x.</param>
	public static Transform RotateX(this Transform transform, float newRotationX)
	{
		transform.rotation = transform.rotation.SetX(newRotationX);
		return transform;
	}

	/// <summary>
	/// Rotates y.
	/// </summary>
	/// <returns>The y.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newRotationY">New rotation y.</param>
	public static Transform RotateY(this Transform transform, float newRotationY)
	{
		transform.rotation = transform.rotation.SetY(newRotationY);
		return transform;
	}

	/// <summary>
	/// Rotates z.
	/// </summary>
	/// <returns>The z.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newRotationZ">New rotation z.</param>
	public static Transform RotateZ(this Transform transform, float newRotationZ)
	{
		transform.rotation = transform.rotation.SetZ(newRotationZ);
		return transform;
	}

	/// <summary>
	/// Rescales the local x.
	/// </summary>
	/// <returns>The rescale x.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newScaleX">New scale x.</param>
	public static Transform LocalRescaleX(this Transform transform, float newScaleX)
	{
		transform.localScale = transform.localScale.SetX(newScaleX);
		return transform;
	}

	/// <summary>
	/// Rescales the local y.
	/// </summary>
	/// <returns>The rescale y.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newScaleY">New scale y.</param>
	public static Transform LocalRescaleY(this Transform transform, float newScaleY)
	{
		transform.localScale = transform.localScale.SetY(newScaleY);
		return transform;
	}

	/// <summary>
	/// Rescales the local z.
	/// </summary>
	/// <returns>The rescale z.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newScaleZ">New scale z.</param>
	public static Transform LocalRescaleZ(this Transform transform, float newScaleZ)
	{
		transform.localScale = transform.localScale.SetZ(newScaleZ);
		return transform;
	}
}
