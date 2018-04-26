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
        Debug.Log(gameObject.name + " was triggered by " + col.gameObject.name);
        Debug.Log(AssignedButton + "dit is de toggle button"); // check of assignedbutton wel vindbaar is. 
        AssignedButton.isOn = !AssignedButton.isOn;   //assisnged button wordt wat assigned button niet is. dus uit is aan en aan is uit. 
    }
}
