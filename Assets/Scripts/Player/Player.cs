using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] private float runSpeed;

    private float initialSpeed;

    private int _handlingObj;
    
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;
    private bool _isAttack;
    private bool _isDead;

    private float _currentHealth;
    private float _maxHealth;
    public UnityEngine.UI.Image healthBar;

    private Itens playerIntens;


    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 _move;
   
    
    
    
    
    
    public Vector2 move
    {
        get {return _move;} 
        set {_move = value;}
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool IsDigging { get => _isDigging; set => _isDigging = value; }
    public bool IsWatering { get => _isWatering; set => _isWatering = value; }
    public int HandlingObj { get => _handlingObj; set => _handlingObj = value; }
    public bool IsAttack { get => _isAttack; set => _isAttack = value; }
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public bool IsDead { get => _isDead; set => _isDead = value; }

    private void Awake()
    {

        //componentes
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerIntens = GetComponent<Itens>();

    }
    private void Start()
    {
        //vida
        _maxHealth = 10f;
        _currentHealth = _maxHealth;


        //Velocidade
        speed = 5f;
        initialSpeed = speed;
        runSpeed = speed * 3;
        

        //Metodos/Ações
        _isRunning = false;
        _isRolling = false;
        _isCutting = false;
        _isDigging = false;
        _isWatering = false;
        _isAttack = false;
        _isDead = false;

        _handlingObj = 0;
    }

    void Update()
    {
        PlayerMethods();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = _move * speed;
    }


    void PlayerMethods()
    {
        ReadInput();
        OnRun();
        OnRolling();
        OnCutting();
        OnDigging();
        OnWatering();
        OnAttack();


        HandObject();
    }

    void HandObject()
    {
        if(Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            _handlingObj = 1;
            Debug.Log("Apertou 1 | Machado");
        }
        if(Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            _handlingObj = 2;
            Debug.Log("Apertou 2 | Pá");
        }
        if(Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            _handlingObj = 3;
            Debug.Log("Apertou 3 | Picareta");
        }
        if(Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            _handlingObj = 4;
            Debug.Log("Apertou 4 | Espada");
        }
        if(Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            _handlingObj = 5;
            Debug.Log("Apertou 5 | Varinha");
        }
        if(Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            _handlingObj = 6;
            Debug.Log("Apertou 6 | Regador");
        }

    }

    public void Die()
    {
        Invoke("GameOver", 3f); // espera 2 segundos
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


    #region Movement

    void ReadInput()
    {
        move = Vector2.zero;

        if(Keyboard.current != null)
        {
            if(Keyboard.current.wKey.isPressed)
                _move.y += 1;

            if(Keyboard.current.sKey.isPressed)
                _move.y -= 1;

            if(Keyboard.current.aKey.isPressed)
                _move.x -= 1;

            if(Keyboard.current.dKey.isPressed)
                _move.x += 1;
        }

        _move = _move.normalized;

    }

    void OnRun()
    {
       
        if(Keyboard.current.leftShiftKey.isPressed)
        {
            speed = runSpeed;
            _isRunning = true;
        }
        else
        {
            speed = initialSpeed;
            _isRunning = false;
        }
        

    }

    void OnRolling()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            speed = runSpeed * 3;
            _isRolling = true;
        }
        else
        {
            _isRolling = false;
        }
        
    }


    void OnCutting()
    {
        if(Mouse.current.leftButton.isPressed && _handlingObj == 1)
        {
            _isCutting = true;
            Stopping();
        }
        else
        {
            _isCutting = false;
            speed = initialSpeed;
        }
    }

    void OnAttack()
    {
        if(Mouse.current.leftButton.isPressed && _handlingObj == 4)
        {
            _isAttack = true;
            Stopping();
        }
        else
        {
            _isAttack = false;
            speed = initialSpeed;
        }
    }


    void OnDigging()
    {
        if(Mouse.current.leftButton.isPressed && _handlingObj == 2)
        {
            _isDigging = true;
            Stopping();
        }
        else
        {
            _isDigging = false;
            speed = initialSpeed;
        }
    }

    void OnWatering()
    {
        if(Mouse.current.leftButton.isPressed && _handlingObj == 6 && playerIntens.currentWater > 0)
        {
            _isWatering = true;
            Stopping();
            playerIntens.currentWater-= 0.5f;
        }
        else
        {
            _isWatering = false;
            speed = initialSpeed;
        }
    }



    void Stopping()
    {
        speed = 0f;
    }

    
    #endregion



}