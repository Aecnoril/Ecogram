using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Scene Loader/switcher
/// Koen van Vliet - Aecnorilkoen@gmail.com
/// </summary>
public class SceneLoader : MonoBehaviour
{
    //public Text loadingTip;
    //public Text loadingText;
    //public Texture2D progressBar;

    private AsyncOperation async;

    /// <summary>
    /// Starts coroutine loading a scene
    /// </summary>
    /// <param name="sceneName">Exact name of the scene that has to be loaded</param>
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadLevelCR(sceneName));
        //loadingText.text = "Loading...";
    }

    private IEnumerator LoadLevelCR(string scene)
    {
        async = SceneManager.LoadSceneAsync(scene);
        yield return async;
    }

    private void RandomText()
    {
        throw new System.NotImplementedException();
    }

    private void OnGUI()
    {
        if (async != null)
        {
            //GUI.DrawTexture(new Rect(0, 0, 100 * async.progress, 50), progressBar);
        }
    }

}