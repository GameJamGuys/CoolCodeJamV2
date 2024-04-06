using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] float speed = 0;

    [Range(0, 3)]
    [SerializeField] float minDelay = 0.7f;

    [Range(3, 10)]
    [SerializeField] float maxDelay = 5f;

    //Animator anim;
    SpriteRenderer sprite;
    Rigidbody2D body;
    bool isRun;

    Vector2 runDir;

    void Start()
    {
        //anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

        WalkAround();
        isRun = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isRun) return;
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Box"))
        {
            Vector2 collDir = collision.relativeVelocity;
            runDir = new Vector2(
                Random.Range(-0.5f, 0.5f),
                Random.Range(-0.5f, 0.5f)).normalized;

            float shiftspeed = speed + Random.Range(-0.1f, 0.1f);
            body.velocity = (collDir + runDir) * shiftspeed;

            isRun = true;
            SayMoo();
        }
        
    }

    async void WalkAround()
    {
        await Timer.Wait(Random.Range(minDelay, maxDelay));
        if (!body) return;

        Vector2 walkDir = new Vector2(
                Random.Range(-0.8f, 0.8f),
                Random.Range(-0.8f, 0.8f)).normalized;

        float shiftspeed = Random.Range(0.8f, 1f);

        body.velocity = walkDir * shiftspeed;
        //print("Cow walk");
        //SayMoo();

        WalkAround();
    }

    void SayMoo()
    {
        int moo = Random.Range(4, 7);
        //AudioManager.Instance.PlaySound($"Moo{moo}");
    }

    void Update()
    {
        if(body.velocity.magnitude > 0.1)
        {
            FlipUpdate(body.velocity.x);
            //anim.SetBool("Run", true);
        }
        else
        {
            isRun = false;
            //anim.SetBool("Run", false);
            body.velocity = Vector2.zero;
        }
    }

    public void FlipUpdate(float horizontal)
    {
        if (horizontal < 0) sprite.flipX = true;
        if (horizontal > 0) sprite.flipX = false;
    }

}
