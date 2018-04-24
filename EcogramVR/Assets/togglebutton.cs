using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togglebutton : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " was triggered by " + other.gameObject.name);
    }
}
