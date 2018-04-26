using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    private Toggle AssignedButton;

    private void Awake()
    {
        AssignedButton = gameObject.GetComponent<Toggle>();
    }

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log(gameObject.name + " was triggered by " + col.gameObject.name);
        
        AssignedButton.onValueChanged.Invoke(true);
    }
}

