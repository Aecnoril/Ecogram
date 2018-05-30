using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    private Toggle AssignedButton; //private field, class is toggle,(togglebutton-on/off), naam is assignedbutton

    private void Awake() //awake start direct als de game 
    {
        AssignedButton = gameObject.GetComponent<Toggle>(); // pakt eerste gameobject wat een toggle is. dus de toggle waar je op klikt.
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(AssignedButton + "dit is de toggle button"); // check of assignedbutton wel vindbaar is. 

        AssignedButton.isOn = !AssignedButton.isOn;   //assisnged button wordt wat assigned button niet is. als hij niet aan is wordt hij aan)
    }
}

