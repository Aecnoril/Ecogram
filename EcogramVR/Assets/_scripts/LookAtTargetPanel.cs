using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetPanel : MonoBehaviour {

    public Transform target;

    private void Start()
    {
        target = Camera.main.transform;
    }

    void Update()
    {
        if (target != null)
        {

            Vector3 lookPos = target.position;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);
            transform.Rotate(new Vector3(0, 180, 0));
        }

    }
}
