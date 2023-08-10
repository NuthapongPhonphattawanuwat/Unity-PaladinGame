using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnaught : MonoBehaviour
{
    static private float _health;
    static private float _maxHealth = 40f;
    public HealthBar HealthBar;
        
    //#################################################################################################################################//
    
    //################################################   S p a w n  Cyclone    #################################################//
    
    //#################################################################################################################################//
    [Header("SpawnCyclone")]
    [SerializeField] private GameObject cyclone;
    [SerializeField] private Transform spawnPos1, spawnPos2, spawnPos3, spawnPos4, spawnPos5, spawnPos6;
    [SerializeField] private float cycloneSpawnDelay = 3f;
    
    [Header("TempSpawn")]
    private Transform _cycloneSpawnPos;
    private int _randomSpawnpos;
    
    //Sound
    public AudioSource bossAttackSound;
    
    private void Start()
    {
        _health = _maxHealth;
        HealthBar.SetHealth(_health,_maxHealth);
        
        //Start to spawn cyclone

        StartCoroutine(RandomCycloneSpawn());
        StartCoroutine(RandomCycloneSpawn());
        StartCoroutine(RandomCycloneSpawn());
    }

    IEnumerator RandomCycloneSpawn()
    {
        while (!GameObject.Find("GameController").GetComponent<GameController>().gameOver)
        {
            _randomSpawnpos = Random.Range(1, 6);
            if (_randomSpawnpos == 1)
            {
                _cycloneSpawnPos = spawnPos1;
            }
            else if (_randomSpawnpos == 2)
            {
                _cycloneSpawnPos = spawnPos2;
            }
            else if (_randomSpawnpos == 3)
            {
                _cycloneSpawnPos = spawnPos3;
            }
            else if (_randomSpawnpos == 4)
            {
                _cycloneSpawnPos = spawnPos4;
            }
            else if (_randomSpawnpos == 5)
            {
                _cycloneSpawnPos = spawnPos5;
            }
            else if (_randomSpawnpos == 6)
            {
                _cycloneSpawnPos = spawnPos6;
            }

            StartCoroutine(SpawnCyclone(cyclone, cycloneSpawnDelay, _cycloneSpawnPos));
            yield return new WaitForSeconds(cycloneSpawnDelay);
        }
        yield return null;
    }

    IEnumerator SpawnCyclone(GameObject cyclone, float spawnDelay, Transform spawnPosition)
    {
        Instantiate(cyclone, spawnPosition.position, spawnPosition.rotation);
        bossAttackSound.Play();
        yield return new WaitForSeconds(0);
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
            cycloneSpawnDelay = 2f;
        }
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
