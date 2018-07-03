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

        [HideInInspector]
        public CharacterManager charManager;
        [HideInInspector]
        public ObjectiveManager objectiveManager;
        public Material fadeMat;
        [HideInInspector]
        public GameObject Player;


        private void Awake()
        {
            //Make sure there is one and only one charactermanager in the app
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(this);

            charManager = ScriptableObject.CreateInstance(typeof(CharacterManager)) as CharacterManager;
            objectiveManager = GetComponent<ObjectiveManager>();
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        public void SpawnCharacter()
        {
            Vector3 spawnPos = Camera.main.transform.position + (Camera.main.transform.forward * 3);
            charManager.CreateCharacter(spawnPos);
        }

        public void StartTutorial()
        {
            FadeTable();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K)) SpawnCharacter();
            if (Input.GetKeyDown(KeyCode.J)) charManager.RemoveCharater();
        }

        void FadeTable()
        {
            foreach (Renderer r in GameObject.Find("Table").GetComponentsInChildren<Renderer>())
            {
                Texture tempTex = r.material.mainTexture;
                r.material = fadeMat;
                if (r.materials.Length != 1)
                    StartCoroutine(FadeTo(r.materials[1], 0.0f, 3f, true));
                r.material.mainTexture = tempTex;
                StartCoroutine(FadeTo(r.material, 0.0f, 3f, true));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="material"></param>
        /// <param name="targetOpacity"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        IEnumerator FadeTo(Material material, float targetOpacity, float duration, bool reverse)
        {
            Color color = material.color;
            float startOpacity = color.a;

            float t = 0;

            while (t < duration)
            {
                t += Time.deltaTime;
                float blend = Mathf.Clamp01(t / duration);
                color.a = (reverse) ? Mathf.Lerp(startOpacity, targetOpacity, 1 - blend) : Mathf.Lerp(startOpacity, targetOpacity, blend);

                material.color = color;

                yield return null;
            }
        }
    }
}