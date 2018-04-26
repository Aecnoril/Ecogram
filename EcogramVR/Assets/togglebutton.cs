using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(gameObject.name + " was triggered by " + col.gameObject.name);
    }
}

