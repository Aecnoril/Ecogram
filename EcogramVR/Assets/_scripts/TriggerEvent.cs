using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("GameController"))
        {
            Debug.Log("WELKOM BOI");
        }
    }
}
