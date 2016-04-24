using System.Collections.Generic;
using UnityEngine;

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
		var closed = new HashSet<PathNode>() { };
		var openList = new SortedList<int, PathNode>(n => n.Cost);
	}

	private void Awake()
	{
		controller = FindObjectOfType<PathFindingController>();
	}
}
