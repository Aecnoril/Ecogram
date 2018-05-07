using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Clickable : MonoBehaviour {

    //The event that should be triggered when clicked
    [Tooltip("The event that should be triggered when clicked")]
    [SerializeField]
    private UnityEvent onClick;
    [Tooltip("Sould the item glow when hovered over?")]
    [SerializeField]
    private bool hoverGlow = true;

    private void OnMouseDown()
    {
        onClick.Invoke();
        Debug.Log("Clicked " + gameObject.name + "!");
    }
}