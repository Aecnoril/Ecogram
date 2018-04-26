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

        #region Properties
        public string CharacterName
        {
            get { return characterName; }
            set { characterName = value; }
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
        #endregion

        /// <summary>
        /// Opens character menu facing the player
        /// </summary>
        public void OpenMenu()
        {

        }

    }
}