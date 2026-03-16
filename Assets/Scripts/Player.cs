using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] private float runSpeed;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
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



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialSpeed = speed;
        runSpeed = speed * 2;
        _isRolling = false;
        _isRunning = false;
    }

    void Update()
    {
        _isRunning = false;
        ReadInput();
        OnRun();
        OnRolling();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = _move * speed;
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
            speed = runSpeed;
            _isRolling = true;
        }
        else
        {
            _isRolling = false;
        }
        
    }

    #endregion
}