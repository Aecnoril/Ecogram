using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    public void EnablePanel(GameObject panel)
    {
        //panel.transform.position = Vector3.zero;
        //panel.transform.SetParent(parent);
        panel.SetActive(true);
    }

    public void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
