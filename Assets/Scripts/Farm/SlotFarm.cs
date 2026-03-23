using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlotFarm : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    


    [Header("Setting")]
    private bool detecting;
    [SerializeField] private int digAmount; //tempo de escavação

    private float waterAmount; // quanta agua precisa pra nascer a cenoura
    private float currentWater;

    private int initialDigAmount;
    private bool isDigging = false;
    private bool dugHole;


    [SerializeField] private GameObject carrotPrefab;

    void Start()
    {

        dugHole = false;
        initialDigAmount = digAmount;
        waterAmount = 5;

    }

    void Update()
    {
        if(dugHole)
        {
            if(detecting)
            {
                currentWater += 0.05f;

            }
            if(currentWater >= waterAmount)
            {
                spriteRenderer.sprite = carrot;

                if(Keyboard.current.eKey.isPressed)
                {
                    spriteRenderer.sprite = hole;
                    Instantiate(carrotPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
                    currentWater = 0f;
                }
            }
        }
    }

    void OnHit()
    {
        digAmount--;

        if(digAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dig") && !isDigging)
        {
            OnHit();
        }
        if(collision.CompareTag("Water"))
        {
            Debug.Log("Player colocou agua");
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Water"))
        {
            detecting = false;
        }
    }
}
