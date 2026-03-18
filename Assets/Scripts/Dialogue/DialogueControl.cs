using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idioms
    {
        pt,
        en
    }

    public idioms language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profilesprite;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;


    [Header("Settings")]
    public float typingSpeed;
    private bool isShowing;
    private int index;
    private string[] sentences;
    private Coroutine typingCoroutine;

    public static DialogueControl instance;

    private void Awake()
    {
        //if(instance == null)
        //{
        instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        // Se ainda está digitando → completa a frase
        if(speechText.text != sentences[index])
        {
            if(typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            speechText.text = sentences[index];
            return;
        }

        // Se já terminou → próxima frase
        if(index < sentences.Length - 1)
        {
            index++;
            speechText.text = "";
            typingCoroutine = StartCoroutine(TypeSentence());
        }
        else
        {
            EndDialogue();
        }
    }

    public void Speech(string actorName, Sprite actorSprite, string[] txt)
    {
        if(!isShowing)
        {
            dialogueObj.SetActive(true);

            actorNameText.text = actorName;
            profilesprite.sprite = actorSprite;

            sentences = txt;
            index = 0;
            isShowing = true;

            typingCoroutine = StartCoroutine(TypeSentence());
        }
    }

    public void EndDialogue()
    {
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        speechText.text = "";
        actorNameText.text = "";
        profilesprite.sprite = null;
        index = 0;
        dialogueObj.SetActive(false);
        isShowing = false;
    }
}
