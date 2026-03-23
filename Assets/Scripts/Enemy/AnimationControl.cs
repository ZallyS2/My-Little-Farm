using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;



    [SerializeField] private Player player;
    [SerializeField] private Skeleton skeleton;
    [SerializeField] private PlayerAnim playerAnim;
    [SerializeField] private Animator anim;

    void Awake()
    {
        playerAnim = player.GetComponent<PlayerAnim>();

        player = FindObjectOfType<Player>();
        if(skeleton == null)
            skeleton = GetComponentInParent<Skeleton>();

        if(anim == null)
            anim = GetComponent<Animator>();

        
            

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayAnim(int value)
    {
        anim.SetInteger("Transitions", value);
    }

    public void Attack()
    {
        if(skeleton.isDead == false)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPoint.transform.position, radius, playerLayer);

            if(hit != null && !player.IsDead)
            {
                //detecta colisão com player
                //Debug.Log("DANO no player");
                playerAnim.OnHurt();


            }
        }
        
    }

    public void OnHit()
    {
        if(skeleton.isDead == false)
        {
            anim.SetTrigger("Hit");
            skeleton.currentHealth--;
            skeleton.healthBar.fillAmount = skeleton.currentHealth / skeleton.maxHealth;
        }
        if(skeleton.currentHealth <= 0)
        {
            anim.SetTrigger("Death");
            skeleton.IsDead();
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

}

