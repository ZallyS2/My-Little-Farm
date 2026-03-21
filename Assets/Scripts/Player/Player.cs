using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] private float runSpeed;

    private float initialSpeed;
    
    
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;


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



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 5f;
        initialSpeed = speed;
        runSpeed = speed * 3;
        _isRolling = false;
        _isRunning = false;
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
            speed = runSpeed * 2;
            _isRolling = true;
        }
        else
        {
            _isRolling = false;
        }
        
    }


    void OnCutting()
    {
        if(Mouse.current.leftButton.isPressed)
        {
            _isCutting = true;
            speed = 0;
        }
        else
        {
            _isCutting = false;
            speed = initialSpeed;
        }
    }

    #endregion
}