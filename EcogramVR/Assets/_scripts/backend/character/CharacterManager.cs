using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts.backend.character
{
    class CharacterManager : MonoBehaviour
    {
        public static CharacterManager instance = null; //Static obect reference
        [Tooltip("Prefab for spawning new characters")]
        [SerializeField]
        private GameObject characterPrefab;
        [Tooltip("Amount of character objects to pool")]
        [Range(1, 128)]
        [SerializeField]
        private int characterPoolSize = 16;

        private List<GameObject> CharacterPool; //Character pool to avoid constant initializing

        //private List<Character> characters;

        public void Awake()
        {
            //Make sure there is one and only one charactermanager in the app
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            CharacterPool = new List<GameObject>();
        }

        public void Start()
        {
            IncreasePool(characterPoolSize);
        }

        #region Character modifications
        public void CreateCharacter(Vector3 position, Quaternion rotation)
        {
            //If there is a character in the pool, take it out and activate it. Otherwise increase the poolsize
            if(CharacterPool.Count > 0)
            {
                GameObject charObj = CharacterPool[CharacterPool.Count - 1];
                charObj.SetActive(true);
                charObj.transform.position = position;
                charObj.transform.rotation = rotation;
                CharacterPool.Remove(charObj);
            }
            else
            {
                Debug.Log("Pool ran out! Increasing size..");
                IncreasePool(characterPoolSize);
            }
        }

        public void RemoveCharater(GameObject charObj)
        {
            charObj.SetActive(false);
            //Put the character back in the pool. If the pool is overflowing, delete character
            if (CharacterPool.Count < characterPoolSize)
                CharacterPool.Add(charObj);
            else
                Destroy(charObj);
        }

        public void EditCharacter()
        {
            throw new NotImplementedException();
        }

        public void LoadCharacters()
        {
            throw new NotImplementedException();
        }
        #endregion

        //Maybe coroutine?
        /// <summary>
        /// Increases the amount of pooled character objects
        /// </summary>
        /// <param name="amt">Amount to increase the pool with</param>
        private void IncreasePool(int amt)
        {
            for (int i = 0; i < amt; i++)
            {
                GameObject charObj = Instantiate(characterPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero));
                charObj.SetActive(false);
                CharacterPool.Add(charObj);
            }
            Debug.Log("Poolsize: " + CharacterPool.Count);
        }

        
    }
}
