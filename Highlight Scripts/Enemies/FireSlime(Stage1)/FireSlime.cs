using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlime : MonoBehaviour
{
    static private float _health;
    static private float _maxHealth = 2f;
    public HealthBar HealthBar;
    
    //Sound
    public AudioSource slimeDeadSound;
    // Start is called before the first frame update
    private void Start()
    {
        _health = _maxHealth;
        HealthBar.SetHealth(_health,_maxHealth);
    }

    //Take hit 
    IEnumerator TakeDamage()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        StartCoroutine(TakeDamage());
        HealthBar.SetHealth(_health,_maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        { 
            col.gameObject.GetComponent<PlayerController>().TakeDamage(2f);
            slimeDeadSound.Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject,1);
        }
    }

    private void Update()
    {
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
