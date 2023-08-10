using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZoneCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        IEnumerator IsTriggerDisableEnter()
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10); ; 
            yield return new WaitForSeconds(1f);
            col.gameObject.GetComponent<PlayerController>().isInWater = true;
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
        IEnumerator IsTriggerDisableExit()
        {
            col.gameObject.GetComponent<PlayerController>().isInWater = false;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
            yield return new WaitForSeconds(1f);
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
        
        if (col.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.name == "WaterEnter")
            {
                StartCoroutine(IsTriggerDisableEnter());
            }
            else if (this.gameObject.name == "WaterExit")
            {
                StartCoroutine(IsTriggerDisableExit());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
