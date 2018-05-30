using System;
using UnityEngine;


public class LookAtTarget : MonoBehaviour
{
	public Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
	{
		if(target != null)
		{
			transform.LookAt(target);
            transform.Rotate(-90, 0, 0);



		}
	}
}