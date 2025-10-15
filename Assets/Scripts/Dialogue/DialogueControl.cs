using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour {
    [Header("Components")]
    public GameObject dialogueObj; // Janela do dialogo
    public Image profileSprite; // Imagem do personagem
    public Text actorName; // Nome do personagem
    public Text dialogueText; // Texto do dialogo

    [Header("Settings")]
    public float typingSpeed = 0.02f; // Velocidade da fala

    // Variaveis de controle
    private bool isDialogueActive = false; // Verifica se o dialogo esta ativo
    private int index = 0; // Indice da frase atual
    private string[] setences; // Letra do dialogo

    void Start() {

    }

    void Update() {

    }

    IEnumerator Type() {
        foreach (char letter in setences[index].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence() {

    }

    public void Speech(string[] txt) {
        if (!isDialogueActive) {
            dialogueObj.SetActive(true);
            setences = txt;
            StartCoroutine(Type());
            isDialogueActive = true;
        }
    }
}
