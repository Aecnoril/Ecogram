using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Hand1"))
        {
            Debug.Log("WELKOM BOI");
        }
    }
}
