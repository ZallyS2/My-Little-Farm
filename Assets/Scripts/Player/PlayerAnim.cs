using UnityEngine;
using UnityEditor;

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
        OnMove();
        OnRun();
    }

    #region Movement
    public void OnMove() {

        if (player.direction.sqrMagnitude > 0) {
            if(player.isRolling) {
                anim.SetTrigger("IsRoll");
                player.isRolling = false;
            } else {
                anim.SetInteger("Transition", 1);
            }
        } else {
            anim.SetInteger("Transition", 0);
        }

        if (player.direction.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0) {
            transform.eulerAngles = new Vector2(0, 180);
        }

    }

    public void OnRun() {
        if (player.isRunning) {
            anim.SetInteger("Transition", 2);
        }
    }

    #endregion
}
