using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();

    [SerializeField] Block startPoint, endPoint;
    Queue<Block> queue = new Queue<Block>();
    Vector2Int[] directions =
        {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
        //ExploreNeighbours();
    }

    private void Pathfind()
    {
        queue.Enqueue(startPoint);
    
        while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            print(searchCenter);
            StopIfEndFound(searchCenter);
        }
    }

    private void StopIfEndFound(Block searchCenter)
    {
        isRunning = false;
        Debug.Log("end");
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int newPos = startPoint.GetGridPos() + direction;
            Debug.Log("exploring: "+ newPos);
            try
            {
                grid[newPos].SetColor(Color.blue);

            }
            catch (Exception)
            {

                Debug.Log(" no cube there at" + newPos);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startPoint.SetColor(Color.green);
        endPoint.SetColor(Color.red);
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
        print($"Loaded {grid.Count} blocks");
    }


}
