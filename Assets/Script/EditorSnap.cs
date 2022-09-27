using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Block))]
public class EditorSnap : MonoBehaviour
{
    Block block;
    private void Awake()
    {
        block = GetComponent<Block>();
    }
    private void Update()
    {
        SnapToGrid();

        UpdateLabel();

    }
    private void SnapToGrid()
    {
        int gridSize = block.GetGridSize();


        transform.position = new Vector3(block.GetGridPos().x, 0f, block.GetGridPos().y);
    }

    private void UpdateLabel()
    {

        int gridSize = block.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string textLabel = block.GetGridPos().x / gridSize + "," + block.GetGridPos().y / gridSize;
        textMesh.text = textLabel;
        gameObject.name = "Cube " + textLabel;
    }
}

