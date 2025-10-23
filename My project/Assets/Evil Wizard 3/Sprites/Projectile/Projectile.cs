using JetBrains.Annotations;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator = null;
    public float Speed = 8f;
    public bool explode = false;
    private float RamdomSpeed;
    void Start()
    {
        RamdomSpeed = Random.Range(0.5f, 1.7f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed * RamdomSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !explode)
        {
            Debug.Log("player get hit!");
            animator.SetTrigger("projectiletouched");
            Speed = 0.1f;
            
        }
        if (other.gameObject.tag == "PlayerAttack" && !explode)
        {
            
            Debug.Log("projectile get hit!");
            animator.SetTrigger("projectiletouched");
            Speed = RamdomSpeed;
        }
        if(other.gameObject.tag == "Barrier" )
        {
            Debug.Log("projectile hit the Barrier!");
            Destroy(gameObject);
        }
    }
    public void movingend()
    {
        explode = true;
        

    }
    public void explodezero()
    {
        gameObject.tag = "Untagged";
    }
    public void explodestart()
    {
        gameObject.tag = "EnemyAttack";
    }
    public void explodeend()
    {
        Destroy(gameObject);
        explode = false;
    }
}
