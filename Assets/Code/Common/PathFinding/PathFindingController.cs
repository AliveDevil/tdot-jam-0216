using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingController : MonoBehaviour
{
	private Dictionary<Vector2, Node> nodes;
	[SerializeField]
	private Transform parent;

	public Node this[Vector2 v]
	{
		get
		{
			var node = default(Node);
			nodes.TryGetValue(v, out node);
			return node;
		}
	}

	private IEnumerator FillGrid()
	{
		var childs = parent.childCount;
		for (int i = 0; i < childs; i++)
		{
			var child = parent.GetChild(i);
			var position = (Vector2)child.position;
			var collider = child.GetComponent<Collider2D>();
			var node = new Node()
			{
				Position = position,
				Traversable = !collider
			};
			nodes[position] = node;

			yield return i;
		}
	}

	private void Start()
	{
		nodes = new Dictionary<Vector2, Node>();
		StartCoroutine(FillGrid());
	}
}
