using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;


    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        LateUpdate();
        Animations();
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
    }


    #endregion
}