using UnityEngine;

public class blocked : MonoBehaviour
{
    private test testscript;
    private Animator animator = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        testscript = player.GetComponent<test>();
        Debug.Log("block created");
        animator = GetComponent<Animator>();
        animator.SetTrigger("BlockedFX");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testscript != null && !testscript.isBloking)
        {
            Destroy(gameObject);
        }
    }
}
