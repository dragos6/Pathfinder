using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] AudioClip takingDamage;
    [SerializeField] AudioClip fatalDamage;

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
        hitParticles.Play();
        GetComponentInParent<AudioSource>().PlayOneShot(takingDamage);

        hitPoints = hitPoints - 1;
    }
    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticles,transform.position,Quaternion.identity);
        vfx.Play();
        AudioSource.PlayClipAtPoint(fatalDamage, Camera.main.transform.position);
        Destroy(gameObject);
    }

}
