using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour {

    public Transform Spawnpoint;
    public GameObject characterPrefab;
    public GameObject spinnerPrefab;

    private float CooldownStart = 0f;
    private float Cooldown = 2f;

    // Use this for initialization
    void OnTriggerExit() {

        if (Time.time > CooldownStart + Cooldown)
        {
            InitializeCharacter();
        }

        CooldownStart = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitializeCharacter()
    {
        Instantiate(characterPrefab, Spawnpoint.position, Spawnpoint.rotation);
    }
}
