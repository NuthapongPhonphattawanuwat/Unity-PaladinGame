using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBig : MonoBehaviour
{
    //#################################################################################################################################//
    
    //################################################   S p a w n  Wave Form    #################################################//
    
    //#################################################################################################################################//
    [Header("SpawnWaveForm")]
    [SerializeField] private GameObject waveForm;
    [SerializeField] private Transform waveFormSpawnPos;
    [SerializeField] private float waveFormSpawnDelay = 2f;
    
    //Sound
    public AudioSource fishBigShootSound;
    
    private void Start()
    {
        //Start to spawn waveform
        StartCoroutine(SpawnWaveForm(waveForm, waveFormSpawnDelay, waveFormSpawnPos));
    }

    IEnumerator SpawnWaveForm(GameObject waveForm, float spawnDelay, Transform spawnPosition)
    {
        while(!GameObject.Find("GameController").GetComponent<GameController>().gameOver)
        {
            //Vector2 spawnPosition = new Vector2 ();
            Instantiate (waveForm, spawnPosition.position, spawnPosition.rotation);
            fishBigShootSound.Play();
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        { 
            col.gameObject.GetComponent<PlayerController>().TakeDamage(2f); 
            Destroy(gameObject);
        }
    }
}
