using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public float speed;
    public float initialSpeed;
    private int index;
    public List<Transform> paths = new List<Transform>();

    private Animator anim;

    void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        FollowPath();
    }


    void FollowPath()
    {
        if(DialogueControl.instance.IsShowing)
        {
            speed = 0f;
            anim.SetBool("IsWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("IsWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
            if(index < paths.Count - 1)
            {
                index++;

                //deixar random
                //index = Random.Range(0, paths.Count - 1);
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;
        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
