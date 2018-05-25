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
        RaycastHit hit;
        Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 50);
        if (hit.collider == viewportHitbox)
            isHit = true;
        else
            isHit = false;

        enabledObjects.SetActive(isHit);
	}
}
