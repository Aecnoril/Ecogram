﻿using UnityEngine;
using System.Collections;

namespace NewtonVR.Example
{
    public class NVRExampleLetterResult : MonoBehaviour
    {
        public LetterSpinner LetterSpinner;

        private TextMesh Text;

        private void Awake()
        {
            Text = this.GetComponent<TextMesh>();
        }

        private void Update()
        {
            Text.text = LetterSpinner.GetLetter();
        }
    }
}