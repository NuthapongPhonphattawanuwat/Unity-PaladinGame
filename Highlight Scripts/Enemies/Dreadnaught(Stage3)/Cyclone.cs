using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclone : MonoBehaviour
{
    private bool alreadyHit = false;
    
    //Sound
    public AudioSource hitPlayerSound;
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage(0.02f);
            
            if (alreadyHit == false)
            {
                hitPlayerSound.Play();
                alreadyHit = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hitPlayerSound.Stop();
            alreadyHit = false;
        }
    }

    private void Update()
    {
        Destroy(gameObject,2f);
    }
}
