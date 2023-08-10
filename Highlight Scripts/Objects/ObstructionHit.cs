using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstructionHit : MonoBehaviour
{
    public AudioSource spikeStabSound;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            spikeStabSound.Play();
            col.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            col.gameObject.GetComponent<Transform>().position = col.gameObject.GetComponent<PlayerController>().checkpoint.position;
        }
    }
}
