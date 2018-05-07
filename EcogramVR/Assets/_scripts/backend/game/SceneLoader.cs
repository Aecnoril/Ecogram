using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Text loadingTip;
    public Text loadingText;
    public Texture2D progressBar;

    [SerializeField]
    private string sceneName = "Scenename";

    private AsyncOperation async;

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadLevelCR(sceneName));
        loadingText.text = "Loading...";
    }

    private IEnumerator LoadLevelCR(string Level)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
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
            GUI.DrawTexture(new Rect(0, 0, 100 * async.progress, 50), progressBar);
        }
    }

}