using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PathFindingAgent : MonoBehaviour
{
	private PathFindingController controller;

	public PathFindingController Controller
	{
		get
		{
			return controller;
		}
	}

	public void Move(Vector2 target)
	{
		var openList = new SortedList<int, PathNode>();
		var closed = new HashSet<PathNode>();
		openList.Add(0, new PathNode()
		{
			Node = Controller[((Vector2)transform.position).Round()]
		});

		var currentNode = default(PathNode);
		while (openList.Count > 0)
		{
			var first = openList.First();
			currentNode = first.Value;
			openList.Remove(first.Key);

			if (currentNode.Node.Position == target)
				// PFAD GEFUNDEN
				return;

			closed.Add(currentNode);

			ExpandNode(currentNode);
		}

		// KEIN PFAD!
		return;
	}

	private void Awake()
	{
		controller = FindObjectOfType<PathFindingController>();
	}

	private void ExpandNode(PathNode node)
	{

	}
}
