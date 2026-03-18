using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcDialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;
    private bool playerHit;

    public DialogueSettings dialogue;

    private List<string> sentences = new List<string>();

    void Start()
    {
        GetNPCInfos();
    }

    void Update()
    {
        // Só abre se o player estiver no raio
        if(playerHit && Keyboard.current.eKey.wasPressedThisFrame)
        {
            DialogueControl.instance.Speech(dialogue.name, dialogue.speakerSprite, sentences.ToArray());
        }

        // Se saiu do raio, fecha o diálogo
        if(!playerHit && DialogueControl.instance != null)
        {
            DialogueControl.instance.EndDialogue();
        }
    }

    void GetNPCInfos()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {

            switch(DialogueControl.instance.language)
            {
                case DialogueControl.idioms.pt:
                    sentences.Add(dialogue.dialogues[i].lenguages.portuguese);
                    break;

                case DialogueControl.idioms.en:
                    sentences.Add(dialogue.dialogues[i].lenguages.english);
                    break;
            }
                
               
            
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }


    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if(hit != null)
        {
            //Debug.Log("Player in range, show dialogue");
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
