using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    public List<GameObject> Panels;
    public int currentPanel = 0;

    public void SwitchPanel(bool up)
    {

        int upDown = (up) ? currentPanel + 1 : currentPanel - 1 ;
        if(upDown < 0)
            upDown = Panels.Count - 1;
        else if (upDown > Panels.Count - 1)
            upDown = 0;
        Panels[currentPanel].SetActive(false);
        Debug.Log("Old Panel: " + currentPanel);
        currentPanel = upDown;
        Debug.Log("New Panel: " + currentPanel);
        Panels[currentPanel].SetActive(true); ;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.J))
            SwitchPanel(false);
        if (Input.GetKeyDown(KeyCode.H))
            SwitchPanel(true);
    }
}
