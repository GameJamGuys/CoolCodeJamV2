using System.Collections;
using System.Collections.Generic;
using Characters;
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
        VictimManager.OnKilled(GetComponent<Character>());
        
        this.enabled = false;
    }
}
