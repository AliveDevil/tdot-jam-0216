using UnityEngine;

public static class VectorExtensions
{
	public static Vector2 Round(this Vector2 v)
	{
		return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
	}

	public static Point ToPoint(this Vector2 v)
	{
		return new Point(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
	}

	public static Vector2 ToVector(this Point p)
	{
		return new Vector2(p.X, p.Y);
	}
}
