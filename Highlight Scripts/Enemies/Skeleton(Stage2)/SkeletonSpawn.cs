using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class SkeletonSpawn : MonoBehaviour
{
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private Transform skeletonSpawnPoint;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(skeletonPrefab, skeletonSpawnPoint.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}