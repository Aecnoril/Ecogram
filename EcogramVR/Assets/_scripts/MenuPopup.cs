using Assets.scripts.backend.character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Text charName;
    private Text charEmotion;
    private Text charSupport;
    private Text charTheme;


    private bool playerNear = false;

    // Use this for initialization
    void Start () {

        mainCam = Camera.main;
        trigger = gameObject.GetComponent<Collider>();
        character = gameObject.GetComponent<Character>();
	}

    private void Awake()
    {
        charName = GameObject.Find("PlayerBook/MenuGroup/Menu_Info/Name/Text").GetComponent<Text>();
        charEmotion = GameObject.Find("PlayerBook/MenuGroup/Menu_Info/Emotion/Text").GetComponentInChildren<Text>();
        charSupport = GameObject.Find("PlayerBook/MenuGroup/Menu_Info/Support/Text").GetComponentInChildren<Text>();
        charTheme = GameObject.Find("PlayerBook/MenuGroup/Menu_Info/Theme/Text").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update () {

        if (trigger.bounds.Contains(mainCam.transform.position))
        {
            playerNear = true;
            character.Menu.SetActive(true);
            menu = character.Menu;
        }
        else
        {
            playerNear = false;
            character.Menu.SetActive(false);
            menu = null;
        }

        if (playerNear)
        {
            Vector3 newPos = mainCam.transform.position;
            newPos += mainCam.transform.forward * menuDistance;
            newPos += mainCam.transform.up * menuOffsetY;
            newPos += mainCam.transform.right * menuOffsetX;
            character.Menu.transform.position = Vector3.Lerp(character.Menu.transform.position, newPos, Time.deltaTime * smoothSpeed);

            charName.text = character.name;
            charEmotion.text = character.Emotion;
            charSupport.text = character.SupportTypes[0];
            charTheme.text = character.Themes[0];
        }
	}

    private void SetMenuItems()
    {
        if(menu != null)
        {

        }
    }
}
