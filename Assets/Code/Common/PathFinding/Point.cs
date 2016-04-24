public struct Point
{
	private int x;
	private int y;

	public int X
	{
		get
		{
			return x;
		}
	}

	public int Y
	{
		get
		{
			return y;
		}
	}

	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public static bool operator !=(Point l, Point r)
	{
		return l.X != r.X || l.Y != r.Y;
	}

	public static bool operator ==(Point l, Point r)
	{
		return l.X == r.X && l.Y == r.Y;
	}
}
