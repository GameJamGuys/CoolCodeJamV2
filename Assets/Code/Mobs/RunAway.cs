using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    [SerializeField] CowController control;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            print("Run!");
            RunFrom(collision.transform);
        }
    }

    void RunFrom(Transform target)
    {
        Vector2 dir = (transform.position - target.position).normalized;

        control.RunBoyy(dir);
        //print(dir);
    }
}
