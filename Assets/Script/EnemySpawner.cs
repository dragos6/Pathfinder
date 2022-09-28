using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement Enemy;


    private void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }
 
    IEnumerator RepeatedlySpawnEnemies()
    {

        while (true)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);

        }
    }
}
