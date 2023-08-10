using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnergyBall : MonoBehaviour
{
    [SerializeField] private float _energyBallMoveSpeedMin;
    [SerializeField] private float _energyBallMoveSpeedMax;
    private float _energyBallMoveSpeed;
    
    private Transform _playerTransform;
    
    private GameController _gc;
    
    private Vector2 _energyBallMoveDirection;
    //Sound
    public AudioSource energyBallHitPlayerSound;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        _energyBallMoveSpeed = Random.Range(_energyBallMoveSpeedMin,_energyBallMoveSpeedMax);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * _energyBallMoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            energyBallHitPlayerSound.Play();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject,2);
        }
    }
}
