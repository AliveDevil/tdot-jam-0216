using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingController : MonoBehaviour
{
	[SerializeField]
	private Transform parent;
	private Dictionary<Point, Tile> tiles;

	public Tile this[Point p]
	{
		get
		{
			var tile = default(Tile);
			tiles.TryGetValue(p, out tile);
			return tile;
		}
	}

	public Transform Parent
	{
		get
		{
			return parent;
		}
		set
		{
			parent = value;
		}
	}

	private IEnumerator FillGrid()
	{
		var childs = parent.childCount;
		for (int i = 0; i < childs; i++)
		{
			var child = parent.GetChild(i);
			var tile = child.GetComponent<Tile>();
			if (!tile)
				continue;
			var position = ((Vector2)child.position).ToPoint();
			tiles[position] = tile;

			yield return i;
		}
	}

	private void Start()
	{
		tiles = new Dictionary<Point, Tile>();
		StartCoroutine(FillGrid());
	}
}
