using Assets._scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public List<GameObject> Panels;

    public void OpenPanel (string panelName)
    {
        PanelTypes type = (PanelTypes)Enum.Parse(typeof (PanelTypes), panelName);
        foreach (GameObject panel in Panels)
        {
            switch (type)
            {
                case PanelTypes.Appearance:
                    if (panel.name == "Menu_Appearance")
                        panel.SetActive(true);
                    else
                        panel.SetActive(false);
                    break;
                case PanelTypes.Attributes:
                    if (panel.name == "Menu_Attributes")
                        panel.SetActive(true);
                    else
                        panel.SetActive(false);
                    break;
                case PanelTypes.Info:
                    if (panel.name == "Menu_Info")
                        panel.SetActive(true);
                    else
                        panel.SetActive(false);
                    break;
                case PanelTypes.Options:
                    if (panel.name == "Menu_Options")
                        panel.SetActive(true);
                    else
                        panel.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
            OpenPanel(PanelTypes.Info.ToString());

        if (Input.GetKey(KeyCode.Keypad2))
            OpenPanel(PanelTypes.Options.ToString());

        if (Input.GetKey(KeyCode.Keypad3))
            OpenPanel(PanelTypes.Attributes.ToString());

        if (Input.GetKey(KeyCode.Keypad4))
            OpenPanel(PanelTypes.Appearance.ToString());
    }

}
