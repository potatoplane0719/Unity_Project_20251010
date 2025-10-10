using UnityEngine;

public class wizardHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;
    private wizard isattacking;
    void Start()
    {
        isattacking = GetComponent<wizard>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack" && !isattacking.wizardattacking)
        {
            Debug.Log("wizard get hit!");
            animator.SetTrigger("wizardhit");
            GetComponent<SpriteRenderer>().color =Color.red;
        }
    }
    public void wizardHitstart()
    {
        
    }
    public void wizardHitend()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
