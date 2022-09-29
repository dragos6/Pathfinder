using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower tower;
    [SerializeField] Transform towerParentTransform;
    Queue<Tower> towersQueue = new Queue<Tower>();

    public void AddTower(Block baseBlock)
    {
        
        int numTowers = towersQueue.Count;
        if(numTowers < towerLimit)
        {
            var newTower =Instantiate(tower, baseBlock.transform.position, Quaternion.identity);
            newTower.transform.parent = towerParentTransform;
            baseBlock.isPlaceable = false;

            newTower.baseBlock = baseBlock;
            //baseBlock.isPlaceable = false;

            towersQueue.Enqueue(newTower);
        }
        else
        {
            MoveExistingTower(baseBlock);
        }
        
    }

    private  void MoveExistingTower(Block newBaseBlock)
    {
        Debug.Log("Max towers reached");
        var oldTower = towersQueue.Dequeue();

        oldTower.baseBlock.isPlaceable = true;
        newBaseBlock.isPlaceable = false;
        oldTower.baseBlock = newBaseBlock;
        oldTower.transform.position = newBaseBlock.transform.position ;

        towersQueue.Enqueue(oldTower);

    }
}
