using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts.backend.character
{
    public class Character : MonoBehaviour
    {
        
        private string characterName;
        private string emotion;
        private string relation;
        private List<string> supportTypes;
        private List<string> themes;
        private GameObject menu;

        public GameObject charObj;

        #region Properties
        public string CharacterName
        {
            get { return characterName; }
            set { characterName = value; charObj.name = value; }
        }

        public string Emotion
        {
            get { return emotion; }
            set { emotion = value; }
        }

        public string Relation
        {
            get { return relation; }
            set { relation = value; }
        }

        public List<string> SupportTypes
        {
            get { return supportTypes; }
            set { supportTypes = value; }
        }

        public List<string> Themes
        {
            get { return themes; }
            set { themes = value; }
        }

        public GameObject Menu
        {
            set { menu = value; }
        }
        #endregion

        public void InitiateChar()
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0, 10, 0), Vector3.down, out hit, 50f, LayerMask.GetMask("Terrain"));
            Debug.DrawLine(transform.position + new Vector3(0, 10, 0), hit.point, Color.red, 2.0f);

            transform.position = hit.point;
        }

        public void OpenCharacter()
        {
            menu.SetActive(true);
        }

        public void CloseCharacter()
        {
            menu.SetActive(false);
        }

    }
}