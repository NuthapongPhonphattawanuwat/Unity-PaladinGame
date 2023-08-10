using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    //Sound
    public AudioSource playerAttackSound;
    public AudioSource walkSound;
    public AudioSource jumpSound;
    //walking check for Sound
    private bool _walking = false;
    //Stage Checkpoint for respawn
    public Transform checkpoint;
    //Animator for transforming
    public RuntimeAnimatorController animatorNormal;
    public RuntimeAnimatorController animatoranimKnight;
    //Health Bar
    public PlayerHealthBar playerHealthBar;
    
    //#################################################################################################################################//
    
    //#####################################################   V a r i a b l e s   ####################################################//
    
    //#################################################################################################################################//

    //Controlling
    public Animator animator;
    private Rigidbody2D _rb2D;
    public float walkSpeed = 12f;
    public float jumpForce = 15f;
    public float jumpCount;
    
    //Underwater
    private float _underwaterHorizontalSpeed = 12f;
    private float _underwaterVerticalSpeed = 10f;
    
    //Health System
    public static float PlayerHealth;
    public static float PlayerMaxHealth = 10f;
    
    //Ground Check
    private bool _isGrounded = false;
    public bool isInWater = false;
    
    void Start () 
    {
        //Scene 3, Max health = 15
        if (SceneManager.GetActiveScene().name == "Scene3")
        {
            PlayerMaxHealth = 15f;
            PlayerHealth = PlayerMaxHealth;
            playerHealthBar.SetHealth(PlayerHealth,PlayerMaxHealth);
        }
        
        //Set Health & Max Health when start the game
        PlayerHealth = PlayerMaxHealth;
        playerHealthBar.SetHealth(PlayerHealth,PlayerMaxHealth);

        //Attack collider
        attackCircleCenter = GameObject.FindWithTag("AttackCircleCenter").transform;
        
        //Set Animator to normal
        GetComponent<Animator>().runtimeAnimatorController = animatorNormal;
        //Get rigidbody2D
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Check if grounded and set animator bool
        _isGrounded = gameObject.GetComponentInChildren<GroundSensor>().isGrounded;
        animator.SetBool("Grounded", _isGrounded);

        //#################################################################################################################################//

        //#############################################   M o v e m e n t    C o n t r o l    #############################################//

        //#################################################################################################################################//
        if (isInWater == false)
        {
            //Gravity Scale
            _rb2D.gravityScale = 4;

            //get Horizontal key
            float move = Input.GetAxis("Horizontal");

            //moving and facing left and right
            if (move > 0)
            {
                transform.localScale = new Vector3(-3, 3, 3);
            }
            else if (move < 0)
            {
                transform.localScale = new Vector3(3, 3, 3);
            }

            _rb2D.velocity = new Vector2(move * walkSpeed, _rb2D.velocity.y);
            
            //Walking sound
            if (move != 0f && _isGrounded == true && _walking == false)
            {
                _walking = true;
                walkSound.Play();
            }
            else if (move == 0 || _isGrounded == false)
            {
                walkSound.Stop();
                _walking = false;
            }

            //Set run animation while player moving
            if (Mathf.Abs(move) > Mathf.Epsilon)
            {
                animator.SetInteger("Move", 2);
            }
            else
            {
                animator.SetInteger("Move", 0);
            }

            //Jump if Jump count left
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpCount > 0)
                {
                    _rb2D.velocity = new Vector2(0, jumpForce);
                    jumpSound.Play();
                    jumpCount -= 1;
                }
            }
        }
        else if (isInWater == true)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            //moving and facing left and right
            if (horizontal > 0)
            {
                transform.localScale = new Vector3(-3, 3, 3);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(3, 3, 3);
            }

            _rb2D.velocity = new Vector2(horizontal * _underwaterHorizontalSpeed, vertical * _underwaterVerticalSpeed);

            //Gravity Scale
            _rb2D.gravityScale = 20;
        }

        //#################################################################################################################################//

        //###############################################   A t t a c k    C o n t r o l    ###############################################//

        //#################################################################################################################################//

        //Attack
        if (isInWater == false)
        {
            if (animator.runtimeAnimatorController == animatorNormal)
            {
                if (Time.time >= _nextAttackTime)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        AttackNormal();
                        _nextAttackTime = Time.time + (1f / attackRate);
                    }
                }
            }
            //If transformed, change attack method
            else if (animator.runtimeAnimatorController == animatoranimKnight)
            {
                if (Time.time >= _nextAttackTime)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        AttackKnight();
                        _nextAttackTime = Time.time + (1f / attackRate);
                    }
                }
            }

            //If scene 1-2 Maxhealth = 10, 3 Maxhealth = 15
            if (SceneManager.GetActiveScene().name == "Scene3")
            {
                if (PlayerHealth > 15)
                {
                    PlayerHealth = 15;
                }
            }
            else if (SceneManager.GetActiveScene().name == "Scene1" || SceneManager.GetActiveScene().name == "Scene2")
            {
                if (PlayerHealth > 10)
                {
                    PlayerHealth = 10;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //If player dead
        if (PlayerHealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    //#################################################################################################################################//
    
    //##################################################   A t t a c k    T y p e    ##################################################//
    
    //#################################################################################################################################//
    
    //Attack Speed Variables
    public float attackRate = 2f;
    private float _nextAttackTime = 0f;
    
    //attack collider set
    public GameObject attackCircle;
    public Transform attackCircleCenter;
    
    //Normal attack
    public void AttackNormal()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");
        StartCoroutine(AttackAnitmationDelay());
        
        IEnumerator AttackAnitmationDelay()
        {
            yield return new WaitForSeconds(0.5f);
            playerAttackSound.Play();
            Instantiate(attackCircle, attackCircleCenter.position, attackCircleCenter.rotation);
        }
    }
    //Transformed attack, faster
    public void AttackKnight()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");
        StartCoroutine(AttackAnitmationDelay());
        
        IEnumerator AttackAnitmationDelay()
        {
            yield return new WaitForSeconds(0.17f);
            playerAttackSound.Play();
            Instantiate(attackCircle, attackCircleCenter.position, attackCircleCenter.rotation);
        }
    }

    //Play hurt animation and decrease health if took damage
    public void TakeDamage(float damage)
    {
        IEnumerator Hurt()
        {
            animator.SetTrigger("Hurt");
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.4f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        PlayerHealth -= damage;
        StartCoroutine(Hurt());
        playerHealthBar.SetHealth(PlayerHealth,PlayerMaxHealth);
    }
    
    //Add health method for item(s?)
    public void AddHealth(float addhealth)
    {
        PlayerHealth += addhealth;
        playerHealthBar.SetHealth(PlayerHealth,PlayerMaxHealth);
    }
}