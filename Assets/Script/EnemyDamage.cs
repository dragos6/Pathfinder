using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    void Start()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        print("I'm hit!");
        ProccessHit();
        if (hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    

    void ProccessHit()
    {
        hitPoints = hitPoints - 1;
        Debug.Log("Current hit points are" + hitPoints);
    }
    private void KillEnemy()
    {
        Destroy(gameObject);
    }

}
