using UnityEngine;

public class slime : MonoBehaviour
{
    public Animator animator;
    private float RamdomNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        RamdomNum = Random.Range(0.1f, 5); 
    }
    private float counter = 0;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= RamdomNum)
        {
            slimeattack();
            counter = 0f;
            RamdomNum = Random.Range(0.1f, 5);
            
        }
    }







    public void slimeattack()
    {
        if (animator != null)
        {
            //Debug.Log("slime attack");
            animator.SetTrigger("attack");
        }
    }
    public void slimeattackone()
    {

    }
    public void slimeattacktwo()
    {
        gameObject.tag = "EnemyAttack";
    }
    public void slimeattackthree()
    {
        gameObject.tag = "Enemy";
    }
    public void slimeattackend()
    {
        
    }
}
