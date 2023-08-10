using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScorePickup : MonoBehaviour 
{ 
    private PlayerController _player;
    
    private bool _alreadyloot = false;

    public AudioSource healthPotionPickupSound;
    
    private void OnTriggerEnter2D(Collider2D col) 
    { 
        if (col.TryGetComponent(out _player)) 
        {
            if (_alreadyloot == false)
            {
                _alreadyloot = true;
                col.gameObject.GetComponent<PlayerController>().AddHealth(1f);
                ScoreManager.instance.AddScore(1); 
                healthPotionPickupSound.Play();
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;

                Destroy(gameObject, 2);
            }
        }
    }
}