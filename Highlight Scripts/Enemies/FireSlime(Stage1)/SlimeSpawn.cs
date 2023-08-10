using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class SlimeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject slimePrefab;
    [SerializeField] private Transform slimeSpawnPoint;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(slimePrefab, slimeSpawnPoint.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
