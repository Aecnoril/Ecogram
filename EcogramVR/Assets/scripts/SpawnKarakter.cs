using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKarakter : MonoBehaviour {

    public Transform Spawnpoint;
    public GameObject Prefab;

    private float CooldownStart = 0f;
    private float Cooldown = 2f;

    // Use this for initialization
    void OnTriggerExit() {

        if (Time.time > CooldownStart + Cooldown)
        {

            Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);

        }

        CooldownStart = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
