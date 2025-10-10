using UnityEngine;

public class wizard : MonoBehaviour
{
    public Animator animator;
    private float RamdomNum;
    public Projectile projectile;
    public Transform LaunchOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        RamdomNum = Random.Range(0.1f, 10); 
    }
    private float counter = 0;
    public bool wizardattacking = false;
    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= RamdomNum && !wizardattacking)
        {
            wizardattack();
            counter = 0f;
            RamdomNum = Random.Range(0.1f, 5);
            
        }
    }
 






    public void wizardattack()
    {
        if (animator != null)
        {
            animator.SetTrigger("attack");
        }
        wizardattacking = true;
        
    }
    public void wizardattackone()
    {

    }
    public void wizardattacktwo()
    {
        //gameObject.tag = "EnemyAttack";
        Instantiate(projectile, LaunchOffset.position, LaunchOffset.rotation);
    }
    public void wizardattackthree()
    {
        //gameObject.tag = "Enemy";
    }
    public void wizardattackend()
    {
        wizardattacking = false;
    }
}
