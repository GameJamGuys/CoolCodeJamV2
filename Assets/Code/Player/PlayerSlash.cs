using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    [SerializeField]
    PlayerSwitcher switcher;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!switcher.darkMode)
        {
            if(collision.TryGetComponent(out GetKilled mob))
            {
                mob.Killed();
            }
        }
    }
}
