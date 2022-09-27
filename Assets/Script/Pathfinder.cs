using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();

    [SerializeField] Block startPoint, endPoint;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
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
            if(grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.Log($"Block { waypoint.GetGridPos()} is overlapping");
            }
            else
            {
            grid.Add(waypoint.GetGridPos(), waypoint);
                waypoint.SetColor(Color.black);
            }
        }
        print($"Loaded {grid.Count} blocks");
    }

   
}
