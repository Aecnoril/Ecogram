using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    private Toggle AssignedButton;

    private void Awake() //awake start direct als de game 
    {
        AssignedButton = gameObject.GetComponent<Toggle>();
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(AssignedButton + "dit is de toggle button"); // check of assignedbutton wel vindbaar is. 

        AssignedButton.isOn = !AssignedButton.isOn;   //assinged button wordt wat assigned button niet is. als hij niet aan is wordt hij aan)
    }
}