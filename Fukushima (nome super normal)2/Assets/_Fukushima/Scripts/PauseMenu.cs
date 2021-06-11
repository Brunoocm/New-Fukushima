using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool paused;
    public GameObject player;

    public GameObject thisGameobject;

    private Lanterna lanternaScript;

    private void Awake()
    {
        lanternaScript = player.GetComponent<Lanterna>();
        Resume();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            PauseMenuVoid();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Resume();
        }
    }
    private void PauseMenuVoid()
    {
        Time.timeScale = 0;
        thisGameobject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        paused = true;
        lanternaScript.ligaDesligaHUD();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        thisGameobject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
        lanternaScript.ligaDesligaHUD();
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);

    }
}
