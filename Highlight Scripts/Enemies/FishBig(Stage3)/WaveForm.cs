using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WaveForm : MonoBehaviour
{
    [SerializeField] private float _waveFormMoveSpeedMin;
    [SerializeField] private float _waveFormMoveSpeedMax;
    private float _waveFormMoveSpeed;
    
    private Transform _playerTransform;
    
    private GameController _gc;
    
    private Vector2 _waveFormMoveDirection;
    
    //Sound
    public AudioSource hitPlayerSound;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);

        _waveFormMoveSpeed = Random.Range(_waveFormMoveSpeedMin,_waveFormMoveSpeedMax);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * _waveFormMoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            hitPlayerSound.Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject,2);
        }
    }
}