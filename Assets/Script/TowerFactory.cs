using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower tower;

    int numTowers = 0;
    public void AddTower(Block baseBlock)
    {
        if(numTowers < towerLimit)
        {
            Instantiate(tower, baseBlock.transform.position + (Vector3.up * 10), Quaternion.identity);
            baseBlock.isPlaceable = false;
            numTowers++;
        }
        else
        {
            MoveExistingTower();
        }
        
    }

    private void MoveExistingTower()
    {
        Debug.Log("Max towers reached");

    }
}
