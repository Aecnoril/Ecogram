using Assets.scripts.backend.game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

public class Objective : MonoBehaviour
{
    public enum ObjectiveType
    {
        Area,
        Object,
        Deliver,
        Event
    }

    public ObjectiveType objectiveType = ObjectiveType.Area;
    [SerializeField]
    private Collider triggerArea;
    [SerializeField]
    private GameObject triggerObject;
    private Player player;
    public UnityEvent onComplete;

    public string name;
    public bool complete;
    public string objectiveText;

    public bool CheckObjective()
    {
        switch (objectiveType)
        {
            case ObjectiveType.Area:
                return CheckArea();
            case ObjectiveType.Object:
                return CheckObject();
            case ObjectiveType.Deliver:
                return CheckEvent();
            case ObjectiveType.Event:
                return CheckEvent();
            default:
                return false;
        }
    }

    private bool CheckObject()
    {
        throw new NotImplementedException();
    }

    private bool CheckArea()
    {
        if (triggerArea.bounds.Contains(player.headCollider.transform.position))
        {
            complete = true;
            onComplete.Invoke();
        }

        return complete;
    }

    private bool CheckEvent()
    {
        throw new NotImplementedException();
    }

    private void Awake()
    {
        player = Player.instance;
    }
}
