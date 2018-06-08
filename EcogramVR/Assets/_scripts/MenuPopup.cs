using Assets.scripts.backend.character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MenuPopup : MonoBehaviour {

    Camera mainCam;
    public float menuDistance = 0.5f;
    public float menuOffsetX = 0.5f;
    public float menuOffsetY = 0.5f;

    public float smoothSpeed = 0.1f;

    private Collider trigger;
    private Character character;
    private GameObject menu;

    private bool playerNear = false;

    // Use this for initialization
    void Start () {
        mainCam = Camera.main;
        trigger = gameObject.GetComponent<Collider>();
        character = gameObject.GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {

        if (trigger.bounds.Contains(mainCam.transform.position))
        {
            playerNear = true;
            character.Menu.SetActive(true);
        }
        else
        {
            playerNear = false;
            character.Menu.SetActive(false);
        }

        if (playerNear)
        {
            Vector3 newPos = mainCam.transform.position;
            newPos += mainCam.transform.forward * menuDistance;
            newPos += mainCam.transform.up * menuOffsetY;
            newPos += mainCam.transform.right * menuOffsetX;
            character.Menu.transform.position = Vector3.Lerp(character.Menu.transform.position, newPos, Time.deltaTime * smoothSpeed);
        }
		
	}
}
