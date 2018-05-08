using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Clickable : MonoBehaviour
{
    //The event that should be triggered when clicked
    [Tooltip("The event that should be triggered when clicked")]
    [SerializeField]
    private UnityEvent onClick;
    [Tooltip("Sould the item glow when hovered over?")]
    [SerializeField]
    private bool hoverGlow = true;
    private bool hovered = false;
    private Transform controllerTipMainHand;
    private Collider col;

    private void Awake()
    {
        controllerTipMainHand = GameObject.Find("Player/SteamVRObjects" + "Hand1" + "/Attach_ControllerTip").transform;
        col = GetComponent<Collider>();
    }

    private void OnMouseDown()
    {
        onClick.Invoke();
        Debug.Log("Clicked " + gameObject.name + "!");
    }

    private void Update()
    {
        if(col.bounds.Contains(controllerTipMainHand.position))
        {
            if(!hovered)
            {
                Debug.Log("Entered " + name);
                hovered = true;
            }
            return;
        }
        if(hovered)
        {
            hovered = false;
            Debug.Log("Exited " + name);
        }

    }

}