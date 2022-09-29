using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpawner : MonoBehaviour
{
    [Range(0f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement Enemy;
    [SerializeField] Transform enemyParent;
    [SerializeField] TMP_Text score;
    [SerializeField] AudioClip spawnedEnemySFX;
    int localScore=0;
    private void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        score.text = localScore.ToString();
    }
 
    IEnumerator RepeatedlySpawnEnemies()
    {

        while (true)
        {
            localScore += 100;
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            score.text=localScore.ToString();
            var NewEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
            NewEnemy.transform.parent = enemyParent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
