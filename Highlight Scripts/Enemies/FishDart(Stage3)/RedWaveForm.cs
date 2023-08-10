using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RedWaveForm : MonoBehaviour
{
    [SerializeField] private float _redWaveFormMoveSpeedMin;
    [SerializeField] private float _redWaveFormMoveSpeedMax;
    private float _redWaveFormMoveSpeed;
    
    private Transform _playerTransform;
    
    private GameController _gc;
    
    private Vector2 _redWaveFormMoveDirection;
    
    //Sound
    public AudioSource hitPlayerSound;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);

        _redWaveFormMoveSpeed = Random.Range(_redWaveFormMoveSpeedMin,_redWaveFormMoveSpeedMax);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * _redWaveFormMoveSpeed;
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
