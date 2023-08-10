using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = System.Numerics.Vector3;

public class StoneCrabSpawn : MonoBehaviour
{
    [FormerlySerializedAs("skeletonPrefab")] [SerializeField] private GameObject stoneCrabPrefab;
    [FormerlySerializedAs("skeletonSpawnPoint")] [SerializeField] private Transform stoneCrabSpawnPoint;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(stoneCrabPrefab, stoneCrabSpawnPoint.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}