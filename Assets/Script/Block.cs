using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isExplored = false;
    public bool isPlaceable = true;
    public Block exploredFrom;
    Vector2Int gridPos;
    const int gridSize = 10;
    const string towerParentName = "Towers";

    [SerializeField] Renderer renderer;
   
    [SerializeField] Material placebleMaterial, unplaceableMaterial;


    public int GetGridSize()
    {
        return gridSize;
    }
    private void Update()
    {
        if (isPlaceable)
        {
            renderer.material = placebleMaterial;
            
        }
        if(!isPlaceable)
        {
            renderer.material = unplaceableMaterial;
        }
        
    }
    public Vector2Int GetGridPos()
    {

        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {

                FindObjectOfType<TowerFactory>().AddTower(this);

            }
            else
            {
                print("Can't place here");
            }

        }


    }
}
