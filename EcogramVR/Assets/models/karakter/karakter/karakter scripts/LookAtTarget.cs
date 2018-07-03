using System;
using UnityEngine;


public class LookAtTarget : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        target = GameObject.Find("Table").transform;

        if (target == null)
            target = Camera.main.transform;
    }

    void Update()
    {
        if (target != null)
        {

            Vector3 lookPos = target.position;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);
            transform.Rotate(new Vector3(0, 0, 0));
        }

    }
}