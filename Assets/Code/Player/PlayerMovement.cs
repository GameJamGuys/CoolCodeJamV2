using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    float horizontal;
    float vertical;

    Vector2 inputVector;

    Rigidbody2D rb2d;

    public Vector2 LastDir;

    //[HideInInspector]
    //public bool isMove;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SetInput(Vector2 input) => inputVector = input;

    void FixedUpdate()
    {
        horizontal = inputVector.x;
        vertical = inputVector.y;

        Vector2 moveDir = new Vector2(horizontal, vertical).normalized;
        if (moveDir != Vector2.zero)
        {
            LastDir = moveDir;
            //AudioManager.Instance.PlaySound("Foot");
            //rb2d.AddForce(moveDir * speed * Time.fixedDeltaTime);
        }
        else
        {
            //rb2d.velocity = Vector2.zero;
        }
            


        //Vector2 position = rb2d.position;
        //position += moveDir * speed * Time.fixedDeltaTime;
        //rb2d.MovePosition(position);

        rb2d.velocity = moveDir * speed;

        
    }
}
