using System.Collections.Generic;
using UnityEngine;

public class PathFindingAgent : MonoBehaviour
{
	private PathFindingController controller;
	private Node endNode;
	private Dictionary<Point, Node> nodes;
	private Node startNode;

	public Node this[Point key]
	{
		get
		{
			var node = default(Node);
			if (!nodes.TryGetValue(key, out node))
				node = nodes[key] = new Node(key.X, key.Y, false, endNode.Location);
			return node;
		}
	}

	public PathFindingController Controller
	{
		get
		{
			return controller;
		}
	}

	public List<Point> FindPath()
	{
		// The start node is the first entry in the 'open' list
		List<Point> path = new List<Point>();
		bool success = Search(startNode);
		if (success)
		{
			// If a path was found, follow the parents from the end node to build a list of locations
			Node node = endNode;
			while (node.ParentNode != null)
			{
				path.Add(node.Location);
				node = node.ParentNode;
			}

			// Reverse the list so it's in the correct order when returned
			path.Reverse();
		}

		return path;
	}

	private static IEnumerable<Point> GetAdjacentLocations(Point fromLocation)
	{
		return new Point[]
		{
			new Point(fromLocation.X - 1, fromLocation.Y - 1),
			new Point(fromLocation.X - 1, fromLocation.Y),
			new Point(fromLocation.X - 1, fromLocation.Y + 1),
			new Point(fromLocation.X, fromLocation.Y + 1),
			new Point(fromLocation.X + 1, fromLocation.Y + 1),
			new Point(fromLocation.X + 1, fromLocation.Y),
			new Point(fromLocation.X + 1, fromLocation.Y - 1),
			new Point(fromLocation.X, fromLocation.Y - 1)
		};
	}

	private void Awake()
	{
		nodes = new Dictionary<Point, Node>();
		controller = FindObjectOfType<PathFindingController>();
	}

	private List<Node> GetAdjacentWalkableNodes(Node fromNode)
	{
		List<Node> walkableNodes = new List<Node>();
		IEnumerable<Point> nextLocations = GetAdjacentLocations(fromNode.Location);

		foreach (var location in nextLocations)
		{
			// Stay within the grid's boundaries
			Node node = this[location];

			// Ignore non-walkable nodes
			if (!node.IsWalkable)
				continue;

			// Ignore already-closed nodes
			if (node.State == NodeState.Closed)
				continue;

			// Already-open nodes are only added to the list if their G-value is lower going via this route.
			if (node.State == NodeState.Open)
			{
				float traversalCost = Node.GetTraversalCost(node.Location, node.ParentNode.Location);
				float gTemp = fromNode.G + traversalCost;
				if (gTemp < node.G)
				{
					node.ParentNode = fromNode;
					walkableNodes.Add(node);
				}
			}
			else
			{
				// If it's untested, set the parent and flag it as 'Open' for consideration
				node.ParentNode = fromNode;
				node.State = NodeState.Open;
				walkableNodes.Add(node);
			}
		}

		return walkableNodes;
	}
	
	private bool Search(Node currentNode)
	{
		// Set the current node to Closed since it cannot be traversed more than once
		currentNode.State = NodeState.Closed;
		List<Node> nextNodes = GetAdjacentWalkableNodes(currentNode);

		// Sort by F-value so that the shortest possible routes are considered first
		nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
		foreach (var nextNode in nextNodes)
		{
			// Check whether the end node has been reached
			if (nextNode.Location == endNode.Location)
			{
				return true;
			}
			else
			{
				// If not, check the next set of nodes
				if (Search(nextNode)) // Note: Recurses back into Search(Node)
					return true;
			}
		}

		// The method returns false if this path leads to be a dead end
		return false;
	}
}
