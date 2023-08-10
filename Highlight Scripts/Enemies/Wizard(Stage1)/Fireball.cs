using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _fireballMoveSpeedMin;
    [SerializeField] private float _fireballMoveSpeedMax;
    private float _fireballMoveSpeed;
    
    private Transform _playerTransform;
    
    private GameController _gc;
    
    private Vector2 _fireballMoveDirection;
    
    //Sound
    public AudioSource fireballHitSound;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        if (go != null)
        {
            _gc = go.GetComponent<GameController>();
        }
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            _playerTransform = playerObject.transform;
        }
        
        if (_playerTransform)
        {
            _fireballMoveDirection = _playerTransform.position - transform.position;
            _fireballMoveDirection.Normalize();
        }
        
        Destroy(gameObject, 2.7f);

        _fireballMoveSpeed = Random.Range(_fireballMoveSpeedMin,_fireballMoveSpeedMax);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3) _fireballMoveDirection * _fireballMoveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(_fireballMoveDirection);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            fireballHitSound.Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 2);
        }
    }
}