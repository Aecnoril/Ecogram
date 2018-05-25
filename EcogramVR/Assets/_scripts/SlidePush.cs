using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlidePush : MonoBehaviour
{
    public UnityEvent onPush;

    private Vector3 localAnchor;
    private Vector3 pushedAnchor;
    private Quaternion localRotation;
    [SerializeField]
    private bool xLock;
    [SerializeField]
    private bool yLock;
    [SerializeField]
    private bool zLock;
    [SerializeField]
    private float minDist = 0.0f;
    [SerializeField]
    private float maxDist = 0.5f;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float activationDist = 0.009f;

    private Color startColor;
    [SerializeField]
    private Color pushColor;

    [SerializeField]
    private bool isTouched;
    [SerializeField]
    private float returnDamp = 4.0f;

    public bool pushed = false;

    // Use this for initialization
    void Start()
    {
        localAnchor = transform.localPosition;
        localRotation = transform.rotation;

        startColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 lockedPos = transform.localPosition;

        if (xLock)
            lockedPos.x = localAnchor.x;
        if (yLock)
            lockedPos.y = localAnchor.y;
        if (zLock)
            lockedPos.z = localAnchor.z;

        if (!xLock)
        {
            if (lockedPos.x > localAnchor.x + minDist)
                lockedPos.x = localAnchor.x + minDist;
            else if (lockedPos.x < localAnchor.x - maxDist)
                lockedPos.x = localAnchor.x - maxDist;
        }
        if (!yLock)
        {
            if (lockedPos.y > localAnchor.y + minDist)
                lockedPos.y = localAnchor.y + minDist;
            else if (lockedPos.y < localAnchor.y - maxDist)
                lockedPos.y = localAnchor.y - maxDist;
        }
        if (!zLock)
        {
            if (lockedPos.z > localAnchor.z + minDist)
                lockedPos.z = localAnchor.z + minDist;
            else if (lockedPos.z < localAnchor.z - maxDist)
                lockedPos.z = localAnchor.z - maxDist;
        }

        transform.localPosition = lockedPos;
        transform.localRotation = localRotation;

        transform.localPosition = Vector3.Lerp(transform.localPosition, localAnchor, returnDamp * Time.deltaTime);

        Vector3 pushDistance = transform.localPosition - localAnchor;
        float distance = 0.0f;
        if (!xLock) distance = Math.Abs(pushDistance.x);
        if (!yLock) distance = Math.Abs(pushDistance.y);
        if (!zLock) distance = Math.Abs(pushDistance.z);
        float press = Mathf.Clamp(1 / activationDist * distance, 0f, 1f);
        Debug.Log(press);

        if (!pushed && press > 0.9f)
        {
            onPush.Invoke();
            GetComponent<Rigidbody>().isKinematic = true;
            pushed = true;
        }
        else if (pushed && press < 0.01f)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            pushed = false;
        }

        GetComponent<Renderer>().material.color = Color.Lerp(startColor, pushColor, press);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isTouched = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isTouched = false;
    }
}
