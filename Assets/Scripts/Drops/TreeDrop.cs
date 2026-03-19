using UnityEngine;

public class TreeDrop : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;

    void Start()
    {
        
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount < timeMove )
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Itens>().totalWoods += 1;
            Destroy(gameObject);
        }
    }
}
