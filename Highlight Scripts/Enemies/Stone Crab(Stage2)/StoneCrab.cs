using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCrab : MonoBehaviour
{
    static private float _health;
    static private float _maxHealth = 2f;
    public HealthBar HealthBar;

        
    //#################################################################################################################################//
    
    //################################################   S p a w n  Energy Ball    #################################################//
    
    //#################################################################################################################################//
    [Header("SpawnFireball")]
    [SerializeField] private GameObject energyBall;
    [SerializeField] private Transform energyBallSpawnPos;
    [SerializeField] private float energyBallSpawnDelay = 2f;
    
    //Sound
    public AudioSource stoneCrabDeadSound;
    public AudioSource stoneCrabShootSound;
    private void Start()
    {
        _health = _maxHealth;
        HealthBar.SetHealth(_health,_maxHealth);
        
        //Start to spawn energyball
        StartCoroutine(SpawnEnergyBall(energyBall, energyBallSpawnDelay, energyBallSpawnPos));
    }

    IEnumerator SpawnEnergyBall(GameObject energyBall, float spawnDelay, Transform spawnPosition)
    {
        while(!GameObject.Find("GameController").GetComponent<GameController>().gameOver)
        {
            //Vector2 spawnPosition = new Vector2 ();
            Instantiate (energyBall, spawnPosition.position, spawnPosition.rotation);
            stoneCrabShootSound.Play();
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        { 
            col.gameObject.GetComponent<PlayerController>().TakeDamage(2f); 
            stoneCrabDeadSound.Play();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject,2);
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
