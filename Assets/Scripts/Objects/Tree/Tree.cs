using UnityEngine;

public class Tree : MonoBehaviour
{
    private float treeHealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab;
    private int totalWood;

    [SerializeField] private ParticleSystem leafs;

    private bool isCutting = false;

    void Start()
    {
        totalWood = Random.Range(1, 5);
        treeHealth = Random.Range(2, 5);
    }

    void Update()
    {
        
    }

    void OnHit()
    {
        treeHealth--;
        anim.SetTrigger("Hit");
        leafs.Play();


        if(treeHealth <= 0)
        {
            
            anim.SetTrigger("Cut");
            for(int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
            }

            isCutting = true;


        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Axe") && !isCutting)
        {
            OnHit();  
        }
    }
}
