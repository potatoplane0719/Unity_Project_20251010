using NUnit.Framework;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator = null;
    public bool isAttacking = false;
    public PlayerAttackBox playerAttackBox;
    public Transform AttackOffset;
    public test test;
    //public Animator animator ;
    void Start()
    {
        test = GetComponent<test>();
        
    }

    // Update is called once per frame
    public void Update()
    {
       
        
    }

    public void playerattack()
    {
        
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            //Debug.Log("attack");

            animator.SetTrigger("attack");
        }
        
    }

    public void lightattackone()
    {
           
           isAttacking = true;
           Debug.Log("isAttacking: " + isAttacking);
           //TogglePolygonColliderTrigger(true);
    }
    public void lightattacktwo()
    {
        var box = Instantiate(playerAttackBox, AttackOffset.position, AttackOffset.rotation);

        box.transform.parent = test.transform;

        box.transform.localScale = new Vector3(
        Mathf.Abs(box.transform.localScale.x) * test.Face,
        box.transform.localScale.y,
        box.transform.localScale.z
        );
           //^what the fuck is this
    }
    public void lightattackend()
    {
           
    
           //TogglePolygonColliderTrigger(false);
    }
    public void lightattackend2()
    {

        isAttacking = false;
        Debug.Log("isAttacking: " + isAttacking);
        test.isJumping = false;
        test.canMove = true;
    }
    
    // Toggles the 'Is Trigger' property of the PolygonCollider2D component
    public void TogglePolygonColliderTrigger(bool PolygonColliderTrigger)
    {
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        if (collider != null)
        {
            collider.isTrigger = !PolygonColliderTrigger;
            //Debug.Log($"PolygonCollider2D isTrigger set to {collider.isTrigger}");
        }
    }
}
