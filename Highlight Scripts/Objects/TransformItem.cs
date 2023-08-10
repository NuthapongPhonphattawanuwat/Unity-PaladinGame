using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformItem : MonoBehaviour
{
    static public GameObject PlayerCharacter;
    
    //Sound
    public AudioSource pickUpSound;
    private void Start()
    {
        PlayerCharacter = GameObject.Find("PlayerCharacter");
    }

    IEnumerator Tranform()
    {
        GameObject.Find("PlayerCharacter").GetComponent<Animator>().runtimeAnimatorController = GameObject.Find("PlayerCharacter").GetComponent<PlayerController>().animatoranimKnight;
        PlayerCharacter.GetComponent<SpriteRenderer>().color = Color.white;
        PlayerCharacter.GetComponent<PlayerController>().attackRate = 4f;
        yield return new WaitForSeconds(15);
        PlayerCharacter.GetComponent<SpriteRenderer>().color = Color.white;
        GameObject.Find("PlayerCharacter").GetComponent<Animator>().runtimeAnimatorController = GameObject.Find("PlayerCharacter").GetComponent<PlayerController>().animatorNormal;
        PlayerCharacter.GetComponent<PlayerController>().attackRate = 1f;
        yield return new WaitForSeconds(3);
        PlayerCharacter.GetComponent<PlayerController>().attackRate = 2f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayerCharacter")
        {
            pickUpSound.Play();
            StartCoroutine(Tranform());
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject.GetComponent<Collider2D>());
        }
    }
}
