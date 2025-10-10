using UnityEngine;

public class PlayerAttackBox : MonoBehaviour
{
    private attack Mattack;
    void Start()
    {
        
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            //Debug.Log("Found player: " + player.name);
            Mattack = player.GetComponent<attack>();
            if (Mattack == null)
                Debug.LogWarning("attack script not found on Player!");
        }
        else
        {
            Debug.LogWarning("Player GameObject not found by tag!");
        }
    }

    void Update()
    {
        if (Mattack != null && Mattack.isAttacking == false)
        {
            
            Destroy(gameObject);
        }
    }
}