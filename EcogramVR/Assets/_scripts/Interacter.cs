using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(Camera) )]
public class Interacter : MonoBehaviour {

    private Camera c = Camera.main;
    [SerializeField]
    private float hitRange = 50.0f;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, hitRange))
            Gizmos.DrawSphere(hit.point, 1.0f);


    }
}
