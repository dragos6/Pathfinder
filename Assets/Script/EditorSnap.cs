using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)] float gridSize = 10f;
    private void Update()
    {
        Vector3 snap;
        snap.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;

        snap.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snap.x, 0, snap.z);
    }
}
