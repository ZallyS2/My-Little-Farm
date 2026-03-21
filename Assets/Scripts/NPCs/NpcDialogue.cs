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

    private static NpcDialogue currentNpc;

    void Start()
    {
        GetNPCInfos();
    }

    void Update()
    {
        if(DialogueControl.instance == null)
            return;

        // Apertou E dentro do range
        if(playerHit && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            // Se não tem diálogo aberto, esse NPC abre
            if(!DialogueControl.instance.IsShowing)
            {
                currentNpc = this;
                DialogueControl.instance.Speech(dialogue.name, dialogue.speakerSprite, sentences.ToArray());
            }
            // Se já tem diálogo aberto, só o NPC atual pode avançar
            else if(currentNpc == this)
            {
                DialogueControl.instance.NextSentence();
            }
        }

        // Só fecha se ESTE NPC for o dono do diálogo e o player sair do range
        if(!playerHit && DialogueControl.instance.IsShowing && currentNpc == this)
        {
            DialogueControl.instance.EndDialogue();
            currentNpc = null;
        }

        // Segurança: se o diálogo fechou por outro motivo, limpa o currentNpc
        if(!DialogueControl.instance.IsShowing && currentNpc == this)
        {
            currentNpc = null;
        }
    }

    void GetNPCInfos()
    {
        sentences.Clear();

        if(DialogueControl.instance == null || dialogue == null)
            return;

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
        playerHit = hit != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}