using Assets.scripts.backend.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts.backend.character
{
    public class CharacterManager : ScriptableObject
    {

        [Tooltip("Prefab for spawning new characters")]
        [SerializeField]
        private GameObject characterPrefab;
        [Tooltip("Amount of character objects to pool")]
        [Range(1, 128)]
        [SerializeField]
        private int characterPoolSize = 16;

        private List<GameObject> CharacterPool; //Character pool to avoid constant initializing

        //private List<Character> characters;

        private void OnEnable()
        {
            CharacterPool = new List<GameObject>();
            characterPrefab = GameManager.instance.charPrefab;
            IncreasePool(characterPoolSize);
        }

        #region Character modifications
        public void CreateCharacter(Vector3 position)
        {
            //If there is a character in the pool, take it out and activate it. Otherwise increase the poolsize
            if (CharacterPool.Count > 0)
            {
                GameObject charObj = CharacterPool[CharacterPool.Count - 1];
                CharacterPool.Remove(charObj);
                charObj.SetActive(true);
                charObj.transform.position = position;
                charObj.GetComponent<Character>().InitiateChar();
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
                GameObject charObj = Instantiate(characterPrefab, Vector3.zero, Quaternion.Euler(-90, 0, 0));

                Character character = charObj.AddComponent<Character>();
                character.charObj = charObj;
                character.CharacterName = "Naam " + CharacterPool.Count;
                character.Emotion = "Blij";
                character.Relation = "";
                character.SupportTypes = new List<string>();
                character.Themes = new List<string>();

                character.Menu = charObj.transform.GetChild(1).gameObject;

                charObj.SetActive(false);
                CharacterPool.Add(charObj);
            }
            Debug.Log("Poolsize: " + CharacterPool.Count);
        }

    }
}
