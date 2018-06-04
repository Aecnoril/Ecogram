using Assets.scripts.backend.character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerViewport : MonoBehaviour
{

    [SerializeField]
    private Transform cameraTransform;

    private bool isHit = false;
    public Character selectedCharacter;

    // Use this for initialization
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 50, LayerMask.GetMask("ViewportRay")))
        {
            if (hit.collider.gameObject.tag == "Character")
            {
                OpenCharacter(hit.collider.gameObject.GetComponent<Character>());
                Debug.DrawLine(cameraTransform.position, hit.point, Color.red, Time.deltaTime);
                return;
            }
        }
        CloseCharacter();

    }

    private void OpenCharacter(Character character)
    {
        if (selectedCharacter == character)
            return;
        CloseCharacter();
        selectedCharacter = character;
        character.OpenCharacter();
    }

    private void CloseCharacter()
    {
        if (selectedCharacter != null)
            selectedCharacter.CloseCharacter();
    }
}
