using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleReverse : MonoBehaviour
{
    Toggle toggle;
    [SerializeField] List<GameObject> toggleObjects;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(ToggleObjects);
    }

    void ToggleObjects(bool isOn)
    {
        foreach(GameObject obj in toggleObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
    
}
