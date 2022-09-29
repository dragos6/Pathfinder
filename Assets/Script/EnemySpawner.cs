using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement Enemy;
    [SerializeField] Transform enemyParent;
    private void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }
 
    IEnumerator RepeatedlySpawnEnemies()
    {

        while (true)
        {
            var NewEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
            NewEnemy.transform.parent = enemyParent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
