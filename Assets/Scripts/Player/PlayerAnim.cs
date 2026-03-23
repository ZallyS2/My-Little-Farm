using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;



    private Player player;
    private Animator anim;

    private bool isHitting;
    private float timeCount;
    private float recoveryTime = 1f;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        LateUpdate();
        Animations();

        if(isHitting)
        {
            timeCount += Time.deltaTime;
            if(timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }
    }


    #region Animation
    void LateUpdate()
    {
        if(player.move.sqrMagnitude > 0)
        {
            anim.SetInteger("Transitions", 1);
        }
        else
        {
            anim.SetInteger("Transitions", 0);
        }


        if(player.move.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(player.move.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }


    }

    void Animations()
    {
        if(player.isRunning)
        {
            anim.SetInteger("Transitions", 2);
        }

        if(player.isRolling)
        {
            anim.SetTrigger("IsRoll");
        }

        if(player.isCutting)
        {
            anim.SetInteger("Transitions", 3);
        }

        if(player.IsDigging)
        {
            anim.SetInteger("Transitions", 4);
        }

        if(player.IsWatering)
        {
            anim.SetInteger("Transitions", 5);
        }

        if(player.IsAttack)
        {
            anim.SetInteger("Transitions", 6);
        }

    }
    public void OnHurt()
    {
        if(!isHitting && !player.IsDead)
        {
            anim.SetTrigger("IsHurt");
            isHitting = true;
            player.CurrentHealth--;
            player.healthBar.fillAmount = player.CurrentHealth / player.MaxHealth;
        }
        if(player.CurrentHealth <= 0)
        {
            player.IsDead = true;
            anim.SetTrigger("IsDead");
            isHitting = false;
            player.Die();
        }
    }

    #endregion


    #region Attack
    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.transform.position, radius, enemyLayer);
        if(hit != null)
        {
            //Debug.Log("Atacando inimigo");
            hit.GetComponentInChildren<AnimationControl>().OnHit();
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
    #endregion

}