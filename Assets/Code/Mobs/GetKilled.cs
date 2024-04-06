using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;

public class GetKilled : MonoBehaviour
{
    public bool isDead = false;

    [SerializeField] GameObject skull;
    [SerializeField] CowController moveControl;

    Collider2D coll;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
    }

    public void Killed()
    {
        isDead = true;
        coll.enabled = false;
        anim.SetTrigger("dead");
        skull.SetActive(true);
        moveControl.MoveBody(Vector2.zero);
        moveControl.enabled = false;
        VictimManager.OnKilled(GetComponent<Character>());
        
        this.enabled = false;
    }
}
