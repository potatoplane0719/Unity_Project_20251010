using System.Linq.Expressions;
using System.Xml.Serialization;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.AssetImporters;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.TextCore;

public class test : MonoBehaviour
{
    private attack Mattack;
    private bool isMovingX;
    public Animator animator = null;
    public bool gethit = false;
    public bool isBloking = false;
    public bool isJumping = false;
    public blocked blockedscript;
    private float timer = 0f;
    public PlayerAttackBox playerAttackBox;
    public Transform AttackOffset;
    public Transform BlockOffset;
    public bool canMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movespeed = 3f;
    public int Face = 1;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        Mattack = GetComponent<attack>();
        //Mattack.playerattack();
        animator = GetComponent<Animator>();

        if (Face == 1)
        {

        }
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && canMove && !isMovingX && !gethit && !isJumping && !Mattack.isAttacking)
        {

            animator.SetTrigger("block");
            Debug.Log("Block");
            Instantiate(blockedscript, BlockOffset.position, BlockOffset.rotation);
            isBloking = true;
        }
        if (!isMovingX)
        {
            if (animator != null)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Backward", false);
            }
        }
        if (!isJumping)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        if (gethit && !isBloking)
        {

            transform.Translate(-Time.deltaTime, 0, 0);
            return;
        }
        else
        {
            // Attack input always has priority
            if (!Mattack.isAttacking && Input.GetKeyDown(KeyCode.U) && !gethit)
            {

                isMovingX = false;
                if (animator != null)
                {
                    animator.SetBool("Walk", false);
                    animator.SetBool("Backward", false);
                }
                Mattack.isAttacking = true;
                Mattack.playerattack();
            }
            else if (!Mattack.isAttacking && !gethit && !isBloking && canMove)
            {
                isMovingX = false;
                if (Input.GetKey(KeyCode.D))
                {
                    int Face = 1;
                    isMovingX = true;
                    Move(Face);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    int Face = -1;
                    isMovingX = true;
                    Move(Face);
                }
                if (Input.GetKeyDown(KeyCode.W) && !isJumping)
                {
                    isMovingX = false;
                    timer = 0f;
                    if (!Mattack.isAttacking)
                    {
                        animator.SetTrigger("Jump");
                    }
                }

            }



        }

    }
    public void Move(int Face)
    {
        if (animator != null && !gethit)
        {
            // Flip the sprite based on Face
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Face;
            transform.localScale = scale;

            if (Face == 1)
            {
                animator.SetBool("Walk", isMovingX);
                animator.SetBool("Backward", !isMovingX);
            }
            else if (Face == -1)
            {
                animator.SetBool("Backward", isMovingX);
                animator.SetBool("Walk", !isMovingX);
            }

            transform.Translate(Face * movespeed * Time.deltaTime, 0, 0);
        }
    }
    public void Jump()
    {
        // Not used
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "green")
        {
            Debug.Log("Green!");
        }
        if (other.gameObject.tag == "red")
        {
            Debug.Log("Red!");
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyAttack" && !gethit && !isBloking)
        {
            gethit = true;
            animator.SetTrigger("hit");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    public void gethitstart()
    {
        gethit = true;
        //Debug.Log("player get hit!");
        GetComponent<SpriteRenderer>().color = Color.red; // or any Color
        TakeDamage(10);
    }
    public void gethitend()
    {
        gethit = false;
        Mattack.isAttacking = false;
        canMove = true;
        isJumping = false;
        //Debug.Log("player get hit end!");
        GetComponent<SpriteRenderer>().color = Color.white; // or any Color
    }
    public void jumpstart()
    {
        //Debug.Log("jumpstart");
        isJumping = true;

        timer = 0f;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    void FixedUpdate()
    {
        if (isJumping)
        {
            isJumping = true;

            timer += Time.fixedDeltaTime;
            if (timer >= 0.16f)
            {

                transform.Translate(0, 2.0f * Time.fixedDeltaTime, 0);

            }
            else if (timer < 0.35f)
            {
                transform.Translate(0, 0.8f - 4 * timer, 0);
            }
        }
    }
    public void jumpdown()
    {
        //Debug.Log("jumpdown");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void jumpend()

    {
        //Debug.Log("jumpend");
        isJumping = false;
        gethit = false;
    }
    public void BlockStart()
    {
        canMove = false;
        isBloking = true;


    }
    public void BlockEnd()
    {
        isBloking = false;
    }
    public void BlockOvercanMove()
    {
        gethit = false;
        canMove = true;
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
