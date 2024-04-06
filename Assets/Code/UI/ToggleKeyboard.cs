using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleKeyboard : MonoBehaviour
{
    Toggle toggle;
    //float cooldown;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggle.isOn = !toggle.isOn;
        }
    }
}
