using UnityEngine;

public class Tile : MonoBehaviour
{
	private Point location;

	public Point Location
	{
		get
		{
			return location;
		}
		set
		{
			location = value;
		}
	}

	private void Awake()
	{
		location = new Point((int)transform.position.x, (int)transform.position.y);
	}
}
