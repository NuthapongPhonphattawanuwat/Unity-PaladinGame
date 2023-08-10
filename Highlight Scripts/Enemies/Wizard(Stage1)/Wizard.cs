using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    static private float _health;
    static private float _maxHealth = 20f;
    public HealthBar HealthBar;
        
    //#################################################################################################################################//
    
    //################################################   S p a w n  F i r e b a l l    #################################################//
    
    //#################################################################################################################################//
    [Header("SpawnFireball")]
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform fireballSpawnPos;
    [SerializeField] private float fireballSpawnDelay = 2f;
    public AudioSource fireballSpawnSound;
    private void Start()
    {
        _health = _maxHealth;
        HealthBar.SetHealth(_health,_maxHealth);
        
        //Start to spawn fireball
        StartCoroutine(SpawnFireball(fireball, fireballSpawnDelay, fireballSpawnPos));
    }

    IEnumerator SpawnFireball(GameObject fireball, float spawnDelay, Transform spawnPosition)
    {
        while(!GameObject.Find("GameController").GetComponent<GameController>().gameOver)
        {
            //Vector2 spawnPosition = new Vector2 ();
            Instantiate (fireball, spawnPosition.position, spawnPosition.rotation);
            fireballSpawnSound.Play();
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return null;
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

    private void Update()
    {
        if (_health <= 10f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            fireballSpawnDelay = 0.8f;
        }
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}