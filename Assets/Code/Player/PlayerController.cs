using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fullSpeed = 1f;
    public float heavySpeed = 0.5f;
    [Space]
    public float interactCooldown = 0.3f;
    [Space]

    [SerializeField] PlayerMovement movement;
    //[SerializeField] PlayerVisual visual;
    //[SerializeField] BoxHandler handler;
    [Space]
    bool isMobile;

    public bool GameEnd;

    Vector2 moveInput;
    //FloatingJoystick joystick;

    void Start()
    {
        //handler.cooldown = interactCooldown;
        //BoxInteract(false);

        //if (isMobile)
            //GameObject.FindGameObjectWithTag("joystick").TryGetComponent(out joystick);
    }

    /*
    private void OnEnable()
    {
        //handler.OnBoxInteract += BoxInteract;
    }

    private void OnDisable()
    {
        //handler.OnBoxInteract -= BoxInteract;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out CowController cow))
        {
            handler.DropBox();
        }
    }
    */

    void Update()
    {
        if (GameEnd)
            return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            //PickUp();
        }

        moveInput = HandleInput();

        HandleMovement(moveInput);
        HandleHandler(moveInput);
        //HandleVisual(moveInput);
    }

    //public void PickUp() => handler.Interaction();

    Vector2 HandleInput()
    {
        Vector2 input = new Vector2();
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        /*
        if (joystick)
        {
            input.x += joystick.Horizontal;
            input.y += joystick.Vertical;
        }
        */

        return input;
    }

    void HandleMovement(Vector2 moveInput)
    {
        movement.SetInput(moveInput);
    }

    void HandleHandler(Vector2 moveInput)
    {
        Vector2 moveDir = moveInput.normalized;
        //if (moveDir != Vector2.zero)
            //handler.lastDir = moveDir;
    }

    void HandleVisual(Vector2 moveInput)
    {
        float move = Mathf.Abs(moveInput.x) + Mathf.Abs(moveInput.y);
        float moveX = Mathf.Abs(moveInput.x);
        float moveY = moveInput.y;

        //visual.AnimSet(move, moveX, moveY);
        //visual.FlipUpdate(moveInput.x);
    }

    void BoxInteract(bool isTake)
    {
        if (isTake)
            movement.speed *= heavySpeed;
        else
            movement.speed *= fullSpeed;
    }
}
