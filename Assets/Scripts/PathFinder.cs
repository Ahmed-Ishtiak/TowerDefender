using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
	[SerializeField] Waypoint startWaypoint, endWaypoint;
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;
	Waypoint seachCenter;
	List<Waypoint> path = new List<Waypoint>();
	Vector2Int[] directions =
	{
		Vector2Int.up,
		Vector2Int.down,
		Vector2Int.left,
		Vector2Int.right,
	};

	public List<Waypoint> GetPath()
	{
		if(path.Count == 0)
		{
            LoadBlocks();
            //ColorStartEndPoint();
            BreadthFirstSearch();
            CreatePath();
        }
		
		return path;
	}
	private void CreatePath()
    {
        SetAsPath(endWaypoint);

        Waypoint previous = endWaypoint.exploreFrom;
        while (previous != startWaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploreFrom;
        }
		SetAsPath(startWaypoint);
        path.Reverse();

    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch()
	{	
		queue.Enqueue(startWaypoint);
		while (queue.Count > 0 && isRunning)
		{ 
		    seachCenter =queue.Dequeue();
			HaltIfEndFound();
			ExploreNeighbour();
			seachCenter.isExplored = true;
		}
		
	}

	private void HaltIfEndFound()
	{
		if(seachCenter == endWaypoint)
		{ 
			isRunning = false;
		}
	}

	private void ExploreNeighbour()
	{
		if (!isRunning) { return; }
		foreach(Vector2Int direction in directions)
		{
			Vector2Int neighbourCoordinates = seachCenter.GetGridPos() + direction;
			if(grid.ContainsKey(neighbourCoordinates))
			{
				QueueNewNeighbour(neighbourCoordinates);
			}
		}
	}

	private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
	{
		Waypoint neighbour = grid[neighbourCoordinates];
		if (neighbour.isExplored || queue.Contains(neighbour))
		{

		}
		else
		{
			queue.Enqueue(neighbour);
			neighbour.exploreFrom = seachCenter;
		}
	}
    /*
	private void ColorStartEndPoint()
	{
		startWaypoint.SetTopColor(Color.white);
		endWaypoint.SetTopColor(Color.red);
	}
	*/
	private void LoadBlocks()
	{
		var waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints) 
		{
			var gridPos = waypoint.GetGridPos();
			if(grid.ContainsKey(gridPos))
			{
				Debug.LogWarning("Skipping Overlapping Block"+ waypoint);
			}
			else
			{
				grid.Add(gridPos, waypoint);
			}
		}
	}
}
