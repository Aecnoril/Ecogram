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
    [Tooltip("The trigger area, if multiple colliders present")]
    [SerializeField]
    private Collider col;
    [Tooltip("Name of the hand gameobject that should trigger the area")]
    [SerializeField]
    private string dominantHand = "Hand1";
    private bool hovered = false;
    private Transform controllerTipMainHand;


    private void Awake()
    {
        controllerTipMainHand = GameObject.Find("Player/SteamVRObjects" + dominantHand + "/Attach_ControllerTip").transform;
        if (col = null)
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