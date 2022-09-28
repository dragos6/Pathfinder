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
        ProccessHit();
        if (hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    

    void ProccessHit()
    {
        hitPoints = hitPoints - 1;
    }
    private void KillEnemy()
    {
        Destroy(gameObject);
    }

}
