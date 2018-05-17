using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.scripts.backend.game
{
    public class ObjectiveManager : MonoBehaviour
    {
        public List<GameObject> GOObjectives;
        private List<Objective> objectives;
        private List<Objective> completedObjectives;

    // Use this for initialization
    void Start()
        {
            objectives = new List<Objective>();
            completedObjectives = new List<Objective>();
            
            foreach(GameObject obj in GOObjectives)
            {
                objectives.Add(obj.GetComponent<Objective>());
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (Objective obj in objectives.ToList())
            {
                if (obj.CheckObjective())
                {
                    completedObjectives.Add(obj);
                    Debug.Log("Objective " + obj.name + " complete!");
                    objectives.Remove(obj);
                }
            }
        }
    }
}