﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    public UnityEvent onPush;

    private Vector3 localAnchor;
    private Vector3 pushedAnchor;

    private Color startColor;
    [SerializeField]
    private Color pushColor;
    [SerializeField]
    private float pushDistance = 0.01f;

    [SerializeField]
    private bool isTouched;
    [SerializeField]
    private float returnDamp = 0.1f;

    public bool pushed = false;

    // Use this for initialization
    void Start()
    {
        localAnchor = transform.localPosition;
        pushedAnchor = transform.localPosition - (Vector3.down * pushDistance);

        startColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pushedDistance = transform.localPosition - localAnchor;
        float distance = 0.0f;
        distance = Math.Abs(pushedDistance.y);
        float press = Mathf.Clamp(1 / pushDistance * distance, 0f, 1f);

        GetComponent<Renderer>().material.color = Color.Lerp(startColor, pushColor, press);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!pushed)
        {
            StartCoroutine(MoveButton(false));
        }

        isTouched = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        isTouched = false;
    }

    private IEnumerator MoveButton(bool up)
    {
        if (up)
        {
            while (transform.localPosition.y > pushedAnchor.y + 0.01f)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, pushedAnchor, returnDamp * Time.deltaTime);
                yield return null;
            }

            onPush.Invoke();
            pushed = true;
            StartCoroutine(MoveButton(true));
        }
        else
        {
            while (!isTouched && transform.localPosition.y < localAnchor.y - 0.01f )
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, localAnchor, returnDamp * Time.deltaTime);
                yield return null;
            }
            pushed = false;
        }
    }
}
