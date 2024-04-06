using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKilled : MonoBehaviour
{
    [SerializeField] GameObject skull;
    [SerializeField] CowController moveControl;

    public void Killed()
    {
        skull.SetActive(true);
        moveControl.enabled = false;
    }
}
