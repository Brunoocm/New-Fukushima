using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]private GameObject loadScreen;
    [SerializeField] private Slider slider;

    public void ChangeScene(string name)
    {
        StartCoroutine(LoadAsync(name));
        
    }

    IEnumerator LoadAsync (string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        loadScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

    public void Assets()
    {

        Application.OpenURL("https://docs.google.com/document/d/175osTysu2XbmJGgF7VHd8PMk7bBlyHlxIdmhDVVcm1M/edit");
    }

    public void Sair()
    {
        Application.Quit();
    }

 
}
