using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    private NavMeshAgent agent;
    private Player player;
    [SerializeField] private AnimationControl animControl;
    public UnityEngine.UI.Image healthBar;

    [SerializeField] private float speed = 2f;
    private float _currentHealth;
    private float _maxHealth;

    [HideInInspector] public bool isDead;

    [SerializeField] private Transform combatPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    public List<Transform> paths = new List<Transform>();
    private int index;

    public float currentHealth { get => _currentHealth; set => _currentHealth = value; }
    public float maxHealth { get => _maxHealth; set => _maxHealth = value; }

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        _maxHealth = 10f;
        _currentHealth = _maxHealth;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        isDead = false;
    }

    void Update()
    {
        if(isDead == false)
        {
            Enemy();
        }
    }

    public void IsDead()
    {
        isDead = true;
        Destroy(gameObject, 3f);
    }

    void Enemy()
    {
        Collider2D hit = Physics2D.OverlapCircle(combatPoint.transform.position, radius, playerLayer);

        if(hit != null)
        {
            agent.SetDestination(player.transform.position);

            float distance = Vector2.Distance(transform.position, player.transform.position);

            if(distance <= agent.stoppingDistance && !player.IsDead)
            {
                animControl.PlayAnim(3); // ataque
            }
            else if(agent.velocity.sqrMagnitude > 0.01f)
            {
                animControl.PlayAnim(2); // andando
            }
            else
            {
                animControl.PlayAnim(1); // parado
            }

            float posX = player.transform.position.x - transform.position.x;

            if(posX > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            if(posX < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
        else
        {
            if(paths.Count > 0)
            {
                agent.ResetPath();

                transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

                if(Vector2.Distance(transform.position, paths[index].position) < 0.1f)
                {
                    if(index < paths.Count - 1)
                    {
                        index++;

                        // deixar random
                        // index = Random.Range(0, paths.Count - 1);
                    }
                    else
                    {
                        index = 0;
                    }
                }

                if(Vector2.Distance(transform.position, paths[index].position) > 0.1f)
                {
                    animControl.PlayAnim(2); // andando
                }
                else
                {
                    animControl.PlayAnim(1); // parado
                }

                float posX = paths[index].position.x - transform.position.x;

                if(posX > 0)
                {
                    transform.eulerAngles = new Vector2(0, 0);
                }
                if(posX < 0)
                {
                    transform.eulerAngles = new Vector2(0, 180);
                }
            }
            else
            {
                animControl.PlayAnim(1); // parado
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(combatPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(combatPoint.transform.position, radius);
    }
}