using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
     public AudioSource platformBreaking;
     private bool _triggered = false;
     
     private void OnCollisionEnter2D(Collision2D col)
     {
          if (col.gameObject.CompareTag("Player") && _triggered == false)
          {
               if (gameObject.CompareTag("BreakingPlatform"))
               {
                    _triggered = true;
                    StartCoroutine(Delay());
                    
                    IEnumerator Delay()
                    {
                         yield return new WaitForSeconds(2.5f);
                         GetComponent<Renderer>().enabled = false;
                         GetComponent<Collider2D>().enabled = false;
                         platformBreaking.Play();
                         yield return new WaitForSeconds(1f);
                         Destroy(gameObject);
                    }
               }
          }
     }
}
