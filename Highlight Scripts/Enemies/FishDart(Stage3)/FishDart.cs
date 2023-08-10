using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDart : MonoBehaviour
{
    //#################################################################################################################################//
    
    //################################################   S p a w n  Red Wave Form    #################################################//
    
    //#################################################################################################################################//
    [Header("SpawnRedWaveForm")]
    [SerializeField] private GameObject redWaveForm;
    [SerializeField] private Transform redWaveFormSpawnPos;
    [SerializeField] private float redWaveFormSpawnDelay = 2f;
    
    //Sound
    public AudioSource fishDartShootSound;
    private void Start()
    {
        //Start to spawn redwaveform
        StartCoroutine(SpawnRedWaveForm(redWaveForm, redWaveFormSpawnDelay, redWaveFormSpawnPos));
    }

    IEnumerator SpawnRedWaveForm(GameObject redWaveForm, float spawnDelay, Transform spawnPosition)
    {
        while(!GameObject.Find("GameController").GetComponent<GameController>().gameOver)
        {
            //Vector2 spawnPosition = new Vector2 ();
            Instantiate (redWaveForm, spawnPosition.position, spawnPosition.rotation);
            fishDartShootSound.Play();
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
