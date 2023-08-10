using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCircle : MonoBehaviour
{
    private FireSlime _fireSlime;
    private Wizard _wizard;
    private Skeleton _skeleton;
    private StoneCrab _stoneCrab;
    private Dreadnaught _dreadnaught;

    //sound
    public AudioSource hitSound;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Fire Slime"||(col.gameObject.name == "Fire Slime(Clone)"))
        {
            hitSound.Play();
            _fireSlime = col.gameObject.GetComponent<FireSlime>();
            _fireSlime.TakeDamage(1f);
        }
        
        if (col.gameObject.name == "Wizard")
        {
            hitSound.Play();
            _wizard = col.gameObject.GetComponent<Wizard>();
            _wizard.TakeDamage(1);
        }
        
        if (col.gameObject.name == "Skeleton"||(col.gameObject.name == "Skeleton(Clone)"))
        {
            hitSound.Play();
            _skeleton = col.gameObject.GetComponent<Skeleton>();
            _skeleton.TakeDamage(1.5f);
        }
        
        if (col.gameObject.name == "Stone Crab"||(col.gameObject.name == "Stone Crab(Clone)"))
        {
            hitSound.Play();
            _stoneCrab = col.gameObject.GetComponent<StoneCrab>();
            _stoneCrab.TakeDamage(1.5f);
        }
        
        if (col.gameObject.name == "Dreadnaught")
        {
            hitSound.Play();
            _dreadnaught = col.gameObject.GetComponent<Dreadnaught>();
            _dreadnaught.TakeDamage(1.5f);
        }
    }
    
    private void Update()
    {
        Destroy(gameObject,3f);
    }
}