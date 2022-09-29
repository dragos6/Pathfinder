using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement Enemy;
    int count = 0;

    private void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }
 
    IEnumerator RepeatedlySpawnEnemies()
    {

        while (count<2)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
            count++;
        }
    }
}
