using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int health = 10;
    [SerializeField] int maxDecrease = 1;
    [SerializeField] TMP_Text healthText;
    [SerializeField] AudioClip ouch;


    private void Start()
    {
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(ouch);

        health -= maxDecrease;
        healthText.text = health.ToString();

    }
}
