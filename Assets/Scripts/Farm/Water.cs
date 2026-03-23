using UnityEngine;
using UnityEngine.InputSystem;

public class Water : MonoBehaviour
{
    private int waterValeu;

    private bool detectingPlayer;
    private Itens playerItens;

    void Start()
    {
        playerItens = FindObjectOfType<Itens>();
        waterValeu = 1;
    }

    void Update()
    {
        if(detectingPlayer && Keyboard.current.eKey.isPressed)
        {
            playerItens.WaterLimit(waterValeu);
            Debug.Log("Player pegou a água");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = true;
            Debug.Log("Player chegou perto da água");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detectingPlayer = false;
        Debug.Log("Player saiu de perto da água");
    }
}
