using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();

    [SerializeField] Block startPoint, endPoint;
    public bool blocksLoaded = false;
    Queue<Block> queue = new Queue<Block>();
    Vector2Int[] directions =
        {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    List<Block> path = new List<Block>(); 

    [SerializeField] bool isRunning = true;

    Block searchCenter;

    public List<Block> GetPath()
    {
        if(path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }

    private void CreatePath()
    {
        path.Add(endPoint);
        endPoint.isPlaceable = false;
        Block previous = endPoint.exploredFrom;
        while (previous != startPoint)
        {
            path.Add(previous);
            previous.isPlaceable = false;
            previous = previous.exploredFrom;
        }
        path.Add(startPoint);
        startPoint.isPlaceable=false;
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            StopIfEndFound();
            ExploreNeighbours();

        }
    }

    private void StopIfEndFound()
    {
        if (searchCenter == endPoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int newPos = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(newPos))
            {
                QueueNewNeighbours(newPos);
            }
        }
    }

    void QueueNewNeighbours(Vector2Int newPos)
    {
        Block neighbour = grid[newPos];

        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            // do nothing  

        }
        else
        {
            //neighbour.SetColor(Color.blue);
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
           // yield return new WaitForSeconds(1);
        }

    }



    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Block>();
        foreach (var waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.Log($"Block { waypoint.GetGridPos()} is overlapping");
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
        blocksLoaded = true;
        print($"Loaded {grid.Count} blocks");
    }


}
