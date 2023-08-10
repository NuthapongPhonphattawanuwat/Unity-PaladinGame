using System;
using UnityEngine;
using System.Collections;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded = false;

    private void OnTriggerStay2D(Collider2D col)
    {
        isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.gameObject.name != "Attack Circle Collider(Clone)")
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().jumpCount = 2;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name != "Attack Circle Collider(Clone)")
        {
            isGrounded = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().jumpCount = 1;
        }
    }
}