using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerMask;


    void Start()
    {
        
    }
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerMask);

        if (hit != null) {
            Debug.Log("Player in range");
        } else {

        }
    }


    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

}
