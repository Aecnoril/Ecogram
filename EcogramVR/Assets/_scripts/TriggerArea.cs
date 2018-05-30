using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour {

    public UnityEvent onTrigger;

    private Collider triggerArea;
	// Use this for initialization
	void Start () {
        triggerArea = GetComponent<Collider>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            onTrigger.Invoke();
    }
}
