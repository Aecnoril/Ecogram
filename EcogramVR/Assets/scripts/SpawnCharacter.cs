using Assets.scripts.Backend;
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
            CharacterManager.instance.CreateCharacter(Spawnpoint.position, Spawnpoint.rotation);
        }

        CooldownStart = Time.time;
    }
}
