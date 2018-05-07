using Assets.scripts.backend.character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts.backend.game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null; //Static obect reference

        public GameObject charPrefab;

        public CharacterManager charManager;

        private void Awake()
        {
            //Make sure there is one and only one charactermanager in the app
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(this);

            charManager = ScriptableObject.CreateInstance(typeof(CharacterManager)) as CharacterManager;
        }

        public void SpawnCharacter()
        {
            charManager.CreateCharacter(new Vector3(260, 0.2f, 246), Quaternion.Euler(Vector3.zero));
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}