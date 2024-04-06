using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKilled : MonoBehaviour
{
    [SerializeField] GameObject skull;
    [SerializeField] CowController moveControl;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Killed()
    {
        anim.SetTrigger("dead");
        skull.SetActive(true);
        moveControl.enabled = false;
        
        this.enabled = false;
    }
}
