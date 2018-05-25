using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewport : MonoBehaviour {

    [SerializeField]
    private Collider viewportHitbox;
    [SerializeField]
    private GameObject enabledObjects;

    private Transform cameraTransform;

    private bool isHit = false;

	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;

        if (viewportHitbox == null)
            viewportHitbox = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, 50))
            isHit = true;
        else
            isHit = false;

            enabledObjects.SetActive(isHit);
	}
}
