using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DisplayName : MonoBehaviour {

    public TextMeshPro textmesh;




    private void OnTriggerExit(Collider other)
    {
        TextMesh textmeshPro = GetComponent<TextMesh>();

        textmeshPro.text= textmesh.text;

    }

}

