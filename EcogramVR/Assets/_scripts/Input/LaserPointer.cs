using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{

    private Transform laserOriginObject;
    private LineRenderer lineRender;

    public GameObject pointedObject;

    // Use this for initialization
    void Start()
    {
        laserOriginObject = gameObject.transform;
        lineRender = gameObject.AddComponent<LineRenderer>();
        lineRender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(laserOriginObject.position, laserOriginObject.forward, out hit, 25f, LayerMask.GetMask("ControllerCollider")))
        {
            lineRender.SetPositions(new Vector3[2] { laserOriginObject.position, hit.point });

            lineRender.useWorldSpace = true;
            lineRender.enabled = true;

        };



    }
}
